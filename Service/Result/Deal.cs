using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Result
{
    class Deal : Initializator
    {
        public override CommandtGame CommandGame
        {
            get
            {
                return CommandtGame.Deal;
            }
        }
        
        public override GameInformation ResultInitializator(Player player, Diller diller, int bet = 0)
        {
            player.Bet = bet;
            if (player.Cards.Count > 0)
            {
                player.Cards.Clear();
            }
            if (diller.Cards.Count > 0)
            {
                diller.Cards.Clear();
            }

            player.Cards.Add(CardDeck.GetCard());
            player.Cards.Add(CardDeck.GetCard());
            player.GetSumCadrs();
            
            diller.Cards.Add(CardDeck.GetCard());
            diller.Cards.Add(CardDeck.GetCard());
            diller.GetSumCadrs();
            if (player.Coins.Exists(x => x == 21) && diller.Coins.Exists(x => x == 21))
            {

                return new GameInformation(diller, player, StatusGame.Draw);
            }
            else
                if ((player.Coins.Exists(x => x == 21)))
            {
                player.Balance += Convert.ToInt32(player.Bet * 1.5);

                return new GameInformation(diller, player, StatusGame.Win);
            }
            if ((diller.Coins.Exists(x => x == 21)))
            {
                player.Balance -= player.Bet;
                if (player.Balance == 0)
                {
                    return new GameInformation(diller, player, StatusGame.GameOver);
                }
                return new GameInformation(diller, player, StatusGame.Win);
            }
            return new GameInformation(diller, player, StatusGame.StartGame);

        }
    }
}
