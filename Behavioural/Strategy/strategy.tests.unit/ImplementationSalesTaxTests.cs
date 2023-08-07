using static Strategy.ImplementationSalesTax;

namespace Strategy.Tests.Unit
{
    public class ImplementationSalesTaxTests
    {
        [Fact]
        public void SwedenSalesTaxTest()
        {
            var shippingDetails = new ShippingDetails("Sweden", "Sweden");
            var items = new List<Item> 
            { 
                new Item("123", "The Stand", 12.99m, ItemType.Literature),
                new Item("125", "C# consultancy", 125m, ItemType.Service)
            };
            
            var order = new Order(shippingDetails, items);
            order.ISalesTaxStrategy = new SwedenSalesTaxStrategy();
            var tax = order.GetTax();

            Assert.Equal(8.5392M, tax);
        }
    }
}