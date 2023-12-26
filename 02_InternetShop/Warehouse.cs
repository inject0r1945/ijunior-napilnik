using System;
using System.Collections.Generic;
using System.Linq;

namespace NapilnikStore
{
    public class Warehouse : IGoodAvailable
    {
        private List<ItemPosition> _itemPositions;
        private Dictionary<Good, int> _availableGoods;
        private LinqSpecification<int> _equalOrGreatZeroSpecification = new IntEqualOrGreatZeroSpecification();

        public Warehouse()
        {
            _itemPositions = new List<ItemPosition>();
            _availableGoods = new Dictionary<Good, int>();
        }

        public bool IsAvailableGood(Good good, int count, out int countAvailable)
        {
            bool isExistsGood = _availableGoods.TryGetValue(good, out countAvailable);

            return isExistsGood && countAvailable >= count;
        }

        public void Show()
        {
            Console.WriteLine($"Количество товаров на складе:\n");

            foreach (KeyValuePair<Good, int> goodKeyValuePair in _availableGoods)
                Console.WriteLine($"{goodKeyValuePair.Key.Name}: {goodKeyValuePair.Value} шт.");
        }

        public void Delive(Good good, int count)
        {

            if (_availableGoods.ContainsKey(good))
            {
                _availableGoods[good] += count;
            }
            else
            {
                _availableGoods[good] = count;
            }
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

            bool isAvailableGood = _availableGoods.TryGetValue(good, out int goodAvailableCount);

            if (!isAvailableGood)
                throw new ArgumentOutOfRangeException($"Товар '{good.Name}' отсутствует на складе");

            if (goodAvailableCount < count)
                throw new ArgumentOutOfRangeException($"Не хватает нужного количества товара '{good.Name}'");

            _availableGoods[good] -= count;

            return new ItemPosition(good, count);
        }
    }
}
