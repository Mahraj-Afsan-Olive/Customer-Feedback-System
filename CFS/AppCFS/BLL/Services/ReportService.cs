using BLL.DTOs;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ReportService
    {
        //summary
        public static FeedbackReportDTO GenerateFeedbackReport()
        {
            var feedbacks = DataAccess.FeedbackData().Get();

            var report = new FeedbackReportDTO
            {
                TotalFeedbacks = feedbacks.Count,
                NewCount = feedbacks.Count(f => f.Status == "New"),
                InProgressCount = feedbacks.Count(f => f.Status == "In Progress"),
                ResolvedCount = feedbacks.Count(f => f.Status == "Resolved"),
                FeedbacksByDate = feedbacks
                    .GroupBy(f => f.SubmittedAt.Date)
                    .ToDictionary(g => g.Key, g => g.Count())
            };

            return report;
        }

        public static object GetFeedbackReportByStatus(string status)
        {
            // Get all feedbacks
            var allFeedbacks = DataAccess.FeedbackData().Get();

            // Filter by status
            var filtered = allFeedbacks
                .Where(f => f.Status.ToLower() == status.ToLower())
                .ToList();

            var result = new
            {
                Status = status,
                TotalCount = filtered.Count,
                Feedbacks = filtered.Select(f => new FeedbackDTO
                {
                    Id = f.Id,
                    CustomerName = f.CustomerName,
                    Email = f.Email,
                    Message = f.Message,
                    Status = f.Status,
                    SubmittedAt = f.SubmittedAt,
                    AttachmentPath = f.AttachmentPath
                }).ToList()
            };

            return result;
        }
    }
}
