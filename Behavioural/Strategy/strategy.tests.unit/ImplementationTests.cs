using static Strategy.Implementation;

namespace Strategy.Tests.Unit
{
    public class ImplementationTests
    {
        private static Order Order = new Order("Henk", "StrategyTest", 5);

        [Fact]
        public void CsvExportServiceTest()
        {
            Order.Export(new CsvExportService());
            Assert.Equal("Csv", Order.ExportedTo);
        }

        [Fact]
        public void JsonExportServiceTest()
        {
            Order.Export(new JsonExportService());
            Assert.Equal("Json", Order.ExportedTo);
        }

        [Fact]
        public void XmlExportServiceTest()
        {
            Order.Export(new XmlExportService());
            Assert.Equal("Xml", Order.ExportedTo);
        }
    }
}