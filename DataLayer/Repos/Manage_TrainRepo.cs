using DataLayer.EF;
using DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DataLayer.Repos
{
    internal class Manage_TrainRepo : IRepo<Manage_Trains, int>
    {
     readonly ETicketEntities db;
        public Manage_TrainRepo(ETicketEntities db)
        {
            this.db = db;
        }
        public List<Manage_Trains> GetAll()
        {
            var data = db.Manage_Trains.ToList();
            return data;
        }

        public Manage_Trains Get(int id)
        {
            return db.Manage_Trains.Find(id);
        }

        public bool Create(Manage_Trains obj)
        {
            try
            {
                var res=db.Manage_Trains.Add(obj);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Manage_Trains obj)
        {
            Manage_Trains old = db.Manage_Trains.Where(x => x.Id == obj.Id).SingleOrDefault();
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
                db.Manage_Trains.Remove((from n in db.Manage_Trains where n.Id == id select n).SingleOrDefault());
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

