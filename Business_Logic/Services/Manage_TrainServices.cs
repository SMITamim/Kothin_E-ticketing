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
    public class Manage_TrainServices
    {
        public static List<Manage_TrainModel> GetAll()
        {
            var data = DataFactory.Manage_TrainRepo().GetAll();
            List<Manage_TrainModel> manage_trains = new List<Manage_TrainModel>();
            foreach (var d in data)
            {
                manage_trains.Add(new Manage_TrainModel { Id = d.Id, TrainId = d.TrainId, StationId = d.StationId, ScheduleId=d.ScheduleId });
            }
            return manage_trains;
        }

        public static Manage_TrainModel GetById(int id)
        {
            var data = DataFactory.Manage_TrainRepo().Get(id);
            if (data == null)
                return null;
            return new Manage_TrainModel
            {
                Id = data.Id,
                TrainId = data.TrainId,
                StationId = data.StationId,
                ScheduleId = data.ScheduleId,
            };
        }

        public static bool Create(Manage_TrainModel obj)
        {
            Manage_Trains t = new Manage_Trains { TrainId = obj.TrainId, StationId = obj.StationId, ScheduleId= obj.ScheduleId };
            var res=DataFactory.Manage_TrainRepo().Create(t);
            return res;
        }

        public static bool Update(Manage_TrainModel obj)
        {
            Manage_Trains t = new Manage_Trains { Id = obj.Id, TrainId = obj.TrainId, StationId = obj.StationId, ScheduleId = obj.ScheduleId };
            return DataFactory.Manage_TrainRepo().Update(t);
        }

        public static bool Delete(int id)
        {
            return DataFactory.Manage_TrainRepo().Delete(id);
        }
    }
}

