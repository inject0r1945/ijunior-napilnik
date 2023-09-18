namespace PaymentSystems
{
    public class PaymentSystem1 : IPaymentSystem
    {
        private string _paymentLinkTemplate = "https://pay.system1.ru/order?";

        public string GetPayingLink(Order order)
        {
            return $"{_paymentLinkTemplate}amount={order.Amount}&hash={HashUtils.GetMD5Hash(order.Id.ToString())}";
        }
    }
}
