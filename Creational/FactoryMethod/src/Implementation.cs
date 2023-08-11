namespace FactoryMethod;

/// <summary>
/// Define an interface for creating an object, but let subclasses decide which class to instantiate.
/// 
/// Use cases:
///  * when a class can't anticipate the class of objects it must create (when you do not know in advance which types of object your code should work with - the concrete creators can take on this responsibility)
///  * when a class wants its subclasses to specify the objects it creates
///  * when classes delegate responsibility to one of several helper subclasses, and you want to localize the knowledge of which helper subclass is the delegate
///  * as a way of reusing existing objects
///  
/// SOLID:
///  * new types of products can be added without breaking client code (open closed principle)
///  * creating products is moved to one specific place in your code, the creator (single responsibility principle)
/// 
/// Drawbacks:
///  * clients might need to create subclasses of the creator class just to create a particular ConcreteProduct object
/// 
/// Related patterns:
///  * Abstract factory: often implemented with factory methods
///  * Prototype: no subclassing needed (not based on inheritance), but an initialize action on Product is often required
///  * Template: factory methods are often called from within template methods
/// </summary>

/// <summary>
/// Product
/// Abstract because we want the concrete products to implement the logic behind this
/// Can use interface as alternative
/// </summary>
public abstract class DiscountService
{
    public abstract int DiscountPercengate { get; }
    public override string ToString() => GetType().Name;
}

/// <summary>
/// ConcreteProduct
/// </summary>
public class CountryDiscountService : DiscountService
{
    private readonly string _countryId;

    public CountryDiscountService(string countryId)
    {
        _countryId = countryId;
    }

    public override int DiscountPercengate
    {
        get
        {
            return _countryId switch
            {
                "BE" => 20,
                _ => 10,
            };
        }
    }
}

/// <summary>
/// ConcreteProduct
/// </summary>
public class CodeDiscountService : DiscountService
{
    private readonly Guid _code;

    public CodeDiscountService(Guid code)
    {
        _code = code;
    }

    public override int DiscountPercengate
    {
        // each code return the same fixed percentage, but is only valid once
        // should include check to see if it is used
        get => 15;
    }
}

/// <summary>
/// Creator
/// </summary>
public abstract class DiscountFactory
{
    public abstract DiscountService CreateDiscountService();
}

/// <summary>
/// ConcreteCreator
/// </summary>
public class CountryDiscountFactory : DiscountFactory
{
    private readonly string _countryId;

    public CountryDiscountFactory(string countryId)
    {
        _countryId = countryId;
    }

    public override DiscountService CreateDiscountService()
        => new CountryDiscountService(_countryId);
}

/// <summary>
/// ConcreteCreator
/// </summary>
public class CodeDiscountFactory : DiscountFactory
{
    private readonly Guid _code;

    public CodeDiscountFactory(Guid code)
    {
        _code = code;
    }

    public override DiscountService CreateDiscountService()
        => new CodeDiscountService(_code);
}