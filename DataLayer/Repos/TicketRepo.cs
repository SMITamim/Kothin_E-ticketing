using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.EF;
using DataLayer.Interfaces;


namespace DataLayer.Repos
{
    internal class TicketRepo : IRepo<Ticket, int>
    {
        ETicketEntities db;
        public TicketRepo(ETicketEntities db)
        {
            this.db = db;
        }

        public bool Create(Ticket obj)
        {
            try
            {
                var res = db.Tickets.Add(obj);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                db.Tickets.Remove((from n in db.Tickets where n.Id == id select n).SingleOrDefault());
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Ticket Get(int id)
        {
            return db.Tickets.Find(id);
        }

        public List<Ticket> GetAll()
        {
            return db.Tickets.ToList();
        }

        public bool Update(Ticket obj)
        {
            Ticket old = db.Tickets.Where(x => x.Id == obj.Id).SingleOrDefault();
            if (old != null)
            {
                db.Entry(old).CurrentValues.SetValues(obj);
                db.SaveChanges();
                return true;
            }
            return false;
        }


    }
}
