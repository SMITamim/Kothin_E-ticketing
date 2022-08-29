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
    public class Train_StationService
    {
        public static List<Train_StationModel> GetAll()
        {
            var data = DataFactory.Train_StationRepo().GetAll();
            List<Train_StationModel> stations = new List<Train_StationModel>();
            foreach (var d in data)
            {
                stations.Add(new Train_StationModel { Id = d.Id, Name = d.Name });
            }
            return stations;
        }

        public static Train_StationModel GetById(int id)
        {
            var data = DataFactory.Train_StationRepo().Get(id);
            if (data == null)
                return null;
            return new Train_StationModel
            {
                Id = data.Id,
                Name = data.Name
            };
        }

        public static bool Create(Train_StationModel obj)
        {
            Train_Stations t = new Train_Stations { Name = obj.Name };
            return DataFactory.Train_StationRepo().Create(t);
        }

        public static bool Update(Train_StationModel obj)
        {
            Train_Stations t = new Train_Stations { Id = obj.Id, Name = obj.Name };
            return DataFactory.Train_StationRepo().Update(t);
        }

        public static bool Delete(int id)
        {
            return DataFactory.Train_StationRepo().Delete(id);
        }
    }
}
