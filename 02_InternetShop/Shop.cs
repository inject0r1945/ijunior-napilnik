using System;
using System.Collections.Generic;
using System.Text;

namespace NapilnikStore
{
    class Shop
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

        public Cart Cart()
        {
            Cart cart = new Cart(this);

            return cart;
        }

        public bool IsAvailableGood(Good good, int count, out int countAvailable)
        {
            return _warehouse.IsAvailableGood(good, count, out countAvailable);
        }

        public void Reserve(List<ItemPosition> itemPositions)
        {
            foreach (ItemPosition itemPosition in itemPositions)
            {
                _warehouse.TakeItemPosition(itemPosition);
            }
        }
    }
}
