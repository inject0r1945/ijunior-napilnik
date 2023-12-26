namespace NapilnikStore
{
    public interface IGoodAvailable
    {
        public bool IsAvailableGood(Good good, int count, out int countAvailable);
    }
}
