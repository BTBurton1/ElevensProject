namespace ElevensProject.Models
{
    public class Card
    {
        public string Rank { get; }
        public string Suit { get; }
        public int PointValue { get; }

        public Card(string rank, string suit, int pointValue)
        {
            Rank = rank;
            Suit = suit;
            PointValue = pointValue;
        }

        public override string ToString()
        {
            return $"{Rank} of {Suit} (value {PointValue})";
        }
    }
}
