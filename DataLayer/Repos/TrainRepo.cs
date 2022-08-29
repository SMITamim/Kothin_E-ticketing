using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.EF;
using DataLayer.Interfaces;

namespace DataLayer.Repos
{
    internal class TrainRepo : IRepo<Train, int>
    {
        ETicketEntities db;
        public TrainRepo(ETicketEntities db)
        {
            this.db = db;
        }
        public bool Create(Train obj)
        {
            try
            {
                db.Trains.Add(obj);
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
                db.Trains.Remove((from n in db.Trains where n.Id == id select n).SingleOrDefault());
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Train Get(int id)
        {
            return db.Trains.Find(id);
        }

        public List<Train> GetAll()
        {
            return db.Trains.ToList();
        }
        
        public bool Update(Train obj)
        {
            Train old = db.Trains.Where(x => x.Id == obj.Id).SingleOrDefault();
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
