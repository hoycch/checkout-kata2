using NUnit.Framework;
using System.Collections.Generic;
using SupermarketCheckout;

namespace CheckoutTests
{
    [TestFixture]
    public class BasketTests
    {
        [Test]
        public void AddItem_ShouldAddNewItem()
        {
            // Arrange
            Basket basket = new Basket();

            // Act
            basket.AddItem("A");

            // Assert
            Dictionary<string, int> items = basket.GetItems();
            Assert.That(items, Contains.Key("A"));
            Assert.AreEqual(1, items["A"]);
        }

        [Test]
        public void AddItem_ShouldIncrementQuantityForExistingItem()
        {
            // Arrange
            Basket basket = new Basket();
            basket.AddItem("A");

            // Act
            basket.AddItem("A");

            // Assert
            Dictionary<string, int> items = basket.GetItems();
            Assert.AreEqual(2, items["A"]);
        }

        [Test]
        public void RemoveItem_ShouldDecrementQuantityForExistingItem()
        {
            // Arrange
            Basket basket = new Basket();
            basket.AddItem("A");
            basket.AddItem("A");

            // Act
            basket.RemoveItem("A");

            // Assert
            Dictionary<string, int> items = basket.GetItems();
            Assert.AreEqual(1, items["A"]);
        }

        [Test]
        public void RemoveItem_ShouldRemoveItemWhenQuantityIsZero()
        {
            // Arrange
            Basket basket = new Basket();
            basket.AddItem("A");

            // Act
            basket.RemoveItem("A");

            // Assert
            Dictionary<string, int> items = basket.GetItems();
            Assert.IsFalse(items.ContainsKey("A"));
        }

        [Test]
        public void GetQuantity_ShouldReturnQuantityForExistingItem()
        {
            // Arrange
            Basket basket = new Basket();
            basket.AddItem("A");
            basket.AddItem("A");

            // Act
            int quantityOfA = basket.GetQuantity("A");

            // Assert
            Assert.AreEqual(2, quantityOfA);
        }

        [Test]
        public void GetQuantity_ShouldReturnZeroForNonExistingItem()
        {
            // Arrange
            Basket basket = new Basket();

            // Act
            int quantityOfA = basket.GetQuantity("A");

            // Assert
            Assert.AreEqual(0, quantityOfA);
        }
    }
}