using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentSystems
{
    public interface IHashingActing
    {
        public string GetHash(string input);
    }
}
