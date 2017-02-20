using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.EntityModel
{
    public class loginAttempts
    {
        public int Id { get; set; }
        public string Email {get;set;}
        public DateTime Timestamp { get; set; }
        public bool Successfull { get; set; }
    }
}
