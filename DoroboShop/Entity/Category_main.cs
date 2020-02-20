using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DoroboShop.Entity
{
    [Table("tblCategoryMain")]
    public class Category_main
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public ICollection<Category_first> CategoriesFirst { get; set; }
    }
}