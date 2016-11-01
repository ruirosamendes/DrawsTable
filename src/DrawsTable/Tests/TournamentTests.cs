using DrawsTable.Models;
using Newtonsoft.Json;
using System;
using System.IO;
using Xunit;

namespace DrawsTable.Tests
{
    public class TournamentTests : IDisposable
    {
        Tournament _tournament;

        public TournamentTests()
        {
            string name = "Torneio de Mafra";
            DateTime day = DateTime.Today;
            _tournament = new Tournament(name, day);


        }

        public void Dispose()
        {
           
        }

        [Fact]
        public void CreateTournamentSetsNameAndDate()
        {
            string name = "Torneio de Mafra";
            DateTime day = DateTime.Today;
            Assert.Equal(name, _tournament.Name);
            Assert.Equal(day, _tournament.Day);
        }

        [Fact]
        public void LoadPlayersNamesAndTeamsFromTxtFile()
        {
            
            string path = Directory.GetCurrentDirectory();
            string filePath = path + @"\..\..\PlayersAndTeams.txt";

            _tournament.LoadPlayersFromTxt(filePath);
            Assert.Equal(37, _tournament.TotalLoadedPlayers);
            Assert.Equal("PEDRO MENDES", _tournament.Players[0].Name);
            Assert.Equal("SIEMENS", _tournament.Players[0].Team);
            Assert.Equal(1, _tournament.Players[0].Rank);
            Assert.Equal("CARLOS PAIVA", _tournament.Players[36].Name);
            Assert.Equal("CGD-LX", _tournament.Players[36].Team);
            Assert.Equal(37, _tournament.Players[36].Rank);
        }


        [Fact]
        public void MakeDrawSeedingWithThePlayersNotCrashWithoutPlayers()
        {
            Exception ex = Assert.Throws<Exception>(() => _tournament.MakeDraw(DrawMap.Sixteen, 16, 3));
            Assert.Equal("Insufficient loaded players. You must load two or more players.", ex.Message);

        }

        [Fact]
        public void MakeDrawSeedingWithThePlayers()
        {
            string path = Directory.GetCurrentDirectory();
            string filePath = path + @"\..\..\PlayersAndTeams.txt";
            _tournament.LoadPlayersFromTxt(filePath);
            _tournament.MakeDraw(DrawMap.Sixteen, 16, 3);
            Assert.Equal((int)DrawMap.Sixteen / 2, _tournament.Matches.Length);
            Assert.Equal(1, _tournament.Matches[0].Number);
            Assert.Equal(1, _tournament.Matches[0].Opponent1.Rank);
            Assert.Equal(16, _tournament.Matches[0].Opponent2.Rank);

            Assert.Equal(2, _tournament.Matches[1].Number);
            Assert.Equal(8, _tournament.Matches[1].Opponent1.Rank);
            Assert.Equal(9, _tournament.Matches[1].Opponent2.Rank);

            Assert.Equal(3, _tournament.Matches[2].Number);
            Assert.Equal(5, _tournament.Matches[2].Opponent1.Rank);
            Assert.Equal(12, _tournament.Matches[2].Opponent2.Rank);

            Assert.Equal(4, _tournament.Matches[3].Number);
            Assert.Equal(4, _tournament.Matches[3].Opponent1.Rank);
            Assert.Equal(13, _tournament.Matches[3].Opponent2.Rank);

            Assert.Equal(5, _tournament.Matches[4].Number);
            Assert.Equal(3, _tournament.Matches[4].Opponent1.Rank);
            Assert.Equal(14, _tournament.Matches[4].Opponent2.Rank);

            Assert.Equal(6, _tournament.Matches[5].Number);
            Assert.Equal(6, _tournament.Matches[5].Opponent1.Rank);
            Assert.Equal(11, _tournament.Matches[5].Opponent2.Rank);

            Assert.Equal(7, _tournament.Matches[6].Number);
            Assert.Equal(7, _tournament.Matches[6].Opponent1.Rank);
            Assert.Equal(10, _tournament.Matches[6].Opponent2.Rank);

            Assert.Equal(8, _tournament.Matches[7].Number);
            Assert.Equal(2, _tournament.Matches[7].Opponent1.Rank);
            Assert.Equal(15, _tournament.Matches[7].Opponent2.Rank);

            File.WriteAllText(@"C:\Users\rrm\Desktop\DrawMatches.json", JsonConvert.SerializeObject(_tournament.Matches));
           
        }

    }
}
