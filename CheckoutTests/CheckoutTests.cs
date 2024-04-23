﻿using System;
using System.Collections.Generic;
using NUnit.Framework;
using SupermarketCheckout;

namespace CheckoutTests
{
    [TestFixture]
    public class CheckoutTests
    {
        [Test]
        public void GetTotalPrice_NoItemsScanned_ReturnsZero()
        {
            // Arrange
            var pricingRules = new List<PricingRule>();
            var checkout = new Checkout(pricingRules);

            // Act
            int totalPrice = checkout.GetTotalPrice();

            // Assert
            Assert.AreEqual(0, totalPrice);
        }

        [Test]
        public void GetTotalPrice_SingleItemWithoutSpecialPrice_ReturnsUnitPrice()
        {
            // Arrange
            var pricingRules = new List<PricingRule>
            {
                new PricingRule("A", 50, null)
            };
            var checkout = new Checkout(pricingRules);

            // Act
            checkout.Scan("A");
            int totalPrice = checkout.GetTotalPrice();

            // Assert
            Assert.AreEqual(50, totalPrice);
        }

        [Test]
        public void GetTotalPrice_MultipleItemsWithoutSpecialPrice_ReturnsSumOfUnitPrices()
        {
            // Arrange
            var pricingRules = new List<PricingRule>
            {
                new PricingRule("A", 50, null),
                new PricingRule("B", 30, null)
            };
            var checkout = new Checkout(pricingRules);

            // Act
            checkout.Scan("A");
            checkout.Scan("B");
            int totalPrice = checkout.GetTotalPrice();

            // Assert
            Assert.AreEqual(80, totalPrice);
        }

        [Test]
        public void GetTotalPrice_ItemsWithSpecialPrice_ReturnsCorrectPrice()
        {
            // Arrange
            var pricingRules = new List<PricingRule>
            {
                new PricingRule("A", 50, new SpecialPrice(3, 130)),
                new PricingRule("B", 30, new SpecialPrice(2, 45))
            };
            var checkout = new Checkout(pricingRules);

            // Act
            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("B");
            checkout.Scan("B");
            int totalPrice = checkout.GetTotalPrice();

            // Assert
            Assert.AreEqual(175, totalPrice);
        }

        [Test]
        public void GetTotalPrice_MixedItemsWithAndPartialOriginalPrice_ReturnsCorrectPrice()
        {
            // Arrange
            var pricingRules = new List<PricingRule>
            {
                new PricingRule("A", 50, new SpecialPrice(3, 130)),
                new PricingRule("B", 30, null),
                new PricingRule("C", 20, null)
            };
            var checkout = new Checkout(pricingRules);

            // Act
            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("B");
            checkout.Scan("A");
            checkout.Scan("C");
            checkout.Scan("A");
            checkout.Scan("A");
            int totalPrice = checkout.GetTotalPrice();

            // Assert
            Assert.AreEqual(280, totalPrice);
        }

        [Test]
        public void GetTotalPrice_ItemWithoutPricingRule_ThrowsNullReferenceException()
        {
            // Arrange
            var pricingRules = new List<PricingRule>
            {
                new PricingRule("A", 50, null)
            };
            var checkout = new Checkout(pricingRules);

            // Act
            checkout.Scan("B");

            // Assert
            Assert.Throws<NullReferenceException>(() => checkout.GetTotalPrice());
        }
    }
}
