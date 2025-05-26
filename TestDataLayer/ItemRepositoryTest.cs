using PT2.data;

namespace TestDataLayer
{
    [TestClass]
    public class ItemRepositoryTests
    {
        private ItemRepository _repository;

        [TestInitialize]
        public void Setup()
        {
            var dataContext = new DataContext();
            _repository = new ItemRepository(dataContext);

            _repository.AddItem(new Item { Id = 0, Name = "Item1", Description = "Description1", Price = 10.0f });
            _repository.AddItem(new Item { Id = 1, Name = "Item2", Description = "Description2", Price = 20.0f });
        }

        [TestMethod]
        public void GetItem_ExistingItem_ReturnsCorrectItem()
        {
            var expectedItemId = 0;

            var result = _repository.GetItem(expectedItemId);

            Assert.IsNotNull(result);
            Assert.AreEqual(expectedItemId, result.Id);
        }

        [TestMethod]
        public void GetItem_NonExistingItem_ThrowsException()
        {
            var nonExistingItemId = 999;

            Assert.ThrowsException<InvalidOperationException>(
                () => _repository.GetItem(nonExistingItemId)
            );
        }

        [TestMethod]
        public void AddItem_DuplicateId_ThrowsException()
        {
            var duplicateItem = new Item { Id = 0, Name = "DuplicateItem", Description = "DuplicateDescription", Price = 15.0f };

            Assert.ThrowsException<InvalidOperationException>(
                () => _repository.AddItem(duplicateItem)
            );
        }

        [TestMethod]
        public void UpdateItem_ExistingItem_UpdatesSuccessfully()
        {
            var updatedItem = new Item { Id = 0, Name = "UpdatedItem", Description = "UpdatedDescription", Price = 12.0f };

            _repository.UpdateItem(updatedItem);
            var result = _repository.GetItem(0);

            Assert.AreEqual("UpdatedItem", result.Name);
            Assert.AreEqual("UpdatedDescription", result.Description);
            Assert.AreEqual(12.0f, result.Price);
        }

        [TestMethod]
        public void DeleteItem_ExistingItem_RemovesSuccessfully()
        {
            var itemIdToDelete = 0;

            _repository.DeleteItem(itemIdToDelete);

            Assert.ThrowsException<InvalidOperationException>(
                () => _repository.GetItem(itemIdToDelete)
            );
        }
    }
}
