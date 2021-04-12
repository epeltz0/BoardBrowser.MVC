using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SkateStore.Data
{
    public class Accessories
    {
        [Required]
        [Key]
        public int AccessoryId { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
       
        [Display(Name ="Compatible With")]
        [ForeignKey("Board")]
        public int BoardId { get; set; }

        [DefaultValue(false)]
        [Display(Name = "Favorited")]
        public bool IsFavorite { get; set; }

        public virtual ICollection<Transactions> Transactions { get; set; }
        public virtual ICollection<Ratings> Ratings { get; set; }
    }
}