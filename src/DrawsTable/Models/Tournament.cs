using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace DrawsTable.Models
{
    internal class Tournament
    {
        private string _name;
        private DateTime _day;
        private int _totalLoadedPlayers = 0;
        private Player[] _players;
        private const int TOTAL_MATCH_PLAYERS = 2;
        private SortedDictionary<int, Match> drawMatchs = new SortedDictionary<int, Match>();

        public Tournament(string name, DateTime day)
        {
            _name = name;            
            _day = day;
        }


        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public DateTime Day
        {
            get
            {
                return _day;
            }

            set
            {
                _day = value;
            }
        }

        public int TotalLoadedPlayers
        {
            get
            {
                return _totalLoadedPlayers;
            }
        }

        internal Player[] Players
        {
            get
            {
                return _players;
            }
        }

        internal Match[] Matches
        {
            get
            {
                return drawMatchs.Values.ToArray();
            }
        }

        internal void LoadPlayersFromTxt(string sourceFilePath)
        {
            string[] lines = File.ReadAllLines(sourceFilePath, Encoding.UTF8);
            _players = new Player[lines.Length];
            Player player;
            int playerIndex = 0;
            int rank = playerIndex + 1;

            foreach (string line in lines)
            {
                string[] playerDataStrs = line.Split('\t');

                player = new Player(rank, playerDataStrs[0], playerDataStrs[1]);
                _players[playerIndex] = player;
                playerIndex++;
                rank++;
            }
            _totalLoadedPlayers = _players.Length;
        }

        internal void MakeDraw(DrawMap drawMap, int seedsTotal, int bestOfTotal)
        {
            Dictionary<int, Player> drawPlayers = new Dictionary<int, Player>();


            int totalDrawPlayers = (int)drawMap;
            int totalDrawMatches = totalDrawPlayers / TOTAL_MATCH_PLAYERS;
            int matchIncrement = (int)Math.Log(
               Convert.ToDouble(totalDrawMatches),
               Convert.ToDouble(TOTAL_MATCH_PLAYERS));

            int playerIndexForward = 0;
            int playerIndexBackward = totalDrawPlayers - 1;
            int playerPos = 1;
            int matchPosForward = 1;
            int matchPosBackward = totalDrawMatches;
            int matchNumber = 1;
            int matchInterval = 0;
            int incrementChangeIndex = 0;

            if(_totalLoadedPlayers < 2)
                throw new Exception("Insufficient loaded players. You must load two or more players.");
            // Set matchs
            for (int matchIndex = 0; matchIndex < totalDrawMatches; matchIndex++)
            {
                // Reset interval increment
                if (incrementChangeIndex == 2)
                {
                    if (matchInterval == matchIncrement)
                        matchInterval = 0;
                    else if (matchInterval == 0)
                        matchInterval = matchIncrement;
                    incrementChangeIndex = 0;
                }

                Match match = new Match(_players[playerIndexForward], _players[playerIndexBackward], bestOfTotal);
                // Odd match
                if ((matchNumber % 2) != 0)
                {
                    match.Number = matchPosForward + matchInterval;
                    matchPosForward++;
                }
                // Even match
                else
                {
                    match.Number = matchPosBackward - matchInterval;
                    matchPosBackward--;
                }
                // Add match on Draw position.
                drawMatchs.Add(match.Number.Value, match);
                // Change indexes.
                incrementChangeIndex++;
                playerIndexForward++;
                playerIndexBackward--;
                matchNumber++;
                // Save players with draw ordered.
                drawPlayers.Add(playerPos, match.Opponent1 as Player);
                drawPlayers.Add(playerPos + 1, match.Opponent2 as Player);
                playerPos += 2;

            }
        }
    }
}