namespace Strategy;
public class Implementation
{
    /// <summary>
    /// Strategy
    /// </summary>
    public interface IExportService
    {
        void Export(Order order);
    }

    /// <summary>
    /// ConcreteStrategy
    /// </summary>
    public class JsonExportService : IExportService
    {
        public void Export(Order order)
        {
            order.ExportedTo = "Json";
            Console.WriteLine($"Exporting {order.Name} to {order.ExportedTo}.");
        }
    }

    /// <summary>
    /// ConcreteStrategy
    /// </summary>
    public class XmlExportService : IExportService
    {
        public void Export(Order order)
        {
            order.ExportedTo = "Xml";
            Console.WriteLine($"Exporting {order.Name} to {order.ExportedTo}.");
        }
    }

    /// <summary>
    /// ConcreteStrategy
    /// </summary>
    public class CsvExportService : IExportService
    {
        public void Export(Order order)
        {
            order.ExportedTo = "Csv";
            Console.WriteLine($"Exporting {order.Name} to {order.ExportedTo}.");
        }
    }

    /// <summary>
    /// Context
    /// </summary>
    public class Order
    {
        public string Customer { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int Amount { get; set; }

        public string? ExportedTo { get; set; }
        public string? Description { get; set; }
        public IExportService? ExportService { get; set; }

        public Order(string customer, string name, int amount)
        {
            Customer = customer;
            Name = name;
            Amount = amount;
        }

        // Here the strategy is used to export the order, but
        // the order class does not know which concrete implementation of the strategy it uses.
        // All it knows something of type IExportService is used to export itself.
        public void Export()
        {
            ExportService?.Export(this);
        }
    }
}