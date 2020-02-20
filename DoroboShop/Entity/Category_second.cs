using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DoroboShop.Entity
{
    [Table("tblCategorySecond")]
    public class Category_second
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public Category_first CategoryFirst { get; set; }
    }
}