namespace Singleton;

/// <summary>
/// Use cases:
///  * when there must be exactly one instance of a class
///  * when the sole instance should be extensible by subclassing and clients should be able to use an extended instance without modifying their code
/// 
/// Drawbacks:
///  * Violates the single responsibility principle: objects not only control how they are created, they also manage their own lifecycle
///     - in modern languages you do not often write code like this anymore, this is mostly dealt with by an IOC container
/// 
/// Related patterns:
///  * Abstract factory, Builder, Prototype: can all be implemented as a singleton
///  * State: also often implemented as singletons
/// </summary>
public class LoggerThreadSafe
{
    // readonly as it does not needs to change during the singleton's lifetime
    // immediately initialize it as a Lazy<T> type. This does not mean that the logger itself is constructed,
    // but we pass through a method that will be used for construction when we first access
    // the lazy loggers value property
    private static readonly Lazy<LoggerThreadSafe> _lazyLogger
        = new Lazy<LoggerThreadSafe>(() => new LoggerThreadSafe());

    public static LoggerThreadSafe Instance
    {
        // The first time this is accessed, the logger will be construction using the action above.
        // Every time after this, the same instance will be returned in a THREAD SAFE manner.
        get => _lazyLogger.Value;
    }

    // protected so that clients cannot instantiate, but it can be subclassed
    protected LoggerThreadSafe() { }

    /// <summary>
    /// SingletonOperation
    /// </summary>
    /// <param name="message"></param>
    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}