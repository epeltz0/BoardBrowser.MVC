using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkateStore.Models
{
    public class BoardDetail
    {
        
        public int BoardId { get; set; }
        
        [Display(Name = "Type of Board")]
        public string TypeOfBoard { get; set; }
        
        [Display(Name = "Product Name")]
        public string Name { get; set; }
       
        public string Description { get; set; }
       
        public decimal Price { get; set; }
    }
}
