using DrawsTable.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace DrawsTable.Tests
{
    public class SeedTests
    {
        [Fact]
        public void CalculateStrongestAgainstTheWeakestTwoPLayers()
        {
            IList<Tuple<int, int>> matches = Seed.CalculateMatches((int)DrawMap.Two);

            Assert.Equal(1, matches.Count);
            Assert.Equal(Tuple.Create(1, 2), matches[0]);
        }

        [Fact]
        public void CalculateStrongestAgainstTheWeakestFourPLayers()
        {
            IList<Tuple<int, int>> matches = Seed.CalculateMatches((int)DrawMap.Four);

            Assert.Equal(2, matches.Count);
            Assert.Equal(Tuple.Create(1, 4), matches[0]);
            Assert.Equal(Tuple.Create(2, 3), matches[1]);
        }

        [Fact]
        public void CalculateStrongestAgainstTheWeakestEightPlayers()
        {
            IList<Tuple<int, int>> matches = Seed.CalculateMatches((int)DrawMap.Eight);

            Assert.Equal(4, matches.Count);
            Assert.Equal(Tuple.Create(1, 8), matches[0]);
            Assert.Equal(Tuple.Create(4, 5), matches[1]);
            Assert.Equal(Tuple.Create(3, 6), matches[2]);
            Assert.Equal(Tuple.Create(2, 7), matches[3]);
        }

    }
}
