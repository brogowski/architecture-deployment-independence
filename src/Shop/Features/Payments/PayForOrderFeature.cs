using System;

namespace Features.Payments
{
    class PayForOrderFeature
    {
        PaymentGateway PreparePayment(string orderId, string paymentType)
        {
            throw new NotImplementedException();
        }

        void CompletePayment(string paymentId)
        {
            throw new NotImplementedException();
        }

        void CancelPayment(string paymentId)
        {
            throw new NotImplementedException();
        }
    }

    class PaymentGateway
    {
        public string PaymentId { get; set; }
    }
}
