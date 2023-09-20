namespace PaymentSystems
{
    public class PaymentSystem2 : IPaymentSystem
    {
        private string _paymentLinkTemplate = "https://order.system2.ru/pay?hash=";
        private IHashingActing _hash;

        public PaymentSystem2(IHashingActing hash)
        {
            _hash = hash;
        }

        public string GetPayingLink(Order order)
        {
            return $"{_paymentLinkTemplate}{_hash.GetHash((order.Id + order.Amount).ToString())}";
        }
    }
}
