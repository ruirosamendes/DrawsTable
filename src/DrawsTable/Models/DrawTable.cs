using System;
using System.Collections.Generic;

namespace DrawsTable.Models
{
    internal class DrawTable
    {
        private int _totalPlayers;
        private Dictionary<int, DrawColumn> _columns;
        private Dictionary<int, DrawRow> _rows;
        private const int TotalMatchPlayers = 2;
        private int _totalLevels;

        public DrawTable(int totalPlayers)
        {
            this._totalPlayers = totalPlayers;
            int totalColumns = _totalPlayers - 1;
            this._columns = new Dictionary<int, DrawColumn>(totalColumns);
            for (int i = 1; i <= totalColumns; i++)
                _columns.Add(i, new DrawColumn("Column" + i));
            int totalRows = (_totalPlayers * 2) - 2;
            this._rows = new Dictionary<int, DrawRow>(totalRows);
            for (int i = 1; i <= totalRows; i++)
                _rows.Add(i, new DrawRow(_columns.Count));

            this._totalLevels = (int)Math.Log(
                Convert.ToDouble(_totalPlayers),
                Convert.ToDouble(TotalMatchPlayers));
        }

        public Dictionary<int, DrawColumn> Columns
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

        public Dictionary<int, DrawRow> Rows
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

        internal void SetupLayout()
        {
            int nextLevelIteration = 1;
            int currentNumberOfPlayers = _totalPlayers;
            int currentTotalOfMatches = currentNumberOfPlayers / TotalMatchPlayers;
            int currentMatchLayoutInterval = Math.Abs((currentNumberOfPlayers * TotalMatchPlayers) - _rows.Count);
            int nextMatchLayoutStartColumn = 1;
            int nextMatchLayoutStartRow = 1;

            foreach (int columnKey in _columns.Keys)
            {
                if (columnKey == nextMatchLayoutStartColumn)
                {
                    // Set match cells
                    foreach (KeyValuePair<int, DrawRow> row in _rows)
                    {
                        if ((columnKey == nextMatchLayoutStartColumn) &&
                            (row.Key == nextMatchLayoutStartRow))
                        {
                            // Set match Two contiguous cells
                            row.Value.Cells[columnKey].Style = DrawStyle.Match;
                            int contiguousRow = row.Key + 1;
                            _rows[contiguousRow].Cells[columnKey].Style = DrawStyle.Match;
                            nextMatchLayoutStartRow = contiguousRow + currentMatchLayoutInterval + 1;
                        }
                    }
                    // Setup next level iteration
                    nextLevelIteration++;
                    currentNumberOfPlayers = _totalPlayers / TotalMatchPlayers;
                    currentTotalOfMatches = currentNumberOfPlayers / TotalMatchPlayers;
                    currentMatchLayoutInterval = Math.Abs((currentNumberOfPlayers * TotalMatchPlayers) - _rows.Count);
                    nextMatchLayoutStartColumn = nextMatchLayoutStartColumn + _totalLevels;
                    nextMatchLayoutStartRow = ((int)Math.Pow(nextLevelIteration, TotalMatchPlayers)) - 1;    
                }
            }
        }

    }
}