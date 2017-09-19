using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Result
{
    class Stand : Initializator
    {
        public override CommandtGame CommandGame
        {
            get
            {
                return CommandtGame.Stand;
            }
        }
       
        public override GameInformation ResultInitializator(Player player, Diller diller, int bet = 0)
        {
            diller.GetSumCadrs();
            while (diller.Coins.Min() < 17)
            {
                diller.Cards.Add(CardDeck.GetCard());
                diller.GetSumCadrs();
            }
            if (diller.Coins.Min() > 21)
            {
                player.Balance += Convert.ToInt32(player.Bet * 1.5);
                return new GameInformation(diller, player, StatusGame.Win);
            }
            else if (player.Coins.Exists(x => x == 21) && diller.Coins.Exists(x => x == 21))
            {
                return new GameInformation(diller, player, StatusGame.Draw);
            }
            else if ((player.Coins.Exists(x => x == 21)))
            {
                player.Balance += Convert.ToInt32(player.Bet * 1.5);

                return new GameInformation(diller, player, StatusGame.Win);
            }
            if ((player.Coins.Where(x => x < 21).Max() > diller.Coins.Where(x => x < 21).Max()))
            {
                player.Balance += Convert.ToInt32(player.Bet * 1.5);

                return new GameInformation(diller, player, StatusGame.Win);
            }
            if ((player.Coins.Where(x => x < 21).Max() == diller.Coins.Where(x => x < 21).Max()))
            {

                return new GameInformation(diller, player, StatusGame.Draw);
            }
            else
            {
                player.Balance -= player.Bet;
                if (player.Balance == 0)
                {
                    return new GameInformation(diller, player, StatusGame.GameOver);
                }
                return new GameInformation(diller, player, StatusGame.Losing);
            }
        }
    }
}
