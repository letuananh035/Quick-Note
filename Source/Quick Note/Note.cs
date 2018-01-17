using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quick_Note
{
    public class Note
    {
        public string Tile = "";
        public string Data = "";
        public DateTime Date = DateTime.Now;
        public List<Tag> Tags = null;
        public bool isDelete = false;
    }
}
