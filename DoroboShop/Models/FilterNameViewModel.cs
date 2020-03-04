﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoroboShop.Models
{
    public class FilterNameViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}