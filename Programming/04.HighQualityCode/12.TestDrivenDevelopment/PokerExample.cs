using System;
using System.Collections.Generic;

namespace Poker
{
    class PokerExample
    {
        static void Main()
        {
            ICard card = new Card(CardFace.Ace, CardSuit.Clubs);
            Console.WriteLine(card);

            IHand hand = new Hand(
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Diamonds)
            );
            Console.WriteLine(hand);

            Console.WriteLine(
                new Card(CardFace.Seven, CardSuit.Diamonds).Equals(
                new Card(CardFace.Seven, CardSuit.Diamonds)
            ));

            IPokerHandsChecker checker = new PokerHandsChecker();
            Console.WriteLine(checker.IsFourOfAKind(hand));
            //Console.WriteLine(checker.IsOnePair(hand));
            //Console.WriteLine(checker.IsTwoPair(hand));
        }
    }
}
