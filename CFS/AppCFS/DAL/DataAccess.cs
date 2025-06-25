using DAL.EF.Tables;
using DAL.Interfaces;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccess
    {
        public static IRepo<Feedback, int, bool> FeedbackData()
        {
            return new FeedbackRepo();
        }

        public static IReplyRepo ReplyData()
        {
            return new ReplyRepo();
        }


    }
}
