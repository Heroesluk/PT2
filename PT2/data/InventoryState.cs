using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PT2.data.API;

namespace PT2.data
{
    // this will be used to represent number of specific item in the inventory
    public class InventoryState : IInventoryState
    {
        public int ItemId { get; set; }

        public int Quantity { get; set; }

    }
}