
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
            Assert.Equal(3, draw.TotalRounds);
        }

        [Fact]
        private void ContructorSetupLayoutMustSetRound1MatchsForATotalOf8Players()
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
        private void ContructorSetupLayoutMustSetRound2MatchsForATotalOf8Players()
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
        private void ContructorSetupLayoutMustSetRound3MatchsForATotalOf8Players()
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
        private void ContructorSetupLayoutMustSetConnectionsBetweenRound1AndRound2ForATotalOf8Players()
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
        private void ContructorSetupLayoutMustSetConnectionsBetweenRound2AndRound3ForATotalOf8Players()
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

        [Fact]
        private void ContructorSetupColumnsPropertiesFor16PlayersMustNotCrash()
        {
            // Create new DataTable.
            DrawTable draw = new DrawTable(16);

            Assert.Equal(16, draw.TotalPlayers);
            Assert.Equal(10, draw.Columns.Length);
            Assert.Equal(30, draw.Rows.Length);
            Assert.Equal(4, draw.TotalRounds);           
        }


        [Fact]
        private void ContructorSetupColumnsPropertiesFor16PlayersMustSetupRound1Column()
        {
            // Create new DataTable.
            DrawTable draw = new DrawTable(16);
            
            Assert.Equal("Round 1", draw.Columns[0].Name);
            Assert.Equal("", draw.Columns[1].Name);
            Assert.Equal("", draw.Columns[2].Name);
            Assert.Equal("Quarter - Finals", draw.Columns[3].Name);
            Assert.Equal("", draw.Columns[4].Name);
            Assert.Equal("", draw.Columns[5].Name);
            Assert.Equal("Semi - Finals", draw.Columns[6].Name);
            Assert.Equal("", draw.Columns[7].Name);
            Assert.Equal("", draw.Columns[8].Name);
            Assert.Equal("Final", draw.Columns[9].Name);

            Assert.Equal(DrawColumnType.Match, draw.Columns[0].Type);
            Assert.Equal(DrawColumnType.Connector, draw.Columns[1].Type);
            Assert.Equal(DrawColumnType.Connector, draw.Columns[2].Type);
            Assert.Equal(DrawColumnType.Match, draw.Columns[3].Type);
            Assert.Equal(DrawColumnType.Connector, draw.Columns[4].Type);
            Assert.Equal(DrawColumnType.Connector, draw.Columns[5].Type);
            Assert.Equal(DrawColumnType.Match, draw.Columns[6].Type);
            Assert.Equal(DrawColumnType.Connector, draw.Columns[7].Type);
            Assert.Equal(DrawColumnType.Connector, draw.Columns[8].Type);
            Assert.Equal(DrawColumnType.Match, draw.Columns[9].Type);

        }
   
        [Fact]
        private void ContructorSetupLayoutFor16Players()
        {
            // Create new DataTable.
            DrawTable draw = new DrawTable(16);

            // Round 1
            Assert.Equal(DrawCellType.FirstPlayer, draw.Rows[0].Cells[0].Style);
            Assert.Equal(DrawCellType.SecondPlayer, draw.Rows[1].Cells[0].Style);
            Assert.Equal(DrawCellType.FirstPlayer, draw.Rows[4].Cells[0].Style);
            Assert.Equal(DrawCellType.SecondPlayer, draw.Rows[5].Cells[0].Style);
            Assert.Equal(DrawCellType.FirstPlayer, draw.Rows[8].Cells[0].Style);
            Assert.Equal(DrawCellType.SecondPlayer, draw.Rows[9].Cells[0].Style);        
            Assert.Equal(DrawCellType.FirstPlayer, draw.Rows[12].Cells[0].Style);
            Assert.Equal(DrawCellType.SecondPlayer, draw.Rows[13].Cells[0].Style);
            Assert.Equal(DrawCellType.FirstPlayer, draw.Rows[16].Cells[0].Style);
            Assert.Equal(DrawCellType.SecondPlayer, draw.Rows[17].Cells[0].Style);
            Assert.Equal(DrawCellType.FirstPlayer, draw.Rows[20].Cells[0].Style);
            Assert.Equal(DrawCellType.SecondPlayer, draw.Rows[21].Cells[0].Style);
            Assert.Equal(DrawCellType.FirstPlayer, draw.Rows[24].Cells[0].Style);
            Assert.Equal(DrawCellType.SecondPlayer, draw.Rows[25].Cells[0].Style);
            Assert.Equal(DrawCellType.FirstPlayer, draw.Rows[28].Cells[0].Style);
            Assert.Equal(DrawCellType.SecondPlayer, draw.Rows[29].Cells[0].Style);
            // Connections Round 1 -> Quarter Finals
            Assert.Equal(DrawCellType.OddCornerConnector, draw.Rows[1].Cells[1].Style);
            Assert.Equal(DrawCellType.VerticalConnector, draw.Rows[2].Cells[1].Style);
            Assert.Equal(DrawCellType.HorizontalConnector, draw.Rows[2].Cells[2].Style);
            Assert.Equal(DrawCellType.VerticalConnector, draw.Rows[3].Cells[1].Style);
            Assert.Equal(DrawCellType.EvenCornerConnector, draw.Rows[4].Cells[1].Style);
            Assert.Equal(DrawCellType.OddCornerConnector, draw.Rows[9].Cells[1].Style);
            Assert.Equal(DrawCellType.VerticalConnector, draw.Rows[10].Cells[1].Style);
            Assert.Equal(DrawCellType.HorizontalConnector, draw.Rows[10].Cells[2].Style);
            Assert.Equal(DrawCellType.VerticalConnector, draw.Rows[11].Cells[1].Style);
            Assert.Equal(DrawCellType.EvenCornerConnector, draw.Rows[12].Cells[1].Style);
            Assert.Equal(DrawCellType.OddCornerConnector, draw.Rows[17].Cells[1].Style);
            Assert.Equal(DrawCellType.VerticalConnector, draw.Rows[18].Cells[1].Style);
            Assert.Equal(DrawCellType.HorizontalConnector, draw.Rows[18].Cells[2].Style);
            Assert.Equal(DrawCellType.VerticalConnector, draw.Rows[19].Cells[1].Style);
            Assert.Equal(DrawCellType.EvenCornerConnector, draw.Rows[20].Cells[1].Style);
            Assert.Equal(DrawCellType.OddCornerConnector, draw.Rows[25].Cells[1].Style);
            Assert.Equal(DrawCellType.VerticalConnector, draw.Rows[26].Cells[1].Style);
            Assert.Equal(DrawCellType.HorizontalConnector, draw.Rows[26].Cells[2].Style);
            Assert.Equal(DrawCellType.VerticalConnector, draw.Rows[27].Cells[1].Style);
            Assert.Equal(DrawCellType.EvenCornerConnector, draw.Rows[28].Cells[1].Style);
            // Querter - Finals
            Assert.Equal(DrawCellType.FirstPlayer, draw.Rows[2].Cells[3].Style);
            Assert.Equal(DrawCellType.SecondPlayer, draw.Rows[3].Cells[3].Style);
            Assert.Equal(DrawCellType.FirstPlayer, draw.Rows[10].Cells[3].Style);
            Assert.Equal(DrawCellType.SecondPlayer, draw.Rows[11].Cells[3].Style);
            Assert.Equal(DrawCellType.FirstPlayer, draw.Rows[18].Cells[3].Style);
            Assert.Equal(DrawCellType.SecondPlayer, draw.Rows[19].Cells[3].Style);
            Assert.Equal(DrawCellType.FirstPlayer, draw.Rows[26].Cells[3].Style);
            Assert.Equal(DrawCellType.SecondPlayer, draw.Rows[27].Cells[3].Style);
            // Connections Quarter Finals - Semi Finals
            Assert.Equal(DrawCellType.OddCornerConnector, draw.Rows[3].Cells[4].Style);
            Assert.Equal(DrawCellType.VerticalConnector, draw.Rows[4].Cells[4].Style);
            Assert.Equal(DrawCellType.VerticalConnector, draw.Rows[5].Cells[4].Style);
            Assert.Equal(DrawCellType.VerticalConnector, draw.Rows[6].Cells[4].Style);
            Assert.Equal(DrawCellType.HorizontalConnector, draw.Rows[6].Cells[5].Style);
            Assert.Equal(DrawCellType.VerticalConnector, draw.Rows[7].Cells[4].Style);
            Assert.Equal(DrawCellType.VerticalConnector, draw.Rows[8].Cells[4].Style);
            Assert.Equal(DrawCellType.VerticalConnector, draw.Rows[9].Cells[4].Style);
            Assert.Equal(DrawCellType.EvenCornerConnector, draw.Rows[10].Cells[4].Style);
            Assert.Equal(DrawCellType.OddCornerConnector, draw.Rows[19].Cells[4].Style);
            Assert.Equal(DrawCellType.VerticalConnector, draw.Rows[20].Cells[4].Style);
            Assert.Equal(DrawCellType.VerticalConnector, draw.Rows[21].Cells[4].Style);
            Assert.Equal(DrawCellType.VerticalConnector, draw.Rows[22].Cells[4].Style);
            Assert.Equal(DrawCellType.HorizontalConnector, draw.Rows[22].Cells[5].Style);
            Assert.Equal(DrawCellType.VerticalConnector, draw.Rows[23].Cells[4].Style);
            Assert.Equal(DrawCellType.VerticalConnector, draw.Rows[24].Cells[4].Style);
            Assert.Equal(DrawCellType.VerticalConnector, draw.Rows[25].Cells[4].Style);
            Assert.Equal(DrawCellType.EvenCornerConnector, draw.Rows[26].Cells[4].Style);
            // Semi - Finals
            Assert.Equal(DrawCellType.FirstPlayer, draw.Rows[6].Cells[6].Style);
            Assert.Equal(DrawCellType.SecondPlayer, draw.Rows[7].Cells[6].Style);
            Assert.Equal(DrawCellType.FirstPlayer, draw.Rows[22].Cells[6].Style);
            Assert.Equal(DrawCellType.SecondPlayer, draw.Rows[23].Cells[6].Style);            
            // Connections Semi Finals -> Final
            Assert.Equal(DrawCellType.OddCornerConnector, draw.Rows[7].Cells[7].Style);
            Assert.Equal(DrawCellType.VerticalConnector, draw.Rows[8].Cells[7].Style);
            Assert.Equal(DrawCellType.VerticalConnector, draw.Rows[9].Cells[7].Style);
            Assert.Equal(DrawCellType.VerticalConnector, draw.Rows[10].Cells[7].Style);
            Assert.Equal(DrawCellType.VerticalConnector, draw.Rows[11].Cells[7].Style);
            Assert.Equal(DrawCellType.VerticalConnector, draw.Rows[12].Cells[7].Style);
            Assert.Equal(DrawCellType.VerticalConnector, draw.Rows[13].Cells[7].Style);
            Assert.Equal(DrawCellType.VerticalConnector, draw.Rows[14].Cells[7].Style);
            Assert.Equal(DrawCellType.HorizontalConnector, draw.Rows[14].Cells[8].Style);
            Assert.Equal(DrawCellType.VerticalConnector, draw.Rows[14].Cells[7].Style);
            Assert.Equal(DrawCellType.VerticalConnector, draw.Rows[16].Cells[7].Style);
            Assert.Equal(DrawCellType.VerticalConnector, draw.Rows[17].Cells[7].Style);
            Assert.Equal(DrawCellType.VerticalConnector, draw.Rows[18].Cells[7].Style);
            Assert.Equal(DrawCellType.VerticalConnector, draw.Rows[19].Cells[7].Style);
            Assert.Equal(DrawCellType.VerticalConnector, draw.Rows[20].Cells[7].Style);
            Assert.Equal(DrawCellType.VerticalConnector, draw.Rows[21].Cells[7].Style);
            Assert.Equal(DrawCellType.EvenCornerConnector, draw.Rows[22].Cells[7].Style);
            // Final
            Assert.Equal(DrawCellType.FirstPlayer, draw.Rows[14].Cells[9].Style);
            Assert.Equal(DrawCellType.SecondPlayer, draw.Rows[15].Cells[9].Style);
        }
    }

}
