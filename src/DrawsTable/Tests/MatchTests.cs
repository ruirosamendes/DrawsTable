using DrawsTable.Models;
using Newtonsoft.Json;
using System.IO;
using Xunit;

namespace DrawsTable.Tests
{
    public class MatchTests
    {
        [Fact]
        public void CreateMatchSetOponnentsMatchNumberAndSetsInit()
        {
            Opponent opponent1 = new Opponent("Rui", "Benfica");
            Opponent opponent2 = new Opponent("Joaquim", "Sporting");
            int bestOfTotal = 5;
            Match match = new Match(opponent1, opponent2, bestOfTotal);

            Assert.Equal(opponent1.Name, match.Opponent1.Name);
            Assert.Equal(opponent1.Team, match.Opponent1.Team);
            Assert.Equal(opponent2.Name, match.Opponent2.Name);
            Assert.Equal(opponent2.Team, match.Opponent2.Team);
            Assert.Equal(bestOfTotal, match.BestOfTotal);
            Assert.Equal(bestOfTotal, match.Sets.Length);
            Assert.Equal(0, match.Sets[0].Games1Total);
            Assert.Equal(0, match.Sets[0].Games2Total);
            Assert.Equal(0, match.Sets[1].Games1Total);
            Assert.Equal(0, match.Sets[1].Games2Total);
            Assert.Equal(0, match.Sets[2].Games1Total);
            Assert.Equal(0, match.Sets[2].Games2Total);
            Assert.Equal(0, match.Sets[3].Games1Total);
            Assert.Equal(0, match.Sets[3].Games2Total);
            Assert.Equal(0, match.Sets[4].Games1Total);
            Assert.Equal(0, match.Sets[4].Games2Total);
            //File.WriteAllText(@"C:\Users\rrm\Desktop\Match.json", JsonConvert.SerializeObject(match));
        }
    }
}
