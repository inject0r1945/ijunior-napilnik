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
            Cart newCart = new Cart(_warehouse);

            return newCart;
        }
    }
}
