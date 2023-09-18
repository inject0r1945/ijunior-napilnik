using System;
using System.Collections.Generic;
using System.Text;

namespace NapilnikStore
{
    class Cart
    {
        private List<ItemPosition> _cart;
        private Warehouse _warehouse;

        public Cart(Warehouse warehouse)
        {
            _warehouse = warehouse;
            _cart = new List<ItemPosition>();
        }

        public void Show()
        {
            Console.WriteLine($"Товары в корзине:\n");

            foreach (ItemPosition currentCartPosition in _cart)
                Console.WriteLine($"{currentCartPosition.Item.Name}: {currentCartPosition.Count} шт.");
        }

        public void Add(Good good, int count)
        {
            bool isAvailable = _warehouse.IsAvailableGood(good, count, out int countAvailable);

            if (!isAvailable)
            {
                if (countAvailable == 0)
                    Console.WriteLine($"[ОШИБКА]: Товар '{good.Name}' отсутствует на складе");
                else
                    Console.WriteLine($"[ОШИБКА]: Недостаточное количество товара '{good.Name}' на складе");

                return;
            }

            Merge(new ItemPosition(good, count));
        }

        public Order Order()
        {
            if (_cart.Count == 0)
                return null;

            Order order = new Order();
            ReserveCart();

            return order;
        }

        private void Merge(ItemPosition itemPosition)
        {
            int existItemPositionindex = _cart.IndexOf(itemPosition);

            if (existItemPositionindex == -1)
            {
                _cart.Add(itemPosition);
            }
            else
            {
                _cart[existItemPositionindex] = itemPosition;
            }
        }

        private void ReserveCart()
        {
            foreach (ItemPosition cartItemPosition in _cart)
            {
                _warehouse.TakeItemPosition(cartItemPosition);
            }
        }
    }
}
