using CardGameManager.Enums;
using System;

namespace CardGameManager.Entities
{
    public class Card
    {
        private Suits _suit;
        public Suits Suit
        {
            get
            {
                return this._suit;
            }
            set
            {
                if (this._suit != value) 
                    this._suit = value;
            }
        }
        private Ranks _rank;
        public Ranks Rank
        {
            get
            {
                return this._rank;
            }
            set
            {
                if (this._rank != value)
                    this._rank = value;
            }
        }
        public Card(Ranks rank, Suits suit)
        {
            this._rank = rank;
            this._suit = suit;
        }

        public bool IsEqualTo(Ranks rank)
        {
            throw new NotImplementedException();
        }

        public bool IsHigherThan(Ranks rank)
        {
            throw new NotImplementedException();
        }

        public bool IsLowerThan(Ranks rank)
        {
            throw new NotImplementedException();
        }
    }
}
