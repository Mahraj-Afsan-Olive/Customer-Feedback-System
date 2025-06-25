using BLL.DTOs;
using BLL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class MailService
    {
        public static bool SendResolutionEmail(FeedbackDTO feedback)
        {
            string subject = $"Update on Your Feedback (ID: {feedback.Id})";
            string body = $@"<h3>Hello {feedback.CustomerName},</h3>";

            if (feedback.Status.Equals("New", StringComparison.OrdinalIgnoreCase))
            {
                subject = $"Your Feedback (ID: {feedback.Id}) has been received!";
                body += $@"
                <p>Thank you for submitting your feedback. We have received it and will review it shortly.</p>
                <p>Message: {feedback.Message}</p>
                <p>Status: {feedback.Status}</p>
                <p>Submitted At: {feedback.SubmittedAt}</p>";
            }
            else if (feedback.Status.Equals("In Progress", StringComparison.OrdinalIgnoreCase))
            {
                subject = $"Your Feedback (ID: {feedback.Id}) is being processed";
                body += $@"
                <p>Your feedback is currently being reviewed by our support team.</p>
                <p>Message: {feedback.Message}</p>
                <p>Status: {feedback.Status}</p>
                <p>Submitted At: {feedback.SubmittedAt}</p>";
            }
            else if (feedback.Status.Equals("Resolved", StringComparison.OrdinalIgnoreCase))
            {
                subject = $"Your Feedback (ID: {feedback.Id}) has been resolved!";
                body += $@"
                <p>Your feedback has been marked as <b>Resolved</b>.</p>
                <p>Message: {feedback.Message}</p>
                <p>Status: {feedback.Status}</p>
                <p>Submitted At: {feedback.SubmittedAt}</p>";
            }
            else
            {
                subject = $"Update on Your Feedback (ID: {feedback.Id})";
                body += $@"
                <p>Status: {feedback.Status}</p>
                <p>Message: {feedback.Message}</p>
                <p>Submitted At: {feedback.SubmittedAt}</p>";
            }

            body += @"<br/><p>Thank you,<br/>Customer Support Team</p>";

            return EmailHelper.SendEmail(feedback.Email, subject, body);
        }
    }

}
