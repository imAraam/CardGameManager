using System;
using System.Collections.Generic;
using CardGameManager.Enums;
using System.Linq;

namespace CardGameManager.Entities
{
    public class Deck
    {
        private readonly Random _r = new Random();

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

        public Deck(int numberOfDecks, bool includeJoker)
        {
            foreach (Enums.Suits suit in Enum.GetValues(typeof(Enums.Suits)))
                foreach (Enums.Ranks rank in Enum.GetValues(typeof(Enums.Ranks)))
                {
                    if (!includeJoker && rank == Enums.Ranks.Joker) continue;
                    this._cards.Add(new Card(rank, suit));
                }

            if (numberOfDecks > 1)
            {
                this._cards =
                    (from n in Enumerable.Range(0, numberOfDecks)
                     from c in this._cards
                     select c)
                    .ToList();
            }

            this.Shuffle();
        }

        public void DealTo(Player player, int cardCount)
        {
            for (int i = 0; i < cardCount; i++)
            {
                if (this.IsEmpty) break;

                this.DrawCardToPlayer(player);
            }
        }

        public void Draw(Player drawingPlayer, int cardCount = 1)
        {
            if (this.IsEmpty) return;
            for (int i = 0; i < cardCount; i++)
                this.DrawCardToPlayer(drawingPlayer);
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
        {   //Fisher Yates Shuffle            
            for (int n = this._cards.Count - 1; n > 0; --n)
            {
                int k = this._r.Next(n + 1);
                Card temp = this._cards[n];
                this._cards[n] = this._cards[k];
                this._cards[k] = temp;
            }
        }

        private void DrawCardToPlayer(Player drawingPlayer)
        {
            var lastCardIndex = this._cards.Count - 1;
            var temp = this._cards[lastCardIndex];
            drawingPlayer.Hand.Cards.Add(temp);
            this._cards.RemoveAt(lastCardIndex);
        }
    }
}
