namespace Features.Payments
{
    class PayForOrderFeature
    {
        private readonly IPaymentProcessor _paymentProcessor;
        private readonly IPayForOrderFeatureDataAccess _dataAccess;

        public PayForOrderFeature(IPaymentProcessor paymentProcessor, IPayForOrderFeatureDataAccess dataAccess)
        {
            _paymentProcessor = paymentProcessor;
            _dataAccess = dataAccess;
        }

        PaymentGateway PreparePayment(string orderId, string paymentType)
        {
            var orderPrice = _dataAccess.GetOrderPrice(orderId);
            var paymentId = _paymentProcessor.CreatePayment(new Payment
            {
                Price = orderPrice,
                Description = $"Payment for order: {orderId}",
                Type = paymentType
            });
            return new PaymentGateway(paymentId);
        }

        void CompletePayment(string paymentId) => _paymentProcessor.CompletePayment(paymentId);

        void CancelPayment(string paymentId) => _paymentProcessor.CancelPayment(paymentId);
    }

    interface IPayForOrderFeatureDataAccess
    {
        decimal GetOrderPrice(string orderId);
    }

    class Payment
    {
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
    }

    interface IPaymentProcessor
    {
        void CancelPayment(string paymentId);
        void CompletePayment(string paymentId);
        string CreatePayment(Payment payment);
    }

    class PaymentGateway
    {
        public PaymentGateway(string paymentId)
        {
            PaymentId = paymentId;
        }

        public string PaymentId { get; set; }
    }
}
