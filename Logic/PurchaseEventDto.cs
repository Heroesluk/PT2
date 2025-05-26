using PT2.data.API;

namespace PT2.Logic

{
    internal class PurchaseEventDto: IEvent
    {
        public int ItemId { get; set; }
        public int Quantity { get; set; }

        public PurchaseEventDto(int userId,  int itemId, int quantity, DateTime timestamp)
        {
            ItemId = itemId;
            Quantity = quantity;
            UserId = userId;
            EventName = "Purchase";
        }

        public int EventId { get; set; }
        public string EventName { get; set; }
        public DateTime Timestamp { get; set; }
        public int UserId { get; set; }
        public string EventDescription { get; set; }
    }
}