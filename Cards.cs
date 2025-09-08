public enum Suit { Hearts, Diamonds, Clubs, Spades }

public class Card
{
    public Suit suit;
    public int value;

    public Card(Suit suit, int value)
    {
        this.suit = suit;
        this.value = value;
    }

    public string GetCardName()
    {
        string[] valueNames = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        return $"{valueNames[value - 2]} of {suit}";
    }
}
