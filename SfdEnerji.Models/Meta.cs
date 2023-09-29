using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfdEnerji.Models
{
    public class Meta:BaseModel
    {
        public string? MetaName { get; set; }
        public string? MetaProperty { get; set; }
        public string MetaContant { get; set; }
    }
}
