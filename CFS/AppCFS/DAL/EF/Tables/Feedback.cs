using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Tables
{
    public class Feedback
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string CustomerName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(1000)]
        public string Message { get; set; }

        
        public string AttachmentPath { get; set; } = "";

        
        public DateTime SubmittedAt { get; set; }

        [Required]
        public string Status { get; set; } = "New";

        public virtual ICollection<Reply> Replies { get; set; } = new List<Reply>();
    }
}
