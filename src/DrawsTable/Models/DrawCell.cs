﻿using System.Collections.Generic;

namespace DrawsTable.Models
{
    internal class DrawCell
    {
        private DrawStyle _style;

        public DrawCell(DrawStyle style)
        {
            _style = style;
        }

        public DrawStyle Style
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