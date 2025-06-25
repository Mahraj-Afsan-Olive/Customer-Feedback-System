using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ReplyDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(1000)]
        public string Message { get; set; }

        public DateTime RepliedAt { get; set; }

        [Required]
        public int FeedbackId { get; set; }
    }
}
