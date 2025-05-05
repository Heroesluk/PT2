using PT2.logic;
using Tests;
using Tests.logic.helper;

namespace TestLogicLayer
{
    [TestClass]
    public class CatalogServiceTests
    {
        [TestMethod]
        public void AddItemToCatalog_ValidItem_ShouldAddSuccessfully()
        {
            var fakeDataService = new FakeDataService();
            var catalogService = new CatalogService(fakeDataService);
            int itemId = 0;
            string name = "Test Item";
            string description = "Test Description";
            float price = 10.0f;

            catalogService.AddItemToCatalog(itemId, name, description, price);
            var item = fakeDataService.itemRepo.GetItem(itemId);
            Assert.IsNotNull(item);
            Assert.AreEqual(name, item.Name);
            Assert.AreEqual(description, item.Description);
            Assert.AreEqual(price, item.Price);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddItemToCatalog_NegativePrice_ShouldThrowException()
        {
            var fakeDataService = new FakeDataService();
            var catalogService = new CatalogService(fakeDataService);

            catalogService.AddItemToCatalog(1, "Test Item", "Test Description", -5.0f);
        }

        [TestMethod]
        public void GetItemById_ExistingItem_ShouldReturnItem()
        {
            var fakeDataService = new FakeDataService();
            var catalogService = new CatalogService(fakeDataService);
            var item = new MockItem(0, "Test Item", "Test Description", 10.0f);;
            fakeDataService.itemRepo.AddItem(item);

            var result = catalogService.GetItemById(0);

            Assert.IsNotNull(result);
            Assert.AreEqual(item.Name, result.Name);
        }
    }
}