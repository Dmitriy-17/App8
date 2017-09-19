using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Result
{
    class StartGame : Initializator
    {
        public override CommandtGame CommandGame
        {
            get
            {
                return CommandtGame.StartGame;
            }
        }


        public override GameInformation ResultInitializator(Player player, Diller diller, int bet = 0)
        {
            player.Balance = 1000;
            return new GameInformation(diller = null, player, StatusGame.StartGame);
        }
    }
}
