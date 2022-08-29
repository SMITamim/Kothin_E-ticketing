using DataLayer.EF;
using DataLayer.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer.Repos
{
    internal class AirplaneRepo : IRepo<Airplane, int>
    {
        ETicketEntities db;
        public AirplaneRepo(ETicketEntities db)
        {
            this.db = db;
        }
        public bool Create(Airplane obj)
        {
            try
            {
                db.Airplanes.Add(obj);
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
                db.Airplanes.Remove((from n in db.Airplanes where n.Id == id select n).SingleOrDefault());
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }



        public Airplane Get(int id)
        {
            return db.Airplanes.Find(id);
        }

        public List<Airplane> GetAll()
        {
            return db.Airplanes.ToList();
        }


        public bool Update(Airplane obj)
        {
            Airplane old = db.Airplanes.Where(x => x.Id == obj.Id).SingleOrDefault();
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
