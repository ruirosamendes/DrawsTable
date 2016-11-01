using System.Collections.Generic;

namespace DrawsTable.Models
{
    internal interface IOpponent
    {
        string Name { get; }
        string Team { get; }
        int Rank { get; }
    }
}