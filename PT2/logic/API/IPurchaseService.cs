namespace PT2.logic.API
{
    public interface IPurchaseService
    {
        void SellItem(int userId, int itemId, int quantity);
        float CalculateTotalPrice(int itemId, int quantity);

    }
}
