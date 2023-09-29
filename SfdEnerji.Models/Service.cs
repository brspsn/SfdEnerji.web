using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfdEnerji.Models
{
    public class Service:BaseModel
    {
        public string Contant { get; set; }
        public string Thumbnail { get; set; }
        public string slug { get; set; }
        public int ViewCount { get; set; }
        public virtual ICollection<Picture>? Pictures { get; set; } = new List<Picture>();
    }
}
