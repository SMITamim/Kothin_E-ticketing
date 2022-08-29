using DataLayer.EF;
using DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repos
{
    internal class Train_ScheduleRepo : IRepo<Train_Schedules, int>
    {
        readonly ETicketEntities db;
        public Train_ScheduleRepo(ETicketEntities db)
        {
            this.db = db;
        }
        public List<Train_Schedules> GetAll()
        {
            return db.Train_Schedules.ToList();
        }

        public Train_Schedules Get(int id)
        {
            return db.Train_Schedules.Find(id);
        }

        public bool Create(Train_Schedules obj)
        {
            try
            {
                db.Train_Schedules.Add(obj);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Train_Schedules obj)
        {
            Train_Schedules old = db.Train_Schedules.Where(x => x.Id == obj.Id).SingleOrDefault();
            if (old != null)
            {
                db.Entry(old).CurrentValues.SetValues(obj);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            try
            {
                db.Train_Schedules.Remove((from n in db.Train_Schedules where n.Id == id select n).SingleOrDefault());
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
