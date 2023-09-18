namespace PaymentSystems
{
    public class PaymentSystem2 : IPaymentSystem
    {
        private string _paymentLinkTemplate = "https://order.system2.ru/pay?hash=";

        public string GetPayingLink(Order order)
        {
            return $"{_paymentLinkTemplate}{HashUtils.GetMD5Hash((order.Id + order.Amount).ToString())}";
        }
    }
}
