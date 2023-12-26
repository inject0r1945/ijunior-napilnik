namespace NapilnikStore
{
    public interface IItemAvailable
    {
        public bool IsAvailableGood(Good good, int count, out int countAvailable);
    }
}
