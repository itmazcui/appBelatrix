using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogServices;

namespace AppBelatrix
{
    public static class JobLogger
    {
        static void Main(string[] args)
        {
        }

        private static DataBaseLogServices _dataBaseLogServices;
        private static FileLogServices _fileLogServices;
        private static ConsoleLogServices _consoleLogServices;

        public static bool LogMessage(string message, KindOfError error, KindOfLogs log)
        {
            try
            {
                InstanceServices();
                message = message.Trim();

                if (message == string.Empty) return false;

                if (!log.LogToConsole && !log.LogToFile && !log.LogToDatabase) throw new Exception("Invalid configuration");

                if (log.LogToDatabase)
                    _dataBaseLogServices.LogError(message, error);

                if (log.LogToFile)
                    _fileLogServices.LogError(message);

                if (log.LogToConsole)
                    _consoleLogServices.LogError(message, error);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        private static void InstanceServices()
        {
            if (_dataBaseLogServices == null)
                _dataBaseLogServices = new DataBaseLogServices();

            if (_fileLogServices == null)
                _fileLogServices = new FileLogServices();

            if (_consoleLogServices == null)
                _consoleLogServices = new ConsoleLogServices();
            
        }
    }
}
