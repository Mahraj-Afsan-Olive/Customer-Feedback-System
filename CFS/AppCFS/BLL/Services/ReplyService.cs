using AutoMapper;
using BLL.DTOs;
using DAL.EF.Tables;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ReplyService
    {
        static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Reply, ReplyDTO>();
                cfg.CreateMap<ReplyDTO, Reply>();
            });
            return new Mapper(config);
        }

        public static bool Create(ReplyDTO dto)
        {
            var entity = GetMapper().Map<Reply>(dto);
            return DataAccess.ReplyData().Create(entity);
        }

        public static List<ReplyDTO> GetByFeedbackId(int feedbackId)
        {
            var entities = DataAccess.ReplyData().GetByFeedbackId(feedbackId);
            return GetMapper().Map<List<ReplyDTO>>(entities);
        }
    }
}
