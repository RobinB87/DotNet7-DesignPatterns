using static Strategy.ImplementationSalesTax;

namespace Strategy.Tests.Unit
{
    public class ImplementationSalesTaxTests
    {
        [Fact]
        public void SwedenSalesTaxTest()
        {
            var shippingDetails = new ShippingDetails("Sweden", "Sweden");
            var items = new List<Item> { new Item("123", "The Stand", 5m, ItemType.Literature) };
            var order = new Order(shippingDetails, items);


        }
    }
}