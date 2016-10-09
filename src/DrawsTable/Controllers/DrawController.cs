using DrawsTable.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrawsTable.Controllers
{
    public class DrawController
    {
        public string Get()
        {
            DrawTable draw = new DrawTable(8);
            return draw.Json;
        }

    }
}
