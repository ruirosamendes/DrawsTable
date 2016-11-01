using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrawsTable.Models
{
    internal class Opponent: IOpponent
    {
        private readonly string _name;
        private readonly string _team;
        private int _rank;

        public Opponent(string name, string team)
        {
            _name = name;
            _team = team;
        }
        
        public Opponent(int rank, string name, string team) : this (name, team)
        {
            _rank = rank;
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public int Rank
        {
            get
            {
                return _rank;
            }
        }

        public string Team
        {
            get
            {
                return _team;
            }
        }
    }
}
