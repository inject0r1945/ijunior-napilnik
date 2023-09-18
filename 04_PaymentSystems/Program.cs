using System;

namespace PaymentSystems
{
    class Program
    {
        static void Main(string[] args)
        {
            PaymentSystem1 paymentSystem1 = new PaymentSystem1();
            PaymentSystem2 paymentSystem2 = new PaymentSystem2();

            int secretCode = 12345678;
            PaymentSystem3 paymentSystem3 = new PaymentSystem3(secretCode);

            int orderAmount = 10;
            int orderId = 3;
            Order order = new Order(orderId, orderAmount);

            Console.WriteLine(paymentSystem1.GetPayingLink(order));
            Console.WriteLine(paymentSystem2.GetPayingLink(order));
            Console.WriteLine(paymentSystem3.GetPayingLink(order));
        }
    }
}