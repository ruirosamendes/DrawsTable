using System;
using System.Collections.Generic;


namespace DrawsTable.Models
{
    public static class Seed
    {


        public static List<Tuple<int, int>> CalculateMatches(int totalPlayers)
        {
            int totalMatches = totalPlayers / 2;
            List<Tuple<int, int>> matches = new List<Tuple<int, int>>(totalMatches);

            //i ; n-i + 1
            //(n / 2) - i + 1;  (n / 2) + i
            //(n / 2) - i + 1;  (n / 2) + i
            //i ; n-i + 1

            Tuple<int, int> match1;
            Tuple<int, int> match2;
            Tuple<int, int> match3;
            Tuple<int, int> match4;

            if (totalMatches == 1)
            {
                match1 = Tuple.Create(1, 2);
                matches.Add(match1);
            }
            else if (totalMatches == 2)
            {
                match1 = Tuple.Create(1, 4);
                matches.Add(match1);
                match2 = Tuple.Create(2, 3);
                matches.Add(match2);
            }
            else
            {
                List<Tuple<int, int>> matchesFactor;
                matchesFactor = CalculateMatches(totalPlayers / 2);

                for (int matchFactorIndex = 0; matchFactorIndex < matchesFactor.Count / 2; matchFactorIndex++)
                {
                    match1 = Tuple.Create(matchesFactor[matchFactorIndex].Item1, totalPlayers - matchesFactor[matchFactorIndex].Item1 + 1);
                    matches.Add(match1);

                    match2 = Tuple.Create((totalPlayers / 2) - matchesFactor[matchFactorIndex].Item1 + 1, (totalPlayers / 2) + matchesFactor[matchFactorIndex].Item1);
                    matches.Add(match2);

                    int nextMatchFactorIndex = matchFactorIndex + 1;
                    match3 = Tuple.Create((totalPlayers / 2) - matchesFactor[nextMatchFactorIndex].Item1 + 1, (totalPlayers / 2) + matchesFactor[nextMatchFactorIndex].Item1);
                    matches.Add(match3);

                    match4 = Tuple.Create(matchesFactor[nextMatchFactorIndex].Item1, totalPlayers - matchesFactor[nextMatchFactorIndex].Item1 + 1);
                    matches.Add(match4);
                }
            }

           return matches;
        }
    }
}
