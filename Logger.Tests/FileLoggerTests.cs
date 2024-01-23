using System;
using System.IO;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

[TestClass]
public class FileLoggerTests
{
    [TestMethod]
    public void Log_Message_AppendsInfo()
    {
        FileLogger logger = new("Path.txt")
        { ClassName = nameof(FileLoggerTests) };

        logger.Log(LogLevel.Information, "foo");
        string output = File.ReadAllText("Path.txt");
        Assert.IsTrue(output.Contains("foo"));
        File.Delete("Path.txt");
    }
}
