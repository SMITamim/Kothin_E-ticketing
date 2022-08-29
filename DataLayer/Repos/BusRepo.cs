using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.EF;
using DataLayer.Interfaces;


namespace DataLayer.Repos
{
    internal class BusRepo: IRepo<Bus,int>
    {
            ETicketEntities db;
            public BusRepo(ETicketEntities db)
            {
                this.db = db;
            }
            public bool Create(Bus obj)
            {
                try
                {
                    db.Buses.Add(obj);
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
                    db.Buses.Remove((from n in db.Buses where n.Id == id select n).SingleOrDefault());
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }

            public Bus Get(int id)
            {
                return db.Buses.Find(id);
            }

            public List<Bus> GetAll()
            {
                return db.Buses.ToList();
            }

        public bool Update(Bus obj)
        {
            Bus old = db.Buses.Where(x => x.Id == obj.Id).SingleOrDefault();
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
