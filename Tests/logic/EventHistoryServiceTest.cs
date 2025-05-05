using PT2.logic;
using Tests.logic.helper;

namespace Tests.logic
{
    [TestClass]
    public class EventHistoryServiceTests
    {


        [TestMethod]
        public void GetAllEvents_ShouldReturnAllEvents()
        {
            var fakeDataService = new FakeDataService();
            var eventHistoryService = new EventHistoryService(fakeDataService);            

            var event1 = new MockPurchaseEvent(1,1);
            fakeDataService.eventRepo.AddEvent(event1);

            var events = eventHistoryService.GetAllPurchaseEvents();

            Assert.AreEqual(1, events.Count);
            Assert.IsTrue(events.Contains(event1));
        }
    }
}