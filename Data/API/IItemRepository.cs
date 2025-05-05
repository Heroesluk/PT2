namespace PT2.data.API
{
    public interface IItemRepository
    {
        void AddItem(IItem item);

        IItem GetItem(int itemId);

        IEnumerable<IItem> GetAllItems();
 
        void UpdateItem(IItem item);
        void DeleteItem(int itemId);

        IItem GetItemByName(string name);

        List<IItem> GetItemsByPriceCutOff(float priceCutOff, string upDown);

    }
}
