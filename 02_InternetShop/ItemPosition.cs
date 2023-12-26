using System;

namespace NapilnikStore
{
    public class ItemPosition
    {
        private LinqSpecification<int> _equalOrGreatZeroSpecification  = new IntEqualOrGreatZeroSpecification();

        public Good Item { get; private set; }

        public int Count { get; private set; }

        public bool IsEmpty => Count == 0;

        public ItemPosition(Good item, int count)
        {
            Item = item;
            Count = count;
        }

        public void Increase(int count)
        {
            if (!_equalOrGreatZeroSpecification.IsSatisfiedBy(count))
                throw new ArgumentOutOfRangeException(nameof(count));

            Count += count;
        }

        public void Decrease(int count)
        {
            if (!_equalOrGreatZeroSpecification.IsSatisfiedBy(count))
                throw new ArgumentOutOfRangeException(nameof(count));

            if (_equalOrGreatZeroSpecification.IsSatisfiedBy(count))
                Count -= count;
        }
    }
}
