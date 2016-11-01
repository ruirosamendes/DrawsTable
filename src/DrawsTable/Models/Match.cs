namespace DrawsTable.Models
{
    internal class Match
    {

        Set[] _sets;
        private int? _number;
        private readonly IOpponent _opponent1;
        private readonly IOpponent _opponent2;
        private readonly int _bestOfTTotal;

        private void IntiSets()
        {
            _sets = new Set[_bestOfTTotal];
            for (int setIndex = 0; setIndex < _sets.Length; setIndex++)
            {
                _sets[setIndex] = new Set();
            }
        }

        public Match(IOpponent opponent1, IOpponent opponent2, int bestOfTotal)
        {
            _opponent1 = opponent1;
            _opponent2 = opponent2;
            _bestOfTTotal = bestOfTotal;
            IntiSets();
        }

        public int? Number
        {
            get
            {
                return _number;
            }

            set
            {
                _number = value;
            }
        }

        public IOpponent Opponent1
        {
            get
            {
                return _opponent1;
            }
        }

        public IOpponent Opponent2
        {
            get
            {
                return _opponent2;
            }
        }

        public int BestOfTotal
        {
            get
            {
                return _bestOfTTotal;
            }
        }

        public Set[] Sets
        {
            get
            {
                return _sets;
            }
        }
    }
}
