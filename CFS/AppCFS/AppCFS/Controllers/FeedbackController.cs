using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace AppCFS.Controllers
{
    [RoutePrefix("api/feedback")]
    [EnableCors("*", "*", "*")]
    public class FeedbackController : ApiController
    {
        [HttpGet]
        [Route("all")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = FeedbackService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "An error occurred while retrieving feedbacks. " + ex.Message);
            }
        }

        [HttpPost]
        [Route("submit")]
        public HttpResponseMessage Create(FeedbackDTO f)
        {
            try
            {
                var path = FeedbackService.Create(f);

                return Request.CreateResponse(HttpStatusCode.Created, new
                {
                    Message = "Feedback submitted successfully.",
                    FileUrl = string.IsNullOrEmpty(path) ? null :
                        Request.RequestUri.GetLeftPart(UriPartial.Authority) + path
                });
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError,
                    "Failed to submit feedback. " + ex.Message);
            }
        }


        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = FeedbackService.Get(id);
                if (data == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Feedback not found with ID " + id);
                }
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "An error occurred while fetching the feedback. " + ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var existing = FeedbackService.Get(id);
                if (existing == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Feedback not found with ID " + id);
                }

                FeedbackService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Feedback deleted successfully." });
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Failed to delete feedback. " + ex.Message);
            }
        }

        [HttpPatch]
        [Route("status/{id}")]
        public HttpResponseMessage UpdateStatus(int id, [FromBody] StatusUpdateDTO dto)
        {
            try
            {
                var result = FeedbackService.UpdateStatus(id, dto, out string error);
                if (!result)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, error);
                }

                return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Status updated successfully." });
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "An error occurred: " + ex.Message);
            }
        }

    }
}
