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
    [RoutePrefix("api/report")]
    [EnableCors("*", "*", "*")]
    public class ReportController : ApiController
    {

        [HttpGet]
        [Route("feedback-summary")]
        public HttpResponseMessage GetFeedbackSummary()
        {
            try
            {
                var report = ReportService.GenerateFeedbackReport();
                return Request.CreateResponse(HttpStatusCode.OK, report);
            }
            catch (System.Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Failed to generate report: " + ex.Message);
            }
        }

        [HttpPost]
        [Route("feedback-by-status")]
        public HttpResponseMessage GetFeedbackByStatus([FromBody] string status)
        {
            if (string.IsNullOrWhiteSpace(status))
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Status is required.");
            }

            try
            {
                var data = ReportService.GetFeedbackReportByStatus(status);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Something went wrong generating the report.");
            }
        }
    }
}
