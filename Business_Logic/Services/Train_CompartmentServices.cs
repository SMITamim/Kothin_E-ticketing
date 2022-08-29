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
    public class Train_CompartmentServices
    {
        public static List<Train_CompartmentModel> GetAll()
        {
            var data = DataFactory.Train_CompartmentRepo().GetAll();
            List<Train_CompartmentModel> compartment = new List<Train_CompartmentModel>();
            foreach (var d in data)
            {
                compartment.Add(new Train_CompartmentModel { Id = d.Id, Type = d.Type, TrainId = (int)d.TrainId, Data=d.Data });
            }
            return compartment;
        }

        public static Train_CompartmentModel GetById(int id)
        {
            var data = DataFactory.Train_CompartmentRepo().Get(id);
            if (data == null)
                return null;
            return new Train_CompartmentModel
            {
                Id = data.Id,
                Type = data.Type,
                TrainId = (int)data.TrainId,
                Data = data.Data,
            };
        }

        public static bool Create(Train_CompartmentModel obj)
        {
            Train_Compartments t = new Train_Compartments { Type = obj.Type, TrainId = obj.TrainId, Data=obj.Data };
            return DataFactory.Train_CompartmentRepo().Create(t);
        }

        public static bool Update(Train_CompartmentModel obj)
        {
            Train_Compartments t = new Train_Compartments { Id = obj.Id, Type = obj.Type, TrainId = obj.TrainId, Data = obj.Data };
            return DataFactory.Train_CompartmentRepo().Update(t);
        }

        public static bool Delete(int id)
        {
            return DataFactory.Train_CompartmentRepo().Delete(id);
        }

        public static List<Train_CompartmentModel> Search(int id, string type)
        {
            var compartments = DataFactory.Train_CompartmentRepo().GetAll();
            
            List<Train_CompartmentModel> list = new List<Train_CompartmentModel>();
            var data = (from c in compartments where c.Type == type && c.TrainId==id select c).ToList();
            foreach(var d in data)
            {
                list.Add(new Train_CompartmentModel { TrainId = (int)d.TrainId, Id = d.Id, Type = d.Type, Data = d.Data });
            }
            return list;
        }
    }
}
