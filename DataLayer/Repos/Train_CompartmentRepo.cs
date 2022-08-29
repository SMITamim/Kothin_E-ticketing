using DataLayer.EF;
using DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repos
{
    internal class Train_CompartmentRepo : IRepo<Train_Compartments, int>
    {
        readonly ETicketEntities db;
        public Train_CompartmentRepo(ETicketEntities db)
        {
            this.db = db;
        }
        public List<Train_Compartments> GetAll()
        {
            return db.Train_Compartments.ToList();
        }

        public Train_Compartments Get(int id)
        {
            return db.Train_Compartments.Find(id);
        }

        public bool Create(Train_Compartments obj)
        {
            try
            {
                db.Train_Compartments.Add(obj);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Train_Compartments obj)
        {
            Train_Compartments old = db.Train_Compartments.Where(x => x.Id == obj.Id).SingleOrDefault();
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
                db.Train_Compartments.Remove((from n in db.Train_Compartments where n.Id == id select n).SingleOrDefault());
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
