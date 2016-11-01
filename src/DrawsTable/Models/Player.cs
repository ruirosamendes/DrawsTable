using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrawsTable.Models
{
    internal class Player :  Opponent
    {

        public Player(string name, string team) : base(name, team)
        {
        }

        public Player(int rank, string name, string team) : base (rank, name, team)
        {

        }
    }
}
