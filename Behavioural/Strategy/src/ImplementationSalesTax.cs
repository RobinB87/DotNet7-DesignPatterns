namespace Strategy;
public class ImplementationSalesTax
{
    /// <summary>
    /// Strategy
    /// </summary>
    public interface ISalesTax
    {
        public int GetTax();
    }
    
    /// <summary>
    /// Concrete strategy
    /// </summary>
    public class SwedenSalesTax : ISalesTax
    {
        public int GetTax()
        {
            return 0;
        }
    }

    /// <summary>
    /// Concrete strategy
    /// </summary>
    public class UsaSalesTax : ISalesTax
    {
        public int GetTax()
        {
            return 0;
        }
    }

    /// <summary>
    /// Concept
    /// </summary>
    public class Order
    {
        ShippingDetails ShippingDetails;
        List<Item> Items;

        public Order(ShippingDetails shippingDetails, List<Item> items)
        {
            ShippingDetails = shippingDetails;
            Items = items;
        }
    }

    public class ShippingDetails
    {
        public string OriginCountry { get; set; } = string.Empty;
        public string DestinationCountry { get; set; } = string.Empty;
    }

    public class Item
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public ItemType ItemType { get; set; }
    }

    public enum ItemType
    {
        Literature = 0,
        Service = 1,
    }
}