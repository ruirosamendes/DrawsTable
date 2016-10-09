using System.Collections.Generic;

namespace DrawsTable.Models
{
    internal class DrawRow
    {
         private Dictionary<int, DrawCell> cells;

        public DrawRow(int totalCells)
        {
            cells = new Dictionary<int, DrawCell>(totalCells);
            for (int i = 1; i <= totalCells; i++)
            {
                cells.Add(i, new DrawCell(DrawStyle.None));
            }
        }

        internal Dictionary<int, DrawCell> Cells
        {
            get
            {
                return cells;
            }

            set
            {
                cells = value;
            }
        }
    }
}