using PT2.data.API;
using PT2.logic;

using Tests.logic.helper;

namespace Tests.logic
{
    [TestClass]
    public class CatalogServiceTests
    {
        //private class FakeItemRepository : IItemRepository
        //{
        //    Dictionary<int, IItem> _items = new Dictionary<int, IItem>();

        //    public void AddItem(IItem item)
        //    {
        //        if (item == null)
        //            throw new ArgumentNullException(nameof(item));

        //        if (_items.ContainsKey(item.Id))
        //            throw new InvalidOperationException("Item already exists.");

        //        _items[item.Id] = item;
        //    }
            
            
        //    public IItem GetItem(int itemId)
        //    {
        //        _items.TryGetValue(itemId, out var item);
        //        return item;
        //    }

        //    public IEnumerable<IItem> GetAllItems()
        //    {
        //        return _items.Values;
        //    }

        //    public void UpdateItem(IItem item)
        //    {
        //        if (!_items.ContainsKey(item.Id))
        //            throw new InvalidOperationException("Item not found.");
        //        _items[item.Id] = item;
        //    }

        //    public void DeleteItem(int itemId)
        //    {
        //        if (!_items.Remove(itemId))
        //            throw new InvalidOperationException("Item not found.");
        //    }

        //    public IItem GetItemByName(string name)
        //    {
        //        foreach (var item in _items.Values)
        //        {
        //            if (item.Name == name)
        //                return item;
        //        }
        //        return null;
        //    }

        //    public List<IItem> GetItemsByPriceCutOff(float priceCutOff, string upDown)
        //    {
        //        var result = new List<IItem>();
        //        foreach (var item in _items.Values)
        //        {
        //            if ((upDown == "up" && item.Price >= priceCutOff) ||
        //                (upDown == "down" && item.Price <= priceCutOff))
        //            {
        //                result.Add(item);
        //            }
        //        }
        //        return result;
        //    }
        //}

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