namespace PT2.logic.API
{
    public interface IInventoryService
    {
        void AddStock(int itemId, int quantity);
        int GetItemStock(int itemId);
        void RemoveStock(int itemId, int quantity);

    }
}
