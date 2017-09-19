using Service.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class GameManager
    {
        private Player _player = new Player();
        private Diller _diller = new Diller();
   
        private List<Initializator> _commandList = new List<Initializator>
        {
            new StartGame(), new Continue(), new Deal(), new DoubleDown(), new Hit(), new Stand()
        };

        public GameInformation GetGameInformation(CommandtGame commandGame, int bet = 0)
        {
            var StartGae = new StartGame();
            Initializator command = _commandList.Find((commandSearch) => commandSearch.CommandGame == commandGame);
            if (commandGame == CommandtGame.Deal)
            {
                return command.ResultInitializator(_player, _diller, bet);
            }
            return command.ResultInitializator(_player, _diller);
        }
   
        public int MaxBet()
        {
            return _player.Balance;
        }


    }
}
