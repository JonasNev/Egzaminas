using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostalService.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Town { get; set; }
        public int Capacity { get; set; }
        public string Code { get; set; }
    }
}
