using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.EntityModel
{
    public class category
    {
        public int CatergoryId {get; set;}
        public int Penaltyperday { get; set; }
        public string Category { get; set; } 
        public int Period {get; set;}
    }
}
