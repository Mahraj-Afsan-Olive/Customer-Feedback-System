using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class CFSContext : DbContext
    {
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Reply> Replies { get; set; }


    }
}
