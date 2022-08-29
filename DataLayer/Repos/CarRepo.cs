using DataLayer.EF;
using DataLayer.Interfaces;
using System.Collections.Generic;
using System.Linq;


namespace DataLayer.Repos
{
    internal class CarRepo : IRepo<Car, int>
    {

        ETicketEntities db;
        public CarRepo(ETicketEntities db)
        {
            this.db = db;
        }
        public bool Create(Car obj)
        {
            try
            {
                db.Cars.Add(obj);
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
                db.Cars.Remove((from n in db.Cars where n.Id == id select n).SingleOrDefault());
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Car Get(int id)
        {
            return db.Cars.Find(id);
        }

        public List<Car> GetAll()
        {
            return db.Cars.ToList();
        }

        public bool Update(Car obj)
        {
            Car old = db.Cars.Where(x => x.Id == obj.Id).SingleOrDefault();
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
