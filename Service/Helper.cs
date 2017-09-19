using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal static class Helper
    {

        static private Dictionary<ImageCard, int> _image = new Dictionary<ImageCard, int>
    {
        { ImageCard.A, 1 },
        { ImageCard.Two, 2 },
        { ImageCard.Three, 3 },
        { ImageCard.Four, 4 },
        { ImageCard.Five, 5 },
        { ImageCard.Six, 6 },
        { ImageCard.Seven, 7 },
        { ImageCard.Eight, 8 },
        { ImageCard.Nine, 9 },
        { ImageCard.Ten, 10 },
        { ImageCard.K, 10 },
        { ImageCard.Q, 10 },
        { ImageCard.J, 10 }
    };
 
        public static List<Card> InitializationCardDeck()
        {

            var _cardList = new List<Card>();
            foreach (var suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (var h in _image)
                {
                    var card = new Card()
                    {
                        SuitCard = (Suit)suit,
                        ImageCard = h.Key,
                        ValueCard = h.Value
                    };
                    _cardList.Add(card);
                }
            }
            return _cardList;
        }    
    }
}
