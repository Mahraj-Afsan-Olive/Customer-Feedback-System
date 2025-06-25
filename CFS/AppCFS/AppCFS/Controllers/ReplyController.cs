using BLL.DTOs;
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
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/replies")]
    public class ReplyController : ApiController
    {
        [HttpPost]
        [Route("reply")]
        public HttpResponseMessage AddReply(ReplyDTO dto)
        {
            if (dto == null || string.IsNullOrWhiteSpace(dto.Message))
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Reply message is required.");

            var success = ReplyService.Create(dto);
            if (success)
                return Request.CreateResponse(HttpStatusCode.OK, "Reply added successfully.");
            else
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Failed to add reply.");
        }

        [HttpGet]
        [Route("getbyfeedback/{feedbackId}")]
        public HttpResponseMessage GetReplies(int feedbackId)
        {
            var data = ReplyService.GetByFeedbackId(feedbackId);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
