using PT2.logic.services;
using Tests.logic.helper;

namespace Tests.logic
{
    [TestClass]
    public class EventHistoryServiceTests
    {


        [TestMethod]
        public void GetAllEvents_ShouldReturnAllEvents()
        {
            var fakeEventRepository = new FakeEventRepository();
            var eventHistoryService = new EventHistoryService(fakeEventRepository);

            var event1 = new MockPurchaseEvent(1,1);
            fakeEventRepository.AddEvent(event1);

            var events = eventHistoryService.GetAllPurchaseEvents();

            Assert.AreEqual(1, events.Count);
            Assert.IsTrue(events.Contains(event1));
        }
    }
}