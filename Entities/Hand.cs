using System.Collections.Generic;

namespace CardGameManager.Entities
{
    public class Hand
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

        public Hand()
        { 
        }
    }
}
