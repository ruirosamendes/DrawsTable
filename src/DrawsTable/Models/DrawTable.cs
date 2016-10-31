using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DrawsTable.Models
{
    internal class DrawTable
    {
        
        private const int COLUMN_INTERVAL = 3;
        private int _totalPlayers;
        private int _totalRounds;
        private DrawColumn[] _columns;
        private DrawRow[] _rows;
        private const int TOTAL_MATCH_PLAYERS = 2;

        private static readonly string[] FinalRoundNames = { "Quarter - Finals", "Semi - Finals", "Final" };
        private List<string> _roundNames;
        private int _totalLoadedPlayers;

        public DrawTable(int totalPlayers)
        {
            _totalPlayers = totalPlayers;
            _totalRounds = (int)Math.Log(
               Convert.ToDouble(_totalPlayers),
               Convert.ToDouble(TOTAL_MATCH_PLAYERS));            
            CreateColumns();
            CreateRows();
            SetupLayout();
        }

        private void CreateRows()
        {
            int totalRows = (_totalPlayers * TOTAL_MATCH_PLAYERS) - TOTAL_MATCH_PLAYERS;
            _rows = new DrawRow[totalRows];
            for (int i = 0; i < totalRows; i++)
                _rows[i] = new DrawRow(_columns.Length);
        }



        private void SetupRoundsName()
        {
            _roundNames = new List<string>(_totalRounds);
            int numberOfFinalRounds = FinalRoundNames.Length;
            int numberOfEliminationRounds = _totalRounds - numberOfFinalRounds;
            // Buld rounds names
            for (int round = numberOfEliminationRounds; round > 0; round--)
                _roundNames.Add("Round " + round);
            _roundNames.AddRange(FinalRoundNames);
        }


        private void CreateColumnsInternal()
        {
            int totalColumns = (_totalRounds * COLUMN_INTERVAL) - TOTAL_MATCH_PLAYERS;
            _columns = new DrawColumn[totalColumns];
            int nextMatchLayoutStartColumn = 1;
            int roundIndex = 0;
            for (int columnIndex = 0; columnIndex < totalColumns; columnIndex++)
            {
                int columnPos = columnIndex + 1;
                if (columnPos == nextMatchLayoutStartColumn)
                {
                    _columns[columnIndex] = new DrawColumn(_roundNames[roundIndex], DrawColumnType.Match);
                    nextMatchLayoutStartColumn = nextMatchLayoutStartColumn + COLUMN_INTERVAL;
                    roundIndex++;
                }
                else
                {
                    _columns[columnIndex] = new DrawColumn("", DrawColumnType.Connector);
                }
            }
        }

        private void CreateColumns()
        {
            SetupRoundsName();
            CreateColumnsInternal();
        }

        public DrawColumn[] Columns
        {
            get
            {
                return _columns;
            }

            set
            {
                _columns = value;
            }
        }

        public DrawRow[] Rows
        {
            get
            {
                return _rows;
            }

            set
            {
                _rows = value;
            }
        }

        public int TotalPlayers
        {
            get
            {
                return _totalPlayers;
            }

            set
            {
                _totalPlayers = value;
            }
        }

        public int TotalRounds
        {
            get
            {
                return _totalRounds;
            }

            set
            {
                _totalRounds = value;
            }
        }

        private void SetupLayout()
        {
            int nextRoundIteration = 1;            
            int currentMatchLayoutInterval = ((int)Math.Pow(TOTAL_MATCH_PLAYERS, nextRoundIteration));
            int nextMatchLayoutStartColumn = 1;
            int nextMatchLayoutStartRow = 1;
            int nextMatchNumber = 1;

            for(int columnIndex = 0; columnIndex < _columns.Length; columnIndex++)
            {
                int columnPos = columnIndex + 1;
                if (columnPos == nextMatchLayoutStartColumn)
                {
                    // Set match cells
                    for (int rowIndex = 0; rowIndex < _rows.Length; rowIndex++)
                    {
                        int rowPos = rowIndex + 1;
                        if ((columnPos == nextMatchLayoutStartColumn) &&
                            (rowPos == nextMatchLayoutStartRow))
                        {
                            // Set match Two contiguous cells
                            _rows[rowIndex].Cells[columnIndex].Style = DrawCellType.FirstPlayer;
                            int contiguousRowIndex = rowIndex + 1;
                            _rows[contiguousRowIndex].Cells[columnIndex].Style = DrawCellType.SecondPlayer;

                            // If not the last match round then setup the connectors to next round match.
                            if (nextMatchLayoutStartColumn < _columns.Length)
                            {
                                // Odd Match?
                                if ((nextMatchNumber % 2) != 0)
                                {
                                    // Set match OddCorner connector
                                    _rows[contiguousRowIndex].Cells[columnIndex + 1].Style = DrawCellType.OddCornerConnector;
                                    int startVerticalIndex = contiguousRowIndex + 1;
                                    // Set match Vertical connector down
                                    for (int verticalIndex = startVerticalIndex; verticalIndex < (startVerticalIndex + (currentMatchLayoutInterval / 2)); verticalIndex++)
                                    {
                                        _rows[verticalIndex].Cells[columnIndex + 1].Style = DrawCellType.VerticalConnector;
                                    }
                                }
                                else
                                {
                                    int startVerticalIndex = rowIndex - 1;
                                    // Set match Vertical connector up
                                    for (int verticalIndex = startVerticalIndex; verticalIndex > (startVerticalIndex - (currentMatchLayoutInterval / 2)); verticalIndex--)
                                    {
                                        _rows[verticalIndex].Cells[columnIndex + 1].Style = DrawCellType.VerticalConnector;
                                    }
                                    // Set match EvenCorner connector
                                    _rows[rowIndex].Cells[columnIndex + 1].Style = DrawCellType.EvenCornerConnector;
                                }
                            }

                            // If not the first match round then setup the horizontal connector to the previous round match.
                            if (nextMatchLayoutStartColumn > 1)
                            {
                                // Set match horizontal connector (to previous match)
                                _rows[rowIndex].Cells[columnIndex - 1].Style = DrawCellType.HorizontalConnector;
                            }
                            // Jump to the next match
                            nextMatchLayoutStartRow = rowPos + 1 + currentMatchLayoutInterval + 1;
                            nextMatchNumber++;
                        }
                    }
                    // Setup next round iteration
                    nextRoundIteration++;                                     
                    currentMatchLayoutInterval = ((int)Math.Pow(TOTAL_MATCH_PLAYERS, nextRoundIteration)) + currentMatchLayoutInterval;
                    nextMatchLayoutStartColumn = nextMatchLayoutStartColumn + COLUMN_INTERVAL;
                    nextMatchLayoutStartRow = currentMatchLayoutInterval / TOTAL_MATCH_PLAYERS;
                }
            }
        }


        public int TotalLoadedPlayers
        {
            get
            {
                return _totalLoadedPlayers;
            }
        }

        internal void LoadPlayersFromTxt(string sourceFilePath)
        {
            string[] lines = File.ReadAllLines(sourceFilePath);

            string[][] players = lines.Select(line => line.Split('\t')).ToArray();

            _totalLoadedPlayers = players.Count();


        }
    }
}