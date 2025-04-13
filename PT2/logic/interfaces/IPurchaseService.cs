using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT2.logic.interfaces
{
    public interface IPurchaseService
    {
        void SellItem(int userId, int itemId, int quantity);
        float CalculateTotalPrice(int itemId, int quantity);

    }
}
