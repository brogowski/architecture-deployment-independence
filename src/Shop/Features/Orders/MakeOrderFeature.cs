using System.Collections.Generic;

namespace Features.Orders
{
    class MakeOrderFeature
    {
        private readonly IMakeOrderFeatureDataAccess _dataAccess;
        private readonly IShoppingCart _shoppingCart;

        public MakeOrderFeature(IMakeOrderFeatureDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        OrderConfirmationResult MakeOrder(IEnumerable<string> productIds)
        {
            var id = _dataAccess.SaveOrder(productIds);
            _shoppingCart.Clear();
            return new OrderConfirmationResult
            {
                CompletedSuccessfully = true,
                Message = "Order saved correctly.",
                OrderId = id
            };
        }
    }

    interface IShoppingCart
    {
        void Clear();
    }

    interface IMakeOrderFeatureDataAccess
    {
        string SaveOrder(IEnumerable<string> productIds);
    }

    class OrderConfirmationResult
    {
        public bool CompletedSuccessfully { get; set; }
        public string OrderId { get; set; }
        public string Message { get; set; } 
    }
}
