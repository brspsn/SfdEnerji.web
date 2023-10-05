using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfdEnerji.Models
{
    [Table("Services")]
    public class Service:BaseModel
    {
        public string Content { get; set; }
        public string Thumbnail { get; set; }
        public string slug { get; set; }
        public int ViewCount { get; set; }
        public virtual ICollection<Picture>? Pictures { get; set; } = new List<Picture>();
        public virtual ICollection<Meta>? Metas { get; set; } = new List<Meta>();

    }
}
