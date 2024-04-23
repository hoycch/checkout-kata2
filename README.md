Supermarket Checkout System Unit Tests
This repository only contains unit tests part. The main project locates at https://github.com/hoycch/checkout-kata
This directory contains the unit tests for the Supermarket Checkout System project. The tests are written using the NUnit testing framework and follow a test-driven development (TDD) approach.
Test Structure
The unit tests are organized into the following classes:
BasketTests
This class contains tests for the Basket class, which manages the items scanned by the customer and their quantities. The tests cover the following scenarios:

Adding a new item to the basket
Incrementing the quantity of an existing item
Decrementing the quantity of an existing item
Removing an item from the basket when its quantity becomes zero
Retrieving the quantity of an existing item
Retrieving the quantity of a non-existing item

CheckoutTests
This class contains tests for the Checkout class, which implements the main logic for scanning items and calculating the total price based on the pricing rules. The tests cover the following scenarios:

Calculating the total price when no items are scanned
Calculating the total price for a single item without a special price
Calculating the total price for multiple items without special prices
Calculating the total price for items with special prices
Calculating the total price for a mix of items with and without special prices
Handling the case when an item without a pricing rule is scanned
