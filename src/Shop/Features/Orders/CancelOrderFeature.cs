namespace Features.Orders
{
    class CancelOrderFeature
    {
        private readonly ICancelOrderFeatureDataAccess _dataAccess;

        public CancelOrderFeature(ICancelOrderFeatureDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        void CancelOrder(string orderId) => _dataAccess.CancelOrder(orderId);
    }

    interface ICancelOrderFeatureDataAccess
    {
        void CancelOrder(string orderId);
    }
}
