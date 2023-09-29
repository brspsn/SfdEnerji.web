using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfdEnerji.Models
{
    public class Page:BaseModel
    {
        public string Content { get; set; }
        public int ViewCount { get; set; }

        public string Slug { get; set; }//seyo kelimesi kullacıya seçtirilir/urldeki sayfa adı olarak görünür.
        public virtual ICollection<Picture>? Pictures { get; set; } = new List<Picture>();


    }
}
