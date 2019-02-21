using LogServices.Settings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LogServices
{
    public class DataBaseLogServices
    {
        public void LogError(string message, KindOfError error)
        {
            var da = new DataAccess();
            var parametros = new Dictionary<string, object>
            {
                { "@message", message },
                { "@error", (int)error }
            };

            da.ExecuteSP("sp_log_error", parametros);
        }
    }

    public class ConsoleLogServices
    {
        public void LogError(string message, KindOfError error)
        {
            switch (error)
            {
                case KindOfError.Message:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case KindOfError.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case KindOfError.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                default:
                    break;
            }

            Console.WriteLine(DateTime.Now + " - " + message);
        }
    }

    public class FileLogServices
    {
        public void LogError(string message)
        {
            var result = string.Empty;
            var filePath = System.Configuration.ConfigurationManager.AppSettings["LogFileDirectory"].ToString() + "LogFile" + DateTime.Now.ToShortDateString().Replace("/", "-") + ".txt";
            
            if (File.Exists(filePath))
                File.AppendAllText(filePath, DateTime.Now + " - " + message + Environment.NewLine);
            else
                File.WriteAllText(filePath, DateTime.Now + " - " + message + Environment.NewLine);

        }
    }
}
