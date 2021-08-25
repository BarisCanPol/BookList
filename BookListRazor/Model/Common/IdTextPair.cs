using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookListRazor.Model.Common
{
    public class IdTextPair
    {
        public int id { get; set; }
        public string text { get; set; }
        public IdTextPair()
        {

        }
        public IdTextPair(int i,string t)
        {
            this.id = i;
            this.text = t;
        }
    }
}
