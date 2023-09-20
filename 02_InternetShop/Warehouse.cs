using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NapilnikStore
{
    class Warehouse
    {
        private List<ItemPosition> _itemPositions;
        private LinqSpecification<int> _equalOrGreatZeroSpecification = new IntEqualOrGreatZeroSpecification();

        public Warehouse()
        {
            _itemPositions = new List<ItemPosition>();
        }

        public void Show()
        {
            Console.WriteLine($"Количество товаров на складе:\n");

            foreach (ItemPosition currentItemPosition in _itemPositions)
                Console.WriteLine($"{currentItemPosition.Item.Name}: {currentItemPosition.Count} шт.");
        }

        public void Delive(Good good, int count)
        {
            ItemPosition itemPositionForDelieve = GetItemPosition(good);

            if (itemPositionForDelieve == null)
            {
                itemPositionForDelieve = new ItemPosition(good, count);
                _itemPositions.Add(itemPositionForDelieve);
            }
            else
            {
                itemPositionForDelieve.Increase(count);
            }
        }

        public bool IsAvailableGood(Good good, int count, out int availableCount)
        {
            ItemPosition itemPosition = GetItemPosition(good);

            if (itemPosition == null)
            {
                availableCount = 0;
                return false;
            }

            availableCount = itemPosition.Count;

            return availableCount >= count;
        }

        public ItemPosition TakeItemPosition(ItemPosition itemPosition)
        {
            return TakeItemPosition(itemPosition.Item, itemPosition.Count);
        }

        public ItemPosition TakeItemPosition(Good good, int count)
        {
            if (!_equalOrGreatZeroSpecification.IsSatisfiedBy(count))
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            ItemPosition warehouseItemPosotion = GetItemPosition(good);

            if (warehouseItemPosotion == null)
                throw new ArgumentOutOfRangeException($"Товар '{good.Name}' отсутствует на складе");

            if (warehouseItemPosotion.Count < count)
                throw new ArgumentOutOfRangeException($"Не хватает нужного количества товара '{good.Name}'");

            warehouseItemPosotion.Decrease(count);

            return new ItemPosition(good, count);
        }

        private ItemPosition GetItemPosition(Good good)
        {
            return _itemPositions.FirstOrDefault(x => x.Item.Name == good.Name);
        }
    }
}
