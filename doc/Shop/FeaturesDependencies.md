# Features & Dependencies

> List of all features in Shop system and their relationships. 

> All relationships are **indirect** (separated by polimorfic dispatch ex: interface). 

## Order

- MakeOrder
- CancelOrder
- ListOrders
- GetOrderSummary

Dependency\Feature | MakeOrder         | CancelOrder | ListOrders   | GetOrderSummary          |
:-----------------:|:-----------------:|:-----------:|:------------:|:------------------------:|
Payments           |                   |             | IsOrderPaid? | IsOrderPaid?             |
Products           |                   |             |              | GetProductDetails        |
ShoppingCarts      | ClearShoppingCart |             |              |                          |

## Payments

- PayForOrder

Dependency\Feature | PayForOrder   |
:-----------------:|:-------------:|
Orders             | GetOrderPrice |

## Products

- GetProductDetails
- ListProducts

## ShoppingCarts

- GetCart
- EditCart