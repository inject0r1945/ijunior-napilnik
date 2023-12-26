using System;
using System.Collections.Generic;
using System.Text;

namespace NapilnikStore
{
    public class Shop : IGoodReserve
    {
        private Warehouse _warehouse;

        public Shop()
        {
            _warehouse = new Warehouse();
        }

        public Shop(Warehouse warehouse)
        {
            _warehouse = warehouse;
        }

        public void Reserve(List<ItemPosition> itemPositions)
        {
            foreach (ItemPosition itemPosition in itemPositions)
            {
                _warehouse.TakeItemPosition(itemPosition);
            }
        }

        public Cart Cart()
        {
            Cart cart = new Cart(this, _warehouse);
            return cart;
        }
    }
}
