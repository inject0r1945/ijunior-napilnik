using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NapilnikStore
{
    public class Cart
    {
        private Dictionary<string, ItemPosition> _cart;
        private IGoodReserve _goodReserver;
        private IGoodAvailable _itemAvailableChecker;

        public Cart(IGoodReserve goodReserver, IGoodAvailable itemAvailableChecker)
        {
            _goodReserver = goodReserver;
            _itemAvailableChecker = itemAvailableChecker;
            _cart = new Dictionary<string, ItemPosition>();
        }

        public void Show()
        {
            Console.WriteLine($"Товары в корзине:\n");

            foreach (ItemPosition currentCartPosition in _cart.Values)
                Console.WriteLine($"{currentCartPosition.Item.Name}: {currentCartPosition.Count} шт.");
        }

        public void Add(Good good, int count)
        {
            bool isAvailable = _itemAvailableChecker.IsAvailableGood(good, count, out int countAvailable);

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
            ReserveItems();

            return order;
        }

        private void Merge(ItemPosition itemPosition)
        {
            if (_cart.ContainsKey(itemPosition.Item.Name))
                _cart[itemPosition.Item.Name] = itemPosition;
            else
                _cart.Add(itemPosition.Item.Name, itemPosition);
        }

        private void ReserveItems()
        {
            _goodReserver.Reserve(_cart.Values.ToList());
        }
    }
}
