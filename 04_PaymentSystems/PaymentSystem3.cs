namespace PaymentSystems
{
    public class PaymentSystem3 : IPaymentSystem
    {
        private string _paymentLinkTemplate = "https://system3.com/pay?curency=RUB&";

        private int _secretCode;
        private IHashingActing _hash;

        public PaymentSystem3(int secretCode, IHashingActing hash)
        {
            _secretCode = secretCode;
            _hash = hash;
        }

        public string GetPayingLink(Order order)
        {
            return $"{_paymentLinkTemplate}amount={order.Amount}&hash={_hash.GetHash((order.Id + order.Amount + _secretCode).ToString())}";
        }
    }
}
