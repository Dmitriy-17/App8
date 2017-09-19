using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class Player : Diller
    {
        public int Balance { get; set; }
        public List<int> AvailableBets { get; set; }

    }
}
