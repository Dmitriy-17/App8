using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Service
{
    internal static class CardDeck
    {
        static private List<Card> _cardList = Helper.InitializationCardDeck();

        static public List<Card> GetAll()
        {
            return _cardList;
        }
        static public Card GetCard()
        {
            Thread.Sleep(30);
            Random rand = new Random();
            int numberCurd;
            numberCurd = rand.Next(1, 52);
            return _cardList[numberCurd];
        }
    }
}
