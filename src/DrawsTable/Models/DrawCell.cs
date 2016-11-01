using System.Collections.Generic;

namespace DrawsTable.Models
{
    internal class DrawCell
    {
        private DrawCellType _style;
        private int? matchNumber;

        public DrawCell(DrawCellType style)
        {
            _style = style;
        }

        public DrawCellType Style
        {
            get
            {
                return _style;
            }

            set
            {
                _style = value;
            }
        }

        public int? MatchNumber
        {
            get
            {
                return matchNumber;
            }

            set
            {
                matchNumber = value;
            }
        }
    }
}