using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfdEnerji.Models
{
    public class ContactForm:BaseModel
    {
        public string Email { get; set; }
        public string? Phone { get; set; }
        public string? Subject { get; set; }
        public string Message { get; set; }

    }
}
