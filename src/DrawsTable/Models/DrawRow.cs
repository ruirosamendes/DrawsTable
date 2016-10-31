
namespace DrawsTable.Models
{
    internal class DrawRow
    {
        private DrawCell[] _cells;

        private void EmptyRow(int totalCells)
        {
            _cells = new DrawCell[totalCells];
            for (int i = 0; i < totalCells; i++)
            {
                _cells[i] = new DrawCell(DrawCellType.None);
            }
        }

        public DrawRow(int totalCells)
        {
            EmptyRow(totalCells);
        }       

        public DrawCell[] Cells
        {
            get
            {
                return _cells;
            }

            set
            {
                _cells = value;
            }
        }
    }
}