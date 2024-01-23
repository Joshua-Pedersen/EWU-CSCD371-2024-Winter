using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

[TestClass]
public class LogFactoryTests
{
    [TestMethod]
    public void CreateBaseLogger_NoFile_Null()
    {
        LogFactory factory = new();
        BaseLogger? logger = factory.CreateLogger(nameof(LogFactoryTests));
        Assert.IsNull(logger);
    }

    [TestMethod]
    public void CreateBaseLogger_File_Logger()
    {
        LogFactory factory = new();
        factory.ConfigureFileLogger("foo");
        BaseLogger? logger = factory.CreateLogger(nameof(LogFactoryTests));
        Assert.IsInstanceOfType(logger, typeof(FileLogger));
    }
}
