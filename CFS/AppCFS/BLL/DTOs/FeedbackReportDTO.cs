using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class FeedbackReportDTO
    {
        public int TotalFeedbacks { get; set; }
        public int NewCount { get; set; }
        public int InProgressCount { get; set; }
        public int ResolvedCount { get; set; }
        public Dictionary<DateTime, int> FeedbacksByDate { get; set; }
    }
}
