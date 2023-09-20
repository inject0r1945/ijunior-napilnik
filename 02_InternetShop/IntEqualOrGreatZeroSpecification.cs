using System;
using System.Linq.Expressions;

namespace NapilnikStore
{
    public class IntEqualOrGreatZeroSpecification : LinqSpecification<int>
    {
        public override Expression<Func<int, bool>> MakeExpression()
        {
            return x => x >= 0;
        }
    }
}
