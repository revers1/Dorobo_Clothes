using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoroboShop.ModelsCreate
{
    public class CreateCategoryViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int? ParentId { get; set; }
    }
}