namespace PaymentSystems
{
    public class PaymentSystem1 : IPaymentSystem
    {
        private string _paymentLinkTemplate = "https://pay.system1.ru/order?";
        private IHashingActing _hash;

        public PaymentSystem1(IHashingActing hash)
        {
            _hash = hash;
        }

        public string GetPayingLink(Order order)
        {
            return $"{_paymentLinkTemplate}amount={order.Amount}&hash={_hash.GetHash(order.Id.ToString())}";
        }
    }
}
