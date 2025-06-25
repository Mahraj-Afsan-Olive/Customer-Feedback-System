using BLL.DTOs;
using BLL.Helpers;
using DAL.EF.Tables;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web;
using AutoMapper;

namespace BLL.Services
{
    public class FeedbackService
    {

        // AutoMapper config
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Feedback, FeedbackDTO>();
                cfg.CreateMap<FeedbackDTO, Feedback>();
            });
            return new Mapper(config);
        }
        //feedback with or without attachment screenshot
        public static string Create(FeedbackDTO dto)
        {
            var entity = GetMapper().Map<Feedback>(dto);

            if (!string.IsNullOrEmpty(dto.ScreenshotBase64))
            {
                try
                {
                    string folder = HttpContext.Current.Server.MapPath("~/Uploads");
                    if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);

                    string fileName = Guid.NewGuid().ToString() + ".png";
                    string fullPath = Path.Combine(folder, fileName);

                    byte[] imageBytes = Convert.FromBase64String(dto.ScreenshotBase64);
                    File.WriteAllBytes(fullPath, imageBytes);

                    entity.AttachmentPath = "/Uploads/" + fileName;
                }
                catch
                {
                    throw new Exception("Invalid image data.");
                }
            }
            else
            {
                entity.AttachmentPath = "";
            }

            entity.SubmittedAt = DateTime.Now;
            entity.Status = "New";

            DataAccess.FeedbackData().Create(entity);

            return entity.AttachmentPath;
        }

        //Get all feedbacks
        public static List<FeedbackDTO> Get()
        {
            var entities = DataAccess.FeedbackData().Get();
            return GetMapper().Map<List<FeedbackDTO>>(entities);
        }
        // Get a specific feedback by ID
        public static FeedbackDTO Get(int id)
        {
            var entity = DataAccess.FeedbackData().Get(id);
            if (entity == null) return null;
            return GetMapper().Map<FeedbackDTO>(entity);
        }
        //Delete a feedback by ID
        public static void Delete(int id)
        {
            DataAccess.FeedbackData().Delete(id);
        }
        //Update Status of a feedback
        public static bool UpdateStatus(int id, StatusUpdateDTO dto, out string error)
        {
            var validStatuses = new[] { "New", "In Progress", "Resolved" };

            if (!validStatuses.Contains(dto.NewStatus))
            {
                error = $"Invalid status value. Please use one of the following: {string.Join(", ", validStatuses)}.";
                return false;
            }

            var feedback = DataAccess.FeedbackData().Get(id);
            if (feedback == null)
            {
                error = "Feedback not found.";
                return false;
            }

            feedback.Status = dto.NewStatus;
            var result = DataAccess.FeedbackData().Update(feedback);
            error = result ? null : "Failed to update in database.";
            return result;
        }

    }

}

