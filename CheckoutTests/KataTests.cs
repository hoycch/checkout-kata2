using SupermarketCheckout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutTests
{
    [TestFixture]
    public class KataTests
    {
        private Checkout co;
        private readonly List<PricingRule> RULES = new List<PricingRule>()
        {
            new PricingRule("A", 50,new SpecialPrice(3, 130)),
            new PricingRule("B", 30, new SpecialPrice(2, 45)),
            new PricingRule("C", 20),
            new PricingRule("D", 15),
        };

        [SetUp]
        public void Setup()
        {
            co = new Checkout(RULES);
        }
        private int Price(string goods)
        {
            foreach (char item in goods)
            {
                co.Scan(item.ToString());
            }
            return co.GetTotalPrice();
        }

        public void TestTotals()
        {
            Assert.That(Price(""), Is.EqualTo(0));
            Assert.That(Price("A"), Is.EqualTo(50));
            Assert.That(Price("AB"), Is.EqualTo(80));
            Assert.That(Price("CDBA"), Is.EqualTo(115));
            Assert.That(Price("AA"), Is.EqualTo(100));
            Assert.That(Price("AAA"), Is.EqualTo(130));
            Assert.That(Price("AAAA"), Is.EqualTo(180));
            Assert.That(Price("AAAAA"), Is.EqualTo(230));
            Assert.That(Price("AAAAAA"), Is.EqualTo(260));
            Assert.That(Price("AAAB"), Is.EqualTo(160));
            Assert.That(Price("AAABB"), Is.EqualTo(175));
            Assert.That(Price("AAABBD"), Is.EqualTo(190));
            Assert.That(Price("DABABA"), Is.EqualTo(190));
        }
        [Test]
        public void TestIncremental()
        {
            Assert.That(co.GetTotalPrice(), Is.EqualTo(0));
            co.Scan("A"); 
            Assert.That(co.GetTotalPrice(), Is.EqualTo(50));
            co.Scan("B"); 
            Assert.That(co.GetTotalPrice(), Is.EqualTo(80));
            co.Scan("A"); 
            Assert.That(co.GetTotalPrice(), Is.EqualTo(130));
            co.Scan("A"); 
            Assert.That(co.GetTotalPrice(), Is.EqualTo(160));
            co.Scan("B"); 
            Assert.That(co.GetTotalPrice(), Is.EqualTo(175));
        }
    }
}
