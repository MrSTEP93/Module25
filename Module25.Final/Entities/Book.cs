using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module25.Final.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public short Year { get; set; }
        public List<Genre> Genres { get; set; }
        public Client Client { get; set; }
    }
}
