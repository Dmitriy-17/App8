using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class GameInformation
    {
        private Diller _diller;
        private Player _player;
        private StatusGame _statusGame;


        public GameInformation(Diller diller, Player player, StatusGame statusGame)
        {
            _diller = diller;
            _player = player;
            _statusGame = statusGame;
        }
        public Diller Diller
        {
            get { return _diller; }
            private set { _diller = value; }
        }

        public Player Player
        {
            get { return _player; }
            private set { _player = value; }
        }
        public StatusGame StatusGame
        {
            get { return _statusGame; }
            private set { _statusGame = value; }
        }

    }
}
