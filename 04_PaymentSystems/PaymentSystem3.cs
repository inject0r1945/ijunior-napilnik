namespace PaymentSystems
{
    public class PaymentSystem3 : IPaymentSystem
    {
        private string _paymentLinkTemplate = "https://system3.com/pay?curency=RUB&";

        private int _secretCode;

        public PaymentSystem3(int secretCode)
        {
            _secretCode = secretCode;
        }

        public string GetPayingLink(Order order)
        {
            return $"{_paymentLinkTemplate}amount={order.Amount}&hash={HashUtils.GetSHA1Hash((order.Id + order.Amount + _secretCode).ToString())}";
        }
    }
}
