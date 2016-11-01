using System.Collections.Generic;

namespace DrawsTable.Models
{
    internal class Set
    {
        int _games1Total;
        int _games2Total;

        public Set()
        {
            _games1Total = 0;
            _games2Total = 0;
        }

        public int Games1Total
        {
            get
            {
                return _games1Total;
            }

            set
            {
                _games1Total = value;
            }
        }

        public int Games2Total
        {
            get
            {
                return _games2Total;
            }

            set
            {
                _games2Total = value;
            }
        }
    }
}