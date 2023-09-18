using System;
using System.Collections.Generic;
using System.Text;

namespace NapilnikStore
{
    static class ValidateFunctions
    {
        static public void ValidateArgumentLargeOrEqualZero(int argument)
        {
            if (argument < 0)
                throw new ArgumentOutOfRangeException(nameof(argument));
        }
    }
}
