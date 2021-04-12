using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SkateStore.Data
{
    public class Users
    {
        [Key]
        [Required]
        public int UserId { get; set; }
        [Required]
        [Display(Name = "Full Name")]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        public virtual ICollection<Transactions> Transactions { get; set; }
        public virtual ICollection<Ratings> Ratings{ get; set; }

    }
}