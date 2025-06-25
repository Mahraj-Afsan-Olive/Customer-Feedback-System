using DAL.EF.Tables;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class ReplyRepo : Repo, IReplyRepo
    {
        public bool Create(Reply reply)
        {
            reply.RepliedAt = DateTime.Now;
            db.Replies.Add(reply);
            return db.SaveChanges() > 0;
        }

        public List<Reply> GetByFeedbackId(int feedbackId)
        {
            return db.Replies.Where(r => r.FeedbackId == feedbackId).ToList();
        }
    }
}
