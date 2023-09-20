﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NapilnikStore
{
    class Cart
    {
        private Dictionary<string, ItemPosition> _cart;
        private Shop _shop;

        public Cart(Shop shop)
        {
            _shop = shop;
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
            bool isAvailable = _shop.IsAvailableGood(good, count, out int countAvailable);

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
            _shop.Reserve(_cart.Values.ToList());
        }
    }
}
