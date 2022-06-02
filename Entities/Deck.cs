using System;
using System.Collections.Generic;
using CardGameManager.Enums;

namespace CardGameManager.Entities
{
    public class Deck
    {
        private List<Card> _cards = new List<Card>();
        public List<Card> Cards
        {
            get
            {
                return this._cards;
            }
            set
            {
                if (this._cards != value)
                    this._cards = value;
            }
        }

        public bool IsEmpty
        {
            get
            {
                if (this._cards.Count > 0)
                    return false;
                else
                    return true;
            }
        }

        public Deck()
        {            
            this.Shuffle();
        }

        public void Draw()
        {
            throw new NotImplementedException();
        }


        public void SortBy(Ranks rank)
        {
            throw new NotImplementedException();
        }
        public void SortBy(Suits suit)
        {
            throw new NotImplementedException();
        }

        private void Shuffle()
        {       
            throw new NotImplementedException();
        }
    }
}
