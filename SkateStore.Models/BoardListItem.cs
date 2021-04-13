using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkateStore.Models
{
    public class BoardListItem
    {
        [Required]
        public int BoardId { get; set; }
        [Required]
        [Display(Name = "Type of Board")]
        public string TypeOfBoard { get; set; }
        [Required]
        [Display(Name = "Product Name")]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
       
    }
}
