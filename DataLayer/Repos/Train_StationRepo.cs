using DataLayer.EF;
using DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repos
{
    internal class Train_StationRepo : IRepo<Train_Stations, int>
    {
        readonly ETicketEntities db;
        public Train_StationRepo(ETicketEntities db)
        {
            this.db = db;
        }

        public List<Train_Stations> GetAll()
        {
            return db.Train_Stations.ToList();
        }

        public bool Create(Train_Stations obj)
        {
            try
            {
                db.Train_Stations.Add(obj);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Train_Stations Get(int id)
        {
            return db.Train_Stations.Find(id);
        }

        public bool Update(Train_Stations obj)
        {
            Train_Stations old = db.Train_Stations.Where(x => x.Id == obj.Id).SingleOrDefault();
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
                db.Train_Stations.Remove((from n in db.Train_Stations where n.Id == id select n).SingleOrDefault());
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
