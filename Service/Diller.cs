using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class Diller
    {
        const int blacJack = 21;
        public Diller()
        {
            Cards = new List<Card>();
        }
        public int Bet { get; set; }
        public List<Card> Cards { get; set; }
        public List<int> Coins { get; set; }
        public void GetSumCadrs()
        {
            List<int> result = new List<int>();
            result.Add(Cards.Sum(x => x.ValueCard));
            if (Cards.Exists(x => x.ImageCard == ImageCard.A))
            {
                result.Add((Cards.Sum(x => x.ValueCard)) + 10);
            }
            Coins = result;
        }
    }
}
