
namespace DrawsTable.Models
{
    internal enum DrawCellType : int
    {
        None = 0,
        FirstPlayer = 1,
        SecondPlayer = 2,
        OddCornerConnector = 3,
        EvenCornerConnector = 4,
        VerticalConnector = 5,
        HorizontalConnector = 6
    }
}