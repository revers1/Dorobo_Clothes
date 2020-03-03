using DoroboShop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DoroboShop.Entity
{
    [Table("tblUser")]
    public class User
    {
        [Key ,ForeignKey("user")]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        public virtual ApplicationUser user { get; set; }
    }
}