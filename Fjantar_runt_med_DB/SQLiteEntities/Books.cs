using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fjantar_runt_med_DB.SQLiteEntities
{
    internal class Books
    {
        internal int Id { get; set; }
        internal string Title { get; set; } = string.Empty;
        internal string Author { get; set; } = string.Empty;
        internal int Year { get; set; }
        internal string ISBN { get; set; } = string.Empty;
    }
}
