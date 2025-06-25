using DAL.EF.Tables;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class FeedbackRepo : Repo, IRepo<Feedback, int, bool>
    {
        public bool Create(Feedback f)
        {
            f.SubmittedAt = DateTime.Now;
            f.Status = "New";
            db.Feedbacks.Add(f);
            return db.SaveChanges() > 0;
        }

        public void Delete(int id)
        {
            var f = Get(id);
            db.Feedbacks.Remove(f);
            db.SaveChanges();
        }

        public List<Feedback> Get()
        {
            return db.Feedbacks.ToList();
        }

        public Feedback Get(int id)
        {
            return db.Feedbacks.Find(id);
        }

        public bool Update(Feedback f)
        {
            var ex = Get(f.Id);
            db.Entry(ex).CurrentValues.SetValues(f);
            return db.SaveChanges() > 0;
        }
    }
}
