using System.Collections.Generic;

namespace DrawsTable.Models
{
    internal class DrawCell
    {
        private DrawCellType _style;

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

    }
}