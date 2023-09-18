namespace PaymentSystems
{
    public interface IPaymentSystem
    {
        public string GetPayingLink(Order order);
    }
}
