using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.EF;
using DataLayer.Interfaces;

namespace DataLayer.Repos
{
    internal class AdminRepo : IRepo<Admin, int>
    {
        ETicketEntities db;
        public AdminRepo(ETicketEntities db)
        {
            this.db = db;
        }
        public bool Create(Admin obj)
        {
            try
            {
                db.Admins.Add(obj);
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
                db.Admins.Remove((from n in db.Admins where n.Id == id select n).SingleOrDefault());
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Admin Get(int id)
        {
            return db.Admins.Find(id);
        }

        public List<Admin> GetAll()
        {
            return db.Admins.ToList();
        }

        public bool Update(Admin obj)
        {
            var old = db.Trains.FirstOrDefault(x => x.Id == obj.Id);
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
