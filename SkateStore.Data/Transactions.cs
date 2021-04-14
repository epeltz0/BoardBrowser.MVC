using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SkateStore.Data
{
    public class Transactions
    {
        [Key]
        [Required]
        public int TransactionId { get; set; }
        
        [ForeignKey("Board")]
        public int BoardId { get; set; }
        
        
    }
}