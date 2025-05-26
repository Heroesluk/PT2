using Data;
using Microsoft.EntityFrameworkCore;
using PT2.data;

namespace TestDataLayer
{
    [TestClass]
    public class InventoryStateDbRepositoryTests
    {
        private TestDbContext _dbContext;
        private InventoryStateDbRepository _repository;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<TestDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _dbContext = new TestDbContext(options);
            _repository = new InventoryStateDbRepository(_dbContext);

            // Seed data
            _dbContext.Inventory.Add(new InventoryState(1, 10));
            _dbContext.Inventory.Add(new InventoryState(2, 20));
            _dbContext.SaveChanges();
        }

        [TestCleanup]
        public void Cleanup()
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext.Dispose();
        }

        [TestMethod]
        public void AddInventoryState_ValidState_AddsSuccessfully()
        {
            var newState = new InventoryState(3, 30);

            _repository.AddInventoryState(newState);

            var result = _repository.GetInventoryState(3);
            Assert.IsNotNull(result);
            Assert.AreEqual(30, result.Quantity);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddInventoryState_DuplicateItemId_ThrowsException()
        {
            var duplicateState = new InventoryState(1, 15);

            _repository.AddInventoryState(duplicateState);
        }

        [TestMethod]
        public void GetInventoryState_ExistingItem_ReturnsCorrectState()
        {
            var result = _repository.GetInventoryState(1);

            Assert.IsNotNull(result);
            Assert.AreEqual(10, result.Quantity);
        }



        [TestMethod]
        public void UpdateInventoryState_ExistingItem_UpdatesSuccessfully()
        {
            _repository.UpdateInventoryState(1, 50);

            var result = _repository.GetInventoryState(1);
            Assert.AreEqual(50, result.Quantity);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void UpdateInventoryState_NonExistingItem_ThrowsException()
        {
            _repository.UpdateInventoryState(999, 50);
        }

        [TestMethod]
        public void RemoveInventoryState_ExistingItem_RemovesSuccessfully()
        {
            _repository.RemoveInventoryState(1);

            var result = _repository.GetInventoryState(1);
            Assert.IsNull(result);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RemoveInventoryState_NonExistingItem_ThrowsException()
        {
            _repository.RemoveInventoryState(999);
        }

        [TestMethod]
        public void GetAllInventoryStates_ReturnsAllStates()
        {
            var result = _repository.GetAllInventoryStates();

            Assert.AreEqual(2, result.Count);
        }
    }
}