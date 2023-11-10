namespace BlackJack1
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Linq;

    public enum Suit { Hearts, Diamonds, Clubs, Spades }
    public enum Rank { Two = 2, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace }

    public class Card
    {
        public Suit Suit { get; private set; }
        public Rank Rank { get; private set; }

        public Card(Suit s, Rank r)
        {
            Suit = s;
            Rank = r;
        }

        public int GetValue()
        {
            if ((int)Rank <= 10)
            {
                return (int)Rank;
            }
            else if ((int)Rank <= 13)
            {
                return 10;
            }
            else
            {
                return 11;
            }
        }

        public override string ToString()
        {
            return $"{Rank} of {Suit}";
        }
    }

    public class Deck
    {
        private List<Card> cards;

        public Deck()
        {
            cards = new List<Card>();

            foreach (Suit s in Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank r in Enum.GetValues(typeof(Rank)))
                {
                    cards.Add(new Card(s, r));
                }
            }

            Shuffle();
        }

        public void Shuffle()
        {
            Random rand = new Random();

            for (int i = 0; i < cards.Count; i++)
            {
                int j = rand.Next(i, cards.Count);
                Card temp = cards[i];
                cards[i] = cards[j];
                cards[j] = temp;
            }
        }

        public Card DrawCard()
        {
            Card card = cards[0];
            cards.RemoveAt(0);
            return card;
        }
    }

    public class Hand
    {
        public List<Card> cards;

        public Hand()
        {
            cards = new List<Card>();
        }
        
    public void AddCard(Card card)
        {
            cards.Add(card);
        }

        public int GetTotalValue()
        {
            int total = 0;
            int aceCount = 0;

            foreach (Card card in cards)
            {
                if (card.Rank == Rank.Ace)
                {
                    aceCount++;
                }
                total += card.GetValue();
            }

            while (total > 21 && aceCount > 0)
            {
                total -= 10;
                aceCount--;
            }

            return total;
        }
    }

    public class Player
    {
        public Hand Hand { get; private set; }

        public Player()
        {
            Hand = new Hand();
        }

        public Card DrawCardFromDeck(Deck deck)
        {
            Card drawnCard = deck.DrawCard();
            Hand.AddCard(drawnCard);
            return drawnCard;
        }
        public class Blackjack
        {
           
        }
    }

    public class Dealer : Player
    {
        
    }

    // 블랙잭 게임을 구현하세요. 
    public class Blackjack
    {
        public void PlayGame() {
            Player player = new Player();
            Player dealer = new Dealer();
            Blackjack blackjack = new Blackjack();
            Deck deck = new Deck();
            Hand phand = new Hand();
            Hand dhand = new Hand();
            phand = player.Hand;
            dhand = dealer.Hand;

            Console.WriteLine("블랙잭 시작합니다.");

            Card playerFirstCard = player.DrawCardFromDeck(deck);
            Console.WriteLine("Player First Card Draw");

            Console.ReadLine();

            Card dealerFirstCard = dealer.DrawCardFromDeck(deck);
            Console.WriteLine("Dealer First Card Draw");

            Console.ReadLine();

            Card playerSecondCard = player.DrawCardFromDeck(deck);
            Console.WriteLine("Player Second Card Draw");

            Console.ReadLine();

            Card dealerSecondCard = dealer.DrawCardFromDeck(deck);
            Console.WriteLine("Dealer Second Card Draw");

            Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Dealer Cards");
            Console.ResetColor();
            Console.WriteLine(dealerFirstCard.ToString() + " , ???");
            int dTotal = dhand.GetTotalValue();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Player Cards");
            Console.ResetColor();
            Console.WriteLine(playerFirstCard.ToString() + "  ,  " + playerSecondCard.ToString() + "\n\n");
            int pTotal = phand.GetTotalValue();

            Console.WriteLine($"Dealer : " + dealerFirstCard.ToString() + "  ,  " + dealerSecondCard.ToString() + "\n합 : " + dTotal+"\n");
            Console.WriteLine($"Player : " + playerFirstCard.ToString() + "  ,  " + playerSecondCard.ToString() + "\n합 : " + pTotal);
            Console.ReadLine();

            blackjack.WinCheck(pTotal, dTotal);

            
        }
        public void WinCheck(int pTotal, int dTotal) {
            if (pTotal == 21)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"** Black Jack **\n Player의 승리입니다.\n");
                Console.ResetColor();
            }
            else if (dTotal == 21)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"** Black Jack **\n Dealer의 승리입니다.\n");
                Console.ResetColor();
                
            }
            else if (pTotal > 21 && dTotal > 21||pTotal==dTotal)
            {
                Console.WriteLine($"무승부");
            }
            else if (pTotal > 21)
            {
                Console.WriteLine($"Player의 카드가 21점이 넘었습니다.\nDealer의 승리입니다.\n");
            }
            else if (dTotal > 21)
            {
                Console.WriteLine($"Dealer의 카드가 21점이 넘었습니다.\nPlayer의 승리입니다.\n");
            }
            else if (pTotal > dTotal)
            {
                Console.WriteLine($"Player의 승리입니다.\n");
            }
            else if (dTotal > pTotal)
            {
                Console.WriteLine($"Dealer의 승리입니다.\n");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Blackjack blackjack = new Blackjack();
            blackjack.PlayGame();
            Console.ReadLine();
        }
    }
}