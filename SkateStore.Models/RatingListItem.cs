using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkateStore.Models
{
    public class RatingListItem
    {
        public int RatingId { get; set; }
        public int BoardId { get; set; }
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
