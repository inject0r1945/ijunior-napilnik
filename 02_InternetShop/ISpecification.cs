namespace NapilnikStore
{
    public interface ISpecification<T>
    {
        public bool IsSatisfiedBy(T candidate);
    }
}
