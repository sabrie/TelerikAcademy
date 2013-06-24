using System;
using System.Linq;

namespace Poker
{
    public class PokerHandsChecker : IPokerHandsChecker
    {
        private void ValidExceptionHelper(IHand hand)
        {
            if (!IsValidHand(hand))
            {
                throw new ArgumentException("Hand is not valid!");
            }
        }

        public bool IsValidHand(IHand hand)
        {
            if (hand == null)
            {
                throw new ArgumentNullException("hand");
            }

            if (hand.Cards.Count != 5)
            {
                return false;
            }

            for (int i = 0; i < hand.Cards.Count; i++)
            {
                for (int j = i + 1; j < hand.Cards.Count; j++)
                {
                    if (hand.Cards[i].Equals(hand.Cards[j]))
                    {
                        return false;
                    }
                }
            }

            return true;

            // the same as the above code (excluding the exception)
            // return hand.Cards.Distinct().Count() == 5;
        }

        public bool IsStraightFlush(IHand hand)
        {
            return IsFlush(hand) && IsStraight(hand);
        }

        public bool IsFourOfAKind(IHand hand)
        {
            ValidExceptionHelper(hand);
                                  
            return hand.Cards
                        .Select(card => card.Face)
                        .GroupBy(card => card) 
                        .Any(group => group.Count() == 4);
        }

        public bool IsFullHouse(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsFlush(IHand hand)
        {
            if (!IsValidHand(hand))
            {
                throw new ArgumentException("Hand is not valid!");
            }

            for (int i = 1; i < hand.Cards.Count; i++)
            {
                if (hand.Cards[0].Suit != hand.Cards[i].Suit)
                {
                    return false;
                }
            }

            return true;

            // the same as the above code (excluding the exception)
            // return hand.Cards.Select(card => card.Suit).Distinct().Count() == 1;
        }

        public bool IsStraight(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsTwoPair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsOnePair(IHand hand)
        {
            throw new NotImplementedException();
        }

        // TODO - implement the method
        public bool IsHighCard(IHand hand)
        {
            throw new NotImplementedException();

            // int[] facesCount = CalcFacesCounts(hand);
            // int[] suitsCounts = CalcSuitsCounts(hand);

            // bool isHighCard = ...;

            // return isHighCard;            
        }

        private int[] CalcSuitsCounts(IHand hand)
        {
            int length = (int)CardSuit.Spades + 1;
            int[] suitCounts = new int[length];
            foreach (var card in hand.Cards)
            {
                int suitNum = (int)card.Suit;
                suitCounts[suitNum]++;
            }

            return suitCounts;
        }

        private int[] CalcFacesCounts(IHand hand)
        {
            int length = (int)CardFace.Ace + 1;
            int[] facesCounts = new int[length];
            foreach (var card in hand.Cards)
            {
                int faceNum = (int)card.Face;
                facesCounts[faceNum]++;
            }

            return facesCounts;
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            throw new NotImplementedException();
        }
    }
}
