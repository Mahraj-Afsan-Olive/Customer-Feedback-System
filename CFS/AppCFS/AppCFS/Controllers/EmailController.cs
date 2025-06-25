using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace AppCFS.Controllers
{
    [RoutePrefix("api/email")]
    [EnableCors("*", "*", "*")]
    public class EmailController : ApiController
    {
        [HttpPost]
        [Route("send/{id}")]
        public HttpResponseMessage SendStatusEmail(int id)
        {
            try
            {
                var feedback = FeedbackService.Get(id);
                if (feedback == null)
                {
                    return Request.CreateErrorResponse(
                        HttpStatusCode.NotFound,
                        $"Feedback with ID {id} not found."
                    );
                }

                bool success = MailService.SendResolutionEmail(feedback);

                if (success)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new
                    {
                        Message = $"Email sent based on status '{feedback.Status}' successfully.",
                        Email = feedback.Email,
                        FeedbackId = feedback.Id,
                        Status = feedback.Status
                    });
                }
                else
                {
                    return Request.CreateErrorResponse(
                        HttpStatusCode.InternalServerError,
                        "Failed to send email. Please check your SMTP configuration or internet connection."
                    );
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(
                    HttpStatusCode.InternalServerError,
                    $"An unexpected error occurred while sending the email: {ex.Message}"
                );
            }
        }
    }
}
