using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JimmysComicsSplitApp.DataModel
{
    class Comic
    {
        public string Name { get; set; }
        public int Issue { get; set; }
        public int Year { get; set; }
        public string CoverPrice { get; set; }
        public string Synopsis { get; set; }
        public string MainVillain { get; set; }
        public string Cover { get; set; }
    }
}
