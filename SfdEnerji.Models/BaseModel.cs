﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfdEnerji.Models
{
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifitedDate { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; }=false;

    }
}
