using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Poker.Tests
{
    [TestClass]
    public class PokerHandsCheckerTests
    {
        //// TODO - implement the method IsHighCard is not implemented
        // [TestMethod]
        // public void TestHighCard()
        //{
        //    Hand hand = new Hand(
        //        new Card(CardFace.Jack, CardSuit.Diamonds),
        //        new Card(CardFace.Queen, CardSuit.Hearts),
        //        new Card(CardFace.Four, CardSuit.Spades),
        //        new Card(CardFace.Seven, CardSuit.Clubs),
        //        new Card(CardFace.Ace, CardSuit.Spades)
        //        );
            
        //    PokerHandsChecker checker = new PokerHandsChecker();
        //    bool expected = true;
        //    bool actual = checker.IsHighCard(hand); ;

        //    Assert.AreEqual(expected, actual);
        //}

        [TestMethod]
        public void TestIsValidHand()
        {
            Hand hand = new Hand(
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Spades)
            );

            PokerHandsChecker checker = new PokerHandsChecker();
            bool expected = true;
            bool actual = checker.IsValidHand(hand);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestNullHand()
        {
            Hand hand = null;

            PokerHandsChecker checker = new PokerHandsChecker();
            bool expected = false;
            bool actual = checker.IsValidHand(hand);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestInvalidCardsCount()
        {
            Hand hand = new Hand(
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Spades)
            );

            PokerHandsChecker checker = new PokerHandsChecker();
            bool expected = false;
            bool actual = checker.IsValidHand(hand);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestRepeatingCard()
        {
            Hand hand = new Hand(
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Clubs)
            );

            PokerHandsChecker checker = new PokerHandsChecker();
            bool expected = false;
            bool actual = checker.IsValidHand(hand);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestValidFlush()
        {
            Hand hand = new Hand(
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.Eight, CardSuit.Hearts)
            );

            PokerHandsChecker checker = new PokerHandsChecker();
            bool expected = true;
            bool actual = checker.IsFlush(hand);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestValidFourOfAKindDifferentCardAtPosition1()
        {
            Hand hand = new Hand(
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Spades)
            );

            PokerHandsChecker checker = new PokerHandsChecker();
            bool expected = true;
            bool actual = checker.IsFourOfAKind(hand);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestValidFourOfAKindDifferentCardAtPosition2()
        {
            Hand hand = new Hand(
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Spades)
            );

            PokerHandsChecker checker = new PokerHandsChecker();
            bool expected = true;
            bool actual = checker.IsFourOfAKind(hand);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestValidFourOfAKindDifferentCardAtPosition5()
        {
            Hand hand = new Hand(
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Hearts)
            );

            PokerHandsChecker checker = new PokerHandsChecker();
            bool expected = true;
            bool actual = checker.IsFourOfAKind(hand);

            Assert.AreEqual(expected, actual);
        }
    }
}
