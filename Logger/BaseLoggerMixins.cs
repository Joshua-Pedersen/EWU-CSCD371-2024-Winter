using System;
using System.Globalization;

namespace Logger;

public static class BaseLoggerMixins
{
    public static void LoggerNullCheck(BaseLogger? logger)
    {
        ArgumentNullException.ThrowIfNull(logger);
    }
    
    public static void Error(this BaseLogger? logger, string message, params object[] args)
    {
        LoggerNullCheck(logger);
        string info = string.Format(CultureInfo.CurrentCulture, message, args);
        logger!.Log(LogLevel.Error, info);
    }
    public static void Warning(this BaseLogger? logger, string message, params object[] args)
    {
        LoggerNullCheck(logger);
        string info = string.Format(CultureInfo.CurrentCulture, message, args);
        logger!.Log(LogLevel.Warning, info);
    }
    public static void Information(this BaseLogger? logger, string message, params object[] args)
    {
        LoggerNullCheck(logger);
        string info = string.Format(CultureInfo.CurrentCulture, message, args);
        logger!.Log(LogLevel.Information, info);
    }
    public static void Debug(this BaseLogger? logger, string message, params object[] args)
    {
        LoggerNullCheck(logger);
        string info = string.Format(CultureInfo.CurrentCulture, message, args);
        logger!.Log(LogLevel.Debug, info);
    }

}
