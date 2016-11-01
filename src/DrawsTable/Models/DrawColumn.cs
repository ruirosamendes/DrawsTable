using System.Collections.Generic;

namespace DrawsTable.Models
{
    internal class DrawColumn
    {
        private readonly string _name;
        private readonly DrawColumnType _type;

        public DrawColumn(string name, DrawColumnType type)
        {
            _name = name;
            _type = type;
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public DrawColumnType Type
        {
            get
            {
                return _type;
            }
        }
    }
}