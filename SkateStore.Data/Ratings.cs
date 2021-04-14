using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkateStore.Data
{
    public class Ratings
    {
        [Key]
        [Required]
        public int RatingId { get; set; }
        
        [ForeignKey("Board Id")]
        public int BoardId { get; set; }
     
        [ForeignKey("User Id")]
        [Required]
        public Guid UserId { get; set; }
       
        [Required]
        [Range(1, 5, ErrorMessage = "Value must be between 1 and 5")]
        public int DurablityRating { get; set; }
        
        [Required]
        [Range(1, 5, ErrorMessage = "Value must be between 1 and 5")]
        public int AffordabilityRating { get; set; }
        
        [Required]
        [Range(1, 5, ErrorMessage = "Value must be between 1 and 5")]
        public int SpeedRating { get; set; }
        
        public string Comment { get; set; }
    }
}
