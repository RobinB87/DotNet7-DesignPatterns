namespace Strategy;
public class ImplementationSalesTax
{
    /// <summary>
    /// Strategy
    /// </summary>
    public interface ISalesTaxStrategy
    {
        public decimal GetTax(Order order);
    }
    
    /// <summary>
    /// Concrete strategy
    /// </summary>
    public class SwedenSalesTaxStrategy : ISalesTaxStrategy
    {
        public decimal GetTax(Order order)
        {
            var destination = order.ShippingDetails.DestinationCountry.ToLowerInvariant();
            var origin = order.ShippingDetails.OriginCountry.ToLowerInvariant();
            if (destination != origin) return 0m;

            var totalTax = 0m;
            foreach (var item in order.Items)
            {
                switch (item.ItemType)
                {
                    case ItemType.Service:
                        totalTax += item.Price * 0.06m;
                        break;

                    case ItemType.Literature:
                        totalTax += item.Price * 0.08m;
                        break;

                    default:
                        totalTax += item.Price * 0.05m;
                        break;
                }
            }

            return totalTax;
        }
    }

    /// <summary>
    /// Concrete strategy
    /// </summary>
    public class UsaSalesTaxStrategy : ISalesTaxStrategy
    {
        public decimal GetTax(Order order)
        {
            switch (order.ShippingDetails.DestinationCountry.ToLowerInvariant())
            {
                case "la": return order.TotalPrice * 0.095m;
                case "ny": return order.TotalPrice * 0.04m;
                case "nyc": return order.TotalPrice * 0.045m;
                default: return 0m;
            }
        }
    }

    /// <summary>
    /// Context
    /// </summary>
    public class Order
    {
        public ShippingDetails ShippingDetails;
        public List<Item> Items;
        public decimal TotalPrice;
        public ISalesTaxStrategy? ISalesTaxStrategy { get; set; }

        public Order(ShippingDetails shippingDetails, List<Item> items)
        {
            ShippingDetails = shippingDetails;
            Items = items;
            TotalPrice = Items.Sum(item => item.Price);
        }

        public decimal GetTax()
        {
            if (ISalesTaxStrategy == null) return 0m;
            return ISalesTaxStrategy.GetTax(this);
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