using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DrawsTable.Models
{
    internal class DrawTable
    {
        private static readonly string[] FinalRoundNames = { "Quarter - Finals", "Semi - Finals", "Final" };
        private int _totalPlayers;
        private DrawColumn[] _columns;
        private DrawRow[] _rows;
        private const int TotalMatchPlayers = 2;
        private int _totalLevels;


        public DrawTable(int totalPlayers)
        {
            this._totalPlayers = totalPlayers;
            this._totalLevels = (int)Math.Log(
               Convert.ToDouble(_totalPlayers),
               Convert.ToDouble(TotalMatchPlayers));
            CreateColumns();
            CreateRows();
            SetupLayout();
        }

        private void CreateRows()
        {
            int totalRows = (_totalPlayers * 2) - 2;
            this._rows = new DrawRow[totalRows];
            for (int i = 0; i < totalRows; i++)
                _rows[i] = new DrawRow(_columns.Length);
        }

        private void CreateColumns()
        {
            int totalColumns = _totalPlayers - 1;
            _columns = new DrawColumn[totalColumns];

            int nextMatchLayoutStartColumn = 1;
            int levelIndex = 0;
            for (int columnIndex = 0; columnIndex < totalColumns; columnIndex++)
            {
                int columnPos = columnIndex + 1;
                if (columnPos == nextMatchLayoutStartColumn)
                {
                    _columns[columnIndex] = new DrawColumn(FinalRoundNames[levelIndex], DrawColumnType.Match);
                    nextMatchLayoutStartColumn = nextMatchLayoutStartColumn + _totalLevels;
                    levelIndex++;
                }
                else
                {
                    _columns[columnIndex] = new DrawColumn("", DrawColumnType.Connector);
                }
            }
                
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

        public int TotalLevels
        {
            get
            {
                return _totalLevels;
            }

            set
            {
                _totalLevels = value;
            }
        }

        private void SetupLayout()
        {
            int nextLevelIteration = 1;
            int currentNumberOfPlayers = _totalPlayers;
            int currentTotalOfMatches = currentNumberOfPlayers / nextLevelIteration;
            int currentMatchLayoutInterval = Math.Abs((currentNumberOfPlayers * TotalMatchPlayers) - _rows.Length);
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

                            // If not the last match level then setup the connectors to next level match.
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

                            // If not the first match level then setup the horizontal connector to the previous level match.
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
                    // Setup next level iteration
                    nextLevelIteration++;
                    currentNumberOfPlayers = _totalPlayers / nextLevelIteration;
                    currentTotalOfMatches = currentNumberOfPlayers / TotalMatchPlayers;
                    currentMatchLayoutInterval = Math.Abs((currentNumberOfPlayers * TotalMatchPlayers) - _rows.Length);
                    nextMatchLayoutStartColumn = nextMatchLayoutStartColumn + _totalLevels;
                    nextMatchLayoutStartRow = ((int)Math.Pow(nextLevelIteration, TotalMatchPlayers)) - (nextLevelIteration - 1);    
                }
            }
        }
    }
}