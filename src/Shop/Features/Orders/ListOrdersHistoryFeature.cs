using System;
using System.Collections.Generic;

namespace Features.Orders
{
    class ListOrdersHistoryFeature
    {
        private readonly IGetOrderHistoryFeatureDataAccess _dataAccess;

        public ListOrdersHistoryFeature(IGetOrderHistoryFeatureDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        IEnumerable<Order> ListOrders(Query query) => _dataAccess.ListOrders(query);
    }

    interface IGetOrderHistoryFeatureDataAccess
    {
        IEnumerable<Order> ListOrders(Query query);
    }

    class Query
    {
        public int Take { get; set; }
        public int Skip { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
    }

    class Order
    {
        public DateTime ConfirmationDate { get; set; }
        public decimal TotalPrice { get; set; }
        public OrderStatus Status { get; set; }
        public string Id { get; set; }
    }
}
