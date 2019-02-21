using LogServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AppBelatrix.Test
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestWithoutKindOfLog()
        {
            Assert.IsFalse(JobLogger.LogMessage("mensaje", KindOfError.Error, null));
        }

        [TestMethod]
        public void TestEmptyMessage()
        {
            var kindOfLogs = new KindOfLogs();
            kindOfLogs.LogToConsole = true;
            Assert.IsFalse(JobLogger.LogMessage("   ", KindOfError.Error, kindOfLogs));
        }

        [TestMethod]
        public void TestLogConsole()
        {
            var kindOfLogs = new KindOfLogs();
            kindOfLogs.LogToConsole = true;
            Assert.IsTrue(JobLogger.LogMessage("mensaje", KindOfError.Error, kindOfLogs));
        }

        [TestMethod]
        public void TestLogTextFile()
        {
            var kindOfLogs = new KindOfLogs();
            kindOfLogs.LogToFile = true;
            Assert.IsTrue(JobLogger.LogMessage("mensaje", KindOfError.Error, kindOfLogs));
        }

        [TestMethod]
        public void TestLogDataBase()
        {
            var kindOfLogs = new KindOfLogs();
            kindOfLogs.LogToDatabase = true;
            Assert.IsTrue(JobLogger.LogMessage("mensaje", KindOfError.Error, kindOfLogs));
        }
    }
}
