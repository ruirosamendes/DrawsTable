
using DrawsTable.Models;
using System.Linq;

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
            Assert.Equal(7, draw.Columns.Count);
            Assert.Equal(14, draw.Rows.Count);
            Assert.Equal(3, draw.TotalLevels);
        }

        [Fact]
        private void SetupLayoutMustSetLevel3MatchsForATotalOf8Players()
        {
            // Create new DataTable.
            DrawTable draw = new DrawTable(8);
            draw.SetupLayout();

            Assert.Equal(DrawStyle.Match, draw.Rows[1].Cells[1].Style);
            Assert.Equal(DrawStyle.Match, draw.Rows[2].Cells[1].Style);
            Assert.Equal(DrawStyle.None, draw.Rows[3].Cells[1].Style);
            Assert.Equal(DrawStyle.None, draw.Rows[4].Cells[1].Style);
            Assert.Equal(DrawStyle.Match, draw.Rows[5].Cells[1].Style);
            Assert.Equal(DrawStyle.Match, draw.Rows[6].Cells[1].Style);
            Assert.Equal(DrawStyle.None, draw.Rows[7].Cells[1].Style);
            Assert.Equal(DrawStyle.None, draw.Rows[8].Cells[1].Style);
            Assert.Equal(DrawStyle.Match, draw.Rows[9].Cells[1].Style);
            Assert.Equal(DrawStyle.Match, draw.Rows[10].Cells[1].Style);
            Assert.Equal(DrawStyle.None, draw.Rows[11].Cells[1].Style);
            Assert.Equal(DrawStyle.None, draw.Rows[12].Cells[1].Style);
            Assert.Equal(DrawStyle.Match, draw.Rows[13].Cells[1].Style);
            Assert.Equal(DrawStyle.Match, draw.Rows[14].Cells[1].Style);
        }

        [Fact]
        private void SetupLayoutMustSetLevel2MatchsForATotalOf8Players()
        {
            // Create new DataTable.
            DrawTable draw = new DrawTable(8);
            draw.SetupLayout();

            Assert.Equal(DrawStyle.None, draw.Rows[1].Cells[4].Style);
            Assert.Equal(DrawStyle.None, draw.Rows[2].Cells[4].Style);
            Assert.Equal(DrawStyle.Match, draw.Rows[3].Cells[4].Style);
            Assert.Equal(DrawStyle.Match, draw.Rows[4].Cells[4].Style);
            Assert.Equal(DrawStyle.None, draw.Rows[5].Cells[4].Style);
            Assert.Equal(DrawStyle.None, draw.Rows[6].Cells[4].Style);
            Assert.Equal(DrawStyle.None, draw.Rows[7].Cells[4].Style);
            Assert.Equal(DrawStyle.None, draw.Rows[8].Cells[4].Style);
            Assert.Equal(DrawStyle.None, draw.Rows[9].Cells[4].Style);
            Assert.Equal(DrawStyle.None, draw.Rows[10].Cells[4].Style);
            Assert.Equal(DrawStyle.Match, draw.Rows[11].Cells[4].Style);
            Assert.Equal(DrawStyle.Match, draw.Rows[12].Cells[4].Style);
            Assert.Equal(DrawStyle.None, draw.Rows[13].Cells[4].Style);
            Assert.Equal(DrawStyle.None, draw.Rows[14].Cells[4].Style);
        }
    

    }
}
