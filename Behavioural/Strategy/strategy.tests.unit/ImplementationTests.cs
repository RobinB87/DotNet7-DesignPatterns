using static Strategy.Implementation;

namespace Strategy.Tests.Unit
{
    public class ImplementationTests
    {
        private static Order Order = new Order("Henk", "StrategyTest", 5);

        [Fact]
        public void CsvExportServiceTest()
        {
            Order.ExportService = new CsvExportService();
            Order.Export();
            Assert.Equal("Csv", Order.ExportedTo);
        }

        [Fact]
        public void JsonExportServiceTest()
        {
            Order.ExportService = new JsonExportService();
            Order.Export();
            Assert.Equal("Json", Order.ExportedTo);
        }

        [Fact]
        public void XmlExportServiceTest()
        {
            Order.ExportService = new XmlExportService();
            Order.Export();
            Assert.Equal("Xml", Order.ExportedTo);
        }
    }
}