using DataLayer.EF;
using DataLayer.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer.Repos
{
    internal class Airple_SchedulesRepo : IRepo<Airple_Schedules, int>
    {
        readonly ETicketEntities db;
        public Airple_SchedulesRepo(ETicketEntities db)
        {
            this.db = db;
        }
        public List<Airple_Schedules> GetAll()
        {
            return db.Airple_Schedules.ToList();
        }

        public Airple_Schedules Get(int id)
        {
            return db.Airple_Schedules.Find(id);
        }

        public bool Create(Airple_Schedules obj)
        {
            try
            {
                db.Airple_Schedules.Add(obj);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Airple_Schedules obj)
        {
            Airple_Schedules old = db.Airple_Schedules.Where(x => x.AirplaneId == obj.AirplaneId).SingleOrDefault();
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
                db.Airple_Schedules.Remove((from n in db.Airple_Schedules where n.AirplaneId == id select n).SingleOrDefault());
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
