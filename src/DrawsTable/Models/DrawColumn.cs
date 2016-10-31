using System.Collections.Generic;

namespace DrawsTable.Models
{
    internal class DrawColumn
    {
        private string _name;
        private DrawColumnType _type;

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

            set
            {
                _name = value;
            }
        }

        public DrawColumnType Type
        {
            get
            {
                return _type;
            }

            set
            {
                _type = value;
            }
        }
    }
}