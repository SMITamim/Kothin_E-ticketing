using BusinessLogic.BOs;
using DataLayer;
using DataLayer.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class BusServices
    {
        public static List<BusModel> GetAll()
        {
            var data = DataFactory.BusRepo().GetAll();
            List<BusModel> bus = new List<BusModel>();
            foreach (var d in data)
            {
                bus.Add(new BusModel { Id = d.Id, Regnumber = d.Regnumber, Ownername = d.Ownername, Ownerphone = d.Ownerphone, Owneremail = d.Owneremail, Drivername = d.Drivername, Driverphone = d.Driverphone, Isdoubledecker = d.Isdoubledecker, Category = d.Category, Coach = d.Coach});
            }
            return bus;
        }
        public static BusModel GetById(int id)
        {
            var data = DataFactory.BusRepo().Get(id);
            if (data == null)
                return null;
            return new BusModel
            {
                Regnumber = data.Regnumber,
                Ownername = data.Ownername,
                Ownerphone = data.Ownerphone,
                Owneremail = data.Owneremail,
                Drivername = data.Drivername,
                Driverphone = data.Driverphone,
                Isdoubledecker = data.Isdoubledecker,
                Category = data.Category,
                Coach = data.Category
            };

        }
        public static bool Create(BusModel obj)
        {
            Bus t = new Bus { Regnumber = obj.Regnumber, Ownername = obj.Ownername, Ownerphone = obj.Ownerphone, Owneremail = obj.Owneremail, Drivername = obj.Drivername, Driverphone = obj.Driverphone, Isdoubledecker = obj.Isdoubledecker, Category = obj.Category, Coach = obj.Coach };
            return DataFactory.BusRepo().Create(t);
        }
        public static bool Update(BusModel obj)
        {
            Bus t = new Bus { Id = obj.Id, Regnumber = obj.Regnumber, Ownername = obj.Ownername, Ownerphone = obj.Ownerphone, Owneremail = obj.Owneremail, Drivername = obj.Drivername, Driverphone = obj.Driverphone, Isdoubledecker = obj.Isdoubledecker, Category = obj.Category, Coach = obj.Coach };
            return DataFactory.BusRepo().Update(t);
        }
        public static bool Delete(int id)
        {
            return DataFactory.BusRepo().Delete(id);
        }
    }
}
