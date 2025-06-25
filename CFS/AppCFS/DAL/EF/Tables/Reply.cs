using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Tables
{
    public class Reply
    {
        public int Id { get; set; }

        [Required]
        [StringLength(1000)]
        public string Message { get; set; }

        public DateTime RepliedAt { get; set; }

        [ForeignKey("Feedback")]
        public int FeedbackId { get; set; }

        public virtual Feedback Feedback { get; set; }
    }
}
