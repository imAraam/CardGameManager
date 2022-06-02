using CardGameManager.Enums;
using System.Linq;

namespace CardGameManager.Entities
{
    public class Player
    {
        private Hand _hand = new Hand();
        public Hand Hand
        {
            get
            {
                return this._hand;
            }
            set
            {
                if (this._hand != value)
                    this._hand = value;
            }
        }

        private int _points = 0;
        public int Points
        { 
            get
            {
                return this._points;
            }
            set
            {
                if (this._points != value)
                    this._points = value;
            }
        }

        public Player()
        {
        }

        public void TakeMatchingCards(Player playerGiving, Player playerReceiving, Ranks requestedRank)
        {
            var matchingCards = playerGiving.Hand.Cards.Where(c => c.Rank == requestedRank).ToList();
            if (matchingCards != null && matchingCards.Count > 0)
                foreach (var card in matchingCards)
                {
                    playerReceiving.Hand.Cards.Add(card);
                    playerGiving.Hand.Cards.Remove(card);
                }
        }

        public bool AskForRank(Player playerRequested, Ranks requestedRank)
        {
            return playerRequested.Hand.Cards.Any(c => c.Rank == requestedRank);
        }

        public bool HasFourOrMoreDuplicates()
        {
            return this.Hand.Cards.GroupBy(x => x.Rank).Any(g => g.Count() > 3);
        }

        public void PlaceDownDuplicates(int duplicateThreshold = 2)
        {
            var cardsToRemove = (from Card c in this.Hand.Cards
                                 group c by c.Rank into g
                                 where g.Count() > duplicateThreshold
                                 select g);

            if (cardsToRemove.Count() > 0)
                foreach (var card in cardsToRemove.SelectMany(group => group).ToList())
                    this.Hand.Cards.Remove(card);
        }

        public void AddPoints(int pointsToAdd)
        {
            this.Points += pointsToAdd;
        }

        public void ClearPoints()
        {
            this.Points = 0;
        }

        public bool IsLastCardDrawnGoFish(Ranks goFishRank)
        {
            var lastCardIndex = this.Hand.Cards.Count - 1;
            if (lastCardIndex > -1 &&
                this.Hand.Cards[lastCardIndex].Rank == goFishRank)
                return true;
            else return false;
        }
    }
}
