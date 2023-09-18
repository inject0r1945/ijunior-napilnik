namespace NapilnikStore
{
    class ItemPosition
    {
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
            ValidateFunctions.ValidateArgumentLargeOrEqualZero(count);
            Count += count;
        }

        public void Decrease(int count)
        {
            ValidateFunctions.ValidateArgumentLargeOrEqualZero(count);
            Count -= count;
        }
    }
}
