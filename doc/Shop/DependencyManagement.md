# Dependency management

In `Shop` example we need to solve dependency requirements for all components.

This can be implemented in 2 possible ways:

- Using direct communication (either in single process system or as distributed system)
- Using data manipulation

## Problem

After making order user's shopping cart should be emptied. (MakeOrderFeature)

Orders Component --> ShoppingCarts Component

### Solution 1: Direct communication

> Component encapsulates it's own resoruces (like: data storage) so direct communication is required

All necessary data is provided by communication with other components.

Implementation will use communication protocol (like HTTP or just function invoke) to send messages to other component.

### Solution 2: Data manipulation

> Components use shared resources to communicate indirectly

In this case there is no (direct) communication between components.

Only shared resources (data) are modified to fulfill requirements. 

This time, implementation will clear all products from given shopping cart manually (ex: by SQL delete statement).
