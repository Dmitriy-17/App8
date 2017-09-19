using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Result
{
    abstract class Initializator
    {
        public abstract CommandtGame CommandGame { get; }
        public abstract GameInformation ResultInitializator(Player player, Diller diller, int bet = 0);
    }
}
