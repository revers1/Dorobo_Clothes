using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DoroboShop.Entity
{
    [Table("tblCategoryFirst")]
    public class Category_first
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public Category_main CategoryMain { get; set; }
        public ICollection<Category_second> CategoriesSecond { get; set; }

    }
}