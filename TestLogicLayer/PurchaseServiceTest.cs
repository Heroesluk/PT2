using PT2.logic;
using Tests.logic.helper;

namespace TestLogicLayer
{
    [TestClass]
    public class PurchaseServiceTests
    {
        

        [TestMethod]
        public void SellItem_ValidInputs_ShouldReduceStockAndLogEvent()
        {
            var fakeDataService = new FakeDataService();

            var purchaseService = new PurchaseService(fakeDataService);

            var user = new MockUser(1, "testUser", "securePass", "test@example.com");
            fakeDataService.userRepo.AddUser(user);

            var item = new MockItem(1, "Test Item", "Test Description", 10.0f);
            fakeDataService.itemRepo.AddItem(item);

            fakeDataService.inventoryStateRepo.UpdateInventoryState(1, 10);

            purchaseService.SellItem(1, 1, 2);

            var inventory = fakeDataService.inventoryStateRepo.GetInventoryState(1);
            Assert.AreEqual(8, inventory.Quantity);

            var events = fakeDataService.eventRepo.GetEventsByUserId(1);
            Assert.AreEqual(1, events.Count);
        }

        [TestMethod]
        public void CalculateTotalPrice_ValidInputs_ShouldReturnCorrectPrice()
        {
            var fakeDataService = new FakeDataService();

            var purchaseService = new PurchaseService(fakeDataService);

            var item = new MockItem(1, "Test Item", "Test Description", 10.0f);
            fakeDataService.itemRepo.AddItem(item);

            var totalPrice = purchaseService.CalculateTotalPrice(1, 3);
            Assert.AreEqual(30.0f, totalPrice);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SellItem_NonExistingUser_ShouldThrowException()
        {
            var fakeDataService = new FakeDataService();

            var purchaseService = new PurchaseService(fakeDataService);

            purchaseService.SellItem(99, 1, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SellItem_InsufficientStock_ShouldThrowException()
        {
            var fakeDataService = new FakeDataService();

            var purchaseService = new PurchaseService(fakeDataService);

            var user = new MockUser(1, "testUser", "securePass", "test@example.com");
            fakeDataService.userRepo.AddUser(user);

            var item = new MockItem(1, "Test Item", "Test Description", 10.0f);
            fakeDataService.itemRepo.AddItem(item);

            fakeDataService.inventoryStateRepo.UpdateInventoryState(1, 1);

            purchaseService.SellItem(1, 1, 2);
        }
    }
}
