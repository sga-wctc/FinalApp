using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace FinalApp
{
    class Triplog
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string LocName { get; set; }
        public string Description { get; set; }
        public string ImageFile { get; set; }
    }
}
