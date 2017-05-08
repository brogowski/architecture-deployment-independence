using System;
using System.Collections.Generic;

namespace Features.Orders
{
    class MakeOrderFeature
    {
        OrderConfirmationResult MakeOrder(IEnumerable<string> productIds)
        {
            throw new NotImplementedException();
        }
    }

    class OrderConfirmationResult
    {
        public bool CompletedSuccessfully { get; set; }
        public string OrderId { get; set; }
        public string Message { get; set; } 
    }
}
