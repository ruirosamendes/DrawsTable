
using DrawsTable.Models;
using Xunit;

namespace DrawsTable.Tests
{
    public class DrawTableTests
    {

        [Fact]
        private void ContructorCreateDataTable()
        {
            // Create new DataTable.
            DrawTable draw = new DrawTable(8);

            Assert.Equal(8, draw.TotalPlayers);
            Assert.Equal(7, draw.Columns.Length);
            Assert.Equal(14, draw.Rows.Length);
            Assert.Equal(3, draw.TotalLevels);
        }

        [Fact]
        private void ContructorSetupLayoutMustSetLevel1MatchsForATotalOf8Players()
        {
            // Create new DataTable.
            DrawTable draw = new DrawTable(8);

            Assert.Equal(DrawCellType.FirstPlayer, draw.Rows[0].Cells[0].Style);
            Assert.Equal(DrawCellType.SecondPlayer, draw.Rows[1].Cells[0].Style);
            Assert.Equal(DrawCellType.None, draw.Rows[2].Cells[0].Style);
            Assert.Equal(DrawCellType.None, draw.Rows[3].Cells[0].Style);
            Assert.Equal(DrawCellType.FirstPlayer, draw.Rows[4].Cells[0].Style);
            Assert.Equal(DrawCellType.SecondPlayer, draw.Rows[5].Cells[0].Style);
            Assert.Equal(DrawCellType.None, draw.Rows[6].Cells[0].Style);
            Assert.Equal(DrawCellType.None, draw.Rows[7].Cells[0].Style);
            Assert.Equal(DrawCellType.FirstPlayer, draw.Rows[8].Cells[0].Style);
            Assert.Equal(DrawCellType.SecondPlayer, draw.Rows[9].Cells[0].Style);
            Assert.Equal(DrawCellType.None, draw.Rows[10].Cells[0].Style);
            Assert.Equal(DrawCellType.None, draw.Rows[11].Cells[0].Style);
            Assert.Equal(DrawCellType.FirstPlayer, draw.Rows[12].Cells[0].Style);
            Assert.Equal(DrawCellType.SecondPlayer, draw.Rows[13].Cells[0].Style);
        }

        [Fact]
        private void ContructorSetupLayoutMustSetLevel2MatchsForATotalOf8Players()
        {
            // Create new DataTable.
            DrawTable draw = new DrawTable(8);

            Assert.Equal(DrawCellType.None, draw.Rows[0].Cells[3].Style);
            Assert.Equal(DrawCellType.None, draw.Rows[1].Cells[3].Style);
            Assert.Equal(DrawCellType.FirstPlayer, draw.Rows[2].Cells[3].Style);
            Assert.Equal(DrawCellType.SecondPlayer, draw.Rows[3].Cells[3].Style);
            Assert.Equal(DrawCellType.None, draw.Rows[4].Cells[3].Style);
            Assert.Equal(DrawCellType.None, draw.Rows[5].Cells[3].Style);
            Assert.Equal(DrawCellType.None, draw.Rows[6].Cells[3].Style);
            Assert.Equal(DrawCellType.None, draw.Rows[7].Cells[3].Style);
            Assert.Equal(DrawCellType.None, draw.Rows[8].Cells[3].Style);
            Assert.Equal(DrawCellType.None, draw.Rows[9].Cells[3].Style);
            Assert.Equal(DrawCellType.FirstPlayer, draw.Rows[10].Cells[3].Style);
            Assert.Equal(DrawCellType.SecondPlayer, draw.Rows[11].Cells[3].Style);
            Assert.Equal(DrawCellType.None, draw.Rows[12].Cells[3].Style);
            Assert.Equal(DrawCellType.None, draw.Rows[13].Cells[3].Style);
        }


        [Fact]
        private void ContructorSetupLayoutMustSetLevel3MatchsForATotalOf8Players()
        {
            // Create new DataTable.
            DrawTable draw = new DrawTable(8);

            Assert.Equal(DrawCellType.None, draw.Rows[0].Cells[6].Style);
            Assert.Equal(DrawCellType.None, draw.Rows[1].Cells[6].Style);
            Assert.Equal(DrawCellType.None, draw.Rows[2].Cells[6].Style);
            Assert.Equal(DrawCellType.None, draw.Rows[3].Cells[6].Style);
            Assert.Equal(DrawCellType.None, draw.Rows[4].Cells[6].Style);
            Assert.Equal(DrawCellType.None, draw.Rows[5].Cells[6].Style);
            Assert.Equal(DrawCellType.FirstPlayer, draw.Rows[6].Cells[6].Style);
            Assert.Equal(DrawCellType.SecondPlayer, draw.Rows[7].Cells[6].Style);
            Assert.Equal(DrawCellType.None, draw.Rows[8].Cells[6].Style);
            Assert.Equal(DrawCellType.None, draw.Rows[9].Cells[6].Style);
            Assert.Equal(DrawCellType.None, draw.Rows[10].Cells[6].Style);
            Assert.Equal(DrawCellType.None, draw.Rows[11].Cells[6].Style);
            Assert.Equal(DrawCellType.None, draw.Rows[12].Cells[6].Style);
            Assert.Equal(DrawCellType.None, draw.Rows[13].Cells[6].Style);
        }



        [Fact]
        private void ContructorSetupLayoutMustSetConnectionsBetweenLevel1AndLevel2ForATotalOf8Players()
        {
            // Create new DataTable.
            DrawTable draw = new DrawTable(8);

            Assert.Equal(DrawCellType.None, draw.Rows[0].Cells[1].Style);
            Assert.Equal(DrawCellType.OddCornerConnector, draw.Rows[1].Cells[1].Style);
            Assert.Equal(DrawCellType.VerticalConnector, draw.Rows[2].Cells[1].Style);

            Assert.Equal(DrawCellType.HorizontalConnector, draw.Rows[2].Cells[2].Style);

            Assert.Equal(DrawCellType.VerticalConnector, draw.Rows[3].Cells[1].Style);
            Assert.Equal(DrawCellType.EvenCornerConnector, draw.Rows[4].Cells[1].Style);
            Assert.Equal(DrawCellType.None, draw.Rows[5].Cells[1].Style);
            Assert.Equal(DrawCellType.None, draw.Rows[6].Cells[1].Style);
            Assert.Equal(DrawCellType.None, draw.Rows[7].Cells[1].Style);
            Assert.Equal(DrawCellType.None, draw.Rows[8].Cells[1].Style);
            Assert.Equal(DrawCellType.OddCornerConnector, draw.Rows[9].Cells[1].Style);
            Assert.Equal(DrawCellType.VerticalConnector, draw.Rows[10].Cells[1].Style);

            Assert.Equal(DrawCellType.HorizontalConnector, draw.Rows[10].Cells[2].Style);

            Assert.Equal(DrawCellType.VerticalConnector, draw.Rows[11].Cells[1].Style);
            Assert.Equal(DrawCellType.EvenCornerConnector, draw.Rows[12].Cells[1].Style);
            Assert.Equal(DrawCellType.None, draw.Rows[13].Cells[1].Style);

            

        }

        [Fact]
        private void ContructorSetupLayoutMustSetConnectionsBetweenLevel2AndLevel3ForATotalOf8Players()
        {
            // Create new DataTable.
            DrawTable draw = new DrawTable(8);

            Assert.Equal(DrawCellType.None, draw.Rows[0].Cells[4].Style);
            Assert.Equal(DrawCellType.None, draw.Rows[1].Cells[4].Style);
            Assert.Equal(DrawCellType.None, draw.Rows[2].Cells[4].Style);
            Assert.Equal(DrawCellType.OddCornerConnector, draw.Rows[3].Cells[4].Style);
            Assert.Equal(DrawCellType.VerticalConnector, draw.Rows[4].Cells[4].Style);
            Assert.Equal(DrawCellType.VerticalConnector, draw.Rows[5].Cells[4].Style);
            Assert.Equal(DrawCellType.VerticalConnector, draw.Rows[6].Cells[4].Style);

            Assert.Equal(DrawCellType.HorizontalConnector, draw.Rows[6].Cells[5].Style);

            Assert.Equal(DrawCellType.VerticalConnector, draw.Rows[7].Cells[4].Style);
            Assert.Equal(DrawCellType.VerticalConnector, draw.Rows[8].Cells[4].Style);
            Assert.Equal(DrawCellType.VerticalConnector, draw.Rows[9].Cells[4].Style);
            Assert.Equal(DrawCellType.EvenCornerConnector, draw.Rows[10].Cells[4].Style);
            Assert.Equal(DrawCellType.None, draw.Rows[11].Cells[4].Style);
            Assert.Equal(DrawCellType.None, draw.Rows[12].Cells[4].Style);
            Assert.Equal(DrawCellType.None, draw.Rows[13].Cells[4].Style);
        }

        [Fact]
        private void ContructorSetupColumnsProperties()
        {
            // Create new DataTable.
            DrawTable draw = new DrawTable(8);

            Assert.Equal("Quarter - Finals",  draw.Columns[0].Name);
            Assert.Equal("", draw.Columns[1].Name);
            Assert.Equal("", draw.Columns[2].Name);
            Assert.Equal("Semi - Finals", draw.Columns[3].Name);
            Assert.Equal("", draw.Columns[4].Name);
            Assert.Equal("", draw.Columns[5].Name);
            Assert.Equal("Final", draw.Columns[6].Name);

            Assert.Equal(DrawColumnType.Match, draw.Columns[0].Type);
            Assert.Equal(DrawColumnType.Connector, draw.Columns[1].Type);
            Assert.Equal(DrawColumnType.Connector, draw.Columns[2].Type);
            Assert.Equal(DrawColumnType.Match, draw.Columns[3].Type);
            Assert.Equal(DrawColumnType.Connector, draw.Columns[4].Type);
            Assert.Equal(DrawColumnType.Connector, draw.Columns[5].Type);
            Assert.Equal(DrawColumnType.Match, draw.Columns[6].Type);



        }
    }
}
