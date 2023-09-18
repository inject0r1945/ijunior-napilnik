using System;
using System.Collections.Generic;
using System.Text;

namespace NapilnikStore
{
    class Order
    {
        private Random _randomGenerator = new Random();
        private int _minOrderNumber = 1000;
        private int _maxOrderNumber = 999999;
        private string _url = "https://mymagazine.best.ru/order=";

        public string Paylink { get; private set; }

        public Order()
        {
            Paylink = _url + _randomGenerator.Next(_minOrderNumber, _maxOrderNumber).ToString();
        }
    }
}
