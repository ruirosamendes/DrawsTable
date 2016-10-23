
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

    }
}
