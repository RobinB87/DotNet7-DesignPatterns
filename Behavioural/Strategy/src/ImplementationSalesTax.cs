namespace Strategy;
public class ImplementationSalesTax
{
    /// <summary>
    /// Strategy
    /// </summary>
    public interface ISalesTax
    {
        public decimal GetTax(Order order);
    }
    
    /// <summary>
    /// Concrete strategy
    /// </summary>
    public class SwedenSalesTax : ISalesTax
    {
        public decimal GetTax(Order order)
        {
            return order.Price * 0.25m;
        }
    }

    /// <summary>
    /// Concrete strategy
    /// </summary>
    public class UsaSalesTax : ISalesTax
    {
        public decimal GetTax(Order order)
        {
            return 0;
        }
    }

    /// <summary>
    /// Context
    /// </summary>
    public class Order
    {
        public ShippingDetails ShippingDetails;
        public List<Item> Items;

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

        public ShippingDetails(string originCountry, string destinationCountry)
        {
            OriginCountry = originCountry;
            DestinationCountry = destinationCountry;
        }
    }

    public class Item
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public ItemType ItemType { get; set; }

        public Item(string id, string name, decimal price, ItemType itemType)
        {
            Id = id;
            Name = name;
            Price = price;
            ItemType = itemType;
        }
    }

    public enum ItemType
    {
        Literature = 0,
        Service = 1,
    }
}