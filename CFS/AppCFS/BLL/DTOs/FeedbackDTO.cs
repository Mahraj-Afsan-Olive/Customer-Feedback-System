using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class FeedbackDTO
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

        public string Status { get; set; } = "New";

        // Base64 string for uploading a screenshot
        public string ScreenshotBase64 { get; set; } = "";
    }
}
