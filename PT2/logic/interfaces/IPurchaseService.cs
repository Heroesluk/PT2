namespace PT2.logic.interfaces
{
    public interface IPurchaseService
    {
        void SellItem(int userId, int itemId, int quantity);
        float CalculateTotalPrice(int itemId, int quantity);

    }
}
