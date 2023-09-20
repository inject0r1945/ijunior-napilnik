using System;
using System.Linq.Expressions;

namespace NapilnikStore
{
    public abstract class LinqSpecification<T> : ISpecification<T>
    {
        public bool IsSatisfiedBy(T candidate) => MakeExpression().Compile()(candidate);

        public abstract Expression<Func<T, bool>> MakeExpression();
    }
}
