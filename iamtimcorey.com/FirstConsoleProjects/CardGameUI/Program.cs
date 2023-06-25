using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.ReadLine();
        }
    }

    public abstract class Deck
    {
        private List<PlayingCard> fullDeck = new List<PlayingCard>();
        private List<PlayingCard> drawPile = new List<PlayingCard>();
        private List<PlayingCard> discardPile = new List<PlayingCard>();

        public void CreateDeck()
        {

        }

        public virtual void ShuffleDeck()
        {

        }

        public abstract List<PlayingCard> DealCard();

        public virtual PlayingCard RequestCard()
        {

        }
    }

    public class PlayingCard
    {
        public CardSuit Suit { get; set; }
        public CardValue Value { get; set; }
    }

    public enum CardSuit
    {
        Hearts,
        Clubs,
        Diamonds,
        Spades
    }

    public enum CardValue
    {
        Ace,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Jack,
        Queen,
        King
    }
}
