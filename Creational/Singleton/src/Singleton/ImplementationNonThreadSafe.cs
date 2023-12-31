﻿namespace Singleton;

/// <summary>
/// Singleton
/// </summary>
public class Logger
{
    private static Logger? _instance;
    public static Logger Instance
    {
        get
        {
            if (_instance == null)
                _instance = new Logger();

            return _instance;
        }
    }

    // protected so that clients cannot instantiate, but it can be subclassed
    protected Logger() { }

    /// <summary>
    /// SingletonOperation
    /// </summary>
    /// <param name="message"></param>
    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}