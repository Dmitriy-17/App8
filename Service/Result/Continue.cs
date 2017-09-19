using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Result
{
    class Continue : Initializator
    {
        public override CommandtGame CommandGame
        {
            get
            {
                return CommandtGame.Continue;
            }
        }
        
        public override GameInformation ResultInitializator(Player player, Diller diller, int bet = 0)
        {
            player.Bet = 0;
            player.Coins.Clear();
            player.Cards.Clear();
            
            return new GameInformation(diller = null, player, StatusGame.StartGame);
        }
    }
}
