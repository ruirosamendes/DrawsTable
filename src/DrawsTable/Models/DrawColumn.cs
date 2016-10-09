namespace DrawsTable.Models
{
    internal class DrawColumn
    {
        private string _name;

        public DrawColumn(string name)
        {
            this._name = name;
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
    }
}