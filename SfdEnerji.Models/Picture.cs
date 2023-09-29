using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfdEnerji.Models
{
    public class Picture:BaseModel
    {
        public string Path { get; set; }
        public string? Alt { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }

    }
}
