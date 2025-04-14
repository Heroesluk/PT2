
using PT2.logic.services;
using Tests.logic.helper;

namespace Tests.logic
{
    [TestClass]
    public class PurchaseServiceTests
    {
        

        [TestMethod]
        public void SellItem_ValidInputs_ShouldReduceStockAndLogEvent()
        {
            var fakeUserRepository = new FakeUserRepository();
            var fakeItemRepository = new FakeItemRepository();
            var fakeInventoryRepository = new FakeInventoryStateRepository();
            var fakeEventRepository = new FakeEventRepository();

            var purchaseService = new PurchaseService(
                fakeUserRepository,
                fakeItemRepository,
                fakeInventoryRepository,
                fakeEventRepository);

            var user = new MockUser(1, "testUser", "securePass", "test@example.com");
            fakeUserRepository.AddUser(user);

            var item = new MockItem(1, "Test Item", "Test Description", 10.0f);
            fakeItemRepository.AddItem(item);

            fakeInventoryRepository.UpdateInventoryState(1, 10);

            purchaseService.SellItem(1, 1, 2);

            var inventory = fakeInventoryRepository.GetInventoryState(1);
            Assert.AreEqual(8, inventory.Quantity);

            var events = fakeEventRepository.GetEventsByUserId(1);
            Assert.AreEqual(1, events.Count);
        }

        [TestMethod]
        public void CalculateTotalPrice_ValidInputs_ShouldReturnCorrectPrice()
        {
            var fakeItemRepository = new FakeItemRepository();
            var purchaseService = new PurchaseService(
                null,
                fakeItemRepository,
                null,
                null);

            var item = new MockItem(1, "Test Item", "Test Description", 10.0f);
            fakeItemRepository.AddItem(item);

            var totalPrice = purchaseService.CalculateTotalPrice(1, 3);
            Assert.AreEqual(30.0f, totalPrice);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SellItem_NonExistingUser_ShouldThrowException()
        {
            var fakeUserRepository = new FakeUserRepository();
            var fakeItemRepository = new FakeItemRepository();
            var fakeInventoryRepository = new FakeInventoryStateRepository();
            var fakeEventRepository = new FakeEventRepository();

            var purchaseService = new PurchaseService(
                fakeUserRepository,
                fakeItemRepository,
                fakeInventoryRepository,
                fakeEventRepository);

            purchaseService.SellItem(99, 1, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SellItem_InsufficientStock_ShouldThrowException()
        {
            var fakeUserRepository = new FakeUserRepository();
            var fakeItemRepository = new FakeItemRepository();
            var fakeInventoryRepository = new FakeInventoryStateRepository();
            var fakeEventRepository = new FakeEventRepository();

            var purchaseService = new PurchaseService(
                fakeUserRepository,
                fakeItemRepository,
                fakeInventoryRepository,
                fakeEventRepository);

            var user = new MockUser(1, "testUser", "securePass", "test@example.com");
            fakeUserRepository.AddUser(user);

            var item = new MockItem(1, "Test Item", "Test Description", 10.0f);
            fakeItemRepository.AddItem(item);

            fakeInventoryRepository.UpdateInventoryState(1, 1);

            purchaseService.SellItem(1, 1, 2);
        }
    }
}