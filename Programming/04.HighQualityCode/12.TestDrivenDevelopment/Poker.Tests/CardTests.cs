using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Poker.Tests
{
    [TestClass]
    public class CardTests
    {
        [TestMethod]
        public void TestToStringAceSpades()
        {
            Card card = new Card(CardFace.Ace, CardSuit.Spades);
            string expected = "A♠";
            string actual = card.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestToStringTenDiamonds()
        {
            Card card = new Card(CardFace.Ten, CardSuit.Diamonds);
            string expected = "10♦";
            string actual = card.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestToStringTwoClubs()
        {
            Card card = new Card(CardFace.Two, CardSuit.Clubs);
            string expected = "2♣";
            string actual = card.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestToStringJackHearts()
        {
            Card card = new Card(CardFace.Jack, CardSuit.Hearts);
            string expected = "J♥";
            string actual = card.ToString();

            Assert.AreEqual(expected, actual);
        }
    }
}
