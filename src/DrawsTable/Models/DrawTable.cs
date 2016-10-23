using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DrawsTable.Models
{
    internal class DrawTable
    {
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
            this._columns = new DrawColumn[totalColumns];
            for (int i = 0; i < totalColumns; i++)
                _columns[i] = new DrawColumn("Column" + i);
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
                            int contiguousRow = rowPos + 1;
                            _rows[contiguousRowIndex].Cells[columnIndex].Style = DrawCellType.SecondPlayer;
                            nextMatchLayoutStartRow = contiguousRow + currentMatchLayoutInterval + 1;
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