
namespace DrawsTable.Models
{
    internal class DrawRow
    {
        private DrawCell[] cells;

        public DrawRow(int totalCells)
        {
            cells = new DrawCell[totalCells];
            for (int i = 0; i < totalCells; i++)
            {
                cells[i] = new DrawCell(DrawCellType.None);
            }
        }

        public DrawCell[] Cells
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