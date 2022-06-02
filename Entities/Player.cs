
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

        public void AddPoints(int pointsToAdd)
        {
            this.Points += pointsToAdd;
        }

        public void ClearPoints()
        {
            this.Points = 0;
        }
    }
}
