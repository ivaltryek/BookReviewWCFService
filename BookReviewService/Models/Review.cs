using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewService.Models
{
    public class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        [Range(0,10)]
        public int ReviewScale { get; set; }
        [Required]
        public string ReviewBy { get; set; }
        [Required]
        public string ReviewOn { get; set; }
        public string ReviewComment { get; set; }

    }
}
