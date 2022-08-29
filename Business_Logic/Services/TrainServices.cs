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
    public class TrainServices
    {
        public static List<TrainModel> GetAll()
        {
            var data = DataFactory.TrainRepo().GetAll();
            List<TrainModel> train = new List<TrainModel>();
            foreach (var d in data)
            {
                train.Add(new TrainModel {Id=d.Id, Name = d.Name, Category = d.Category, Number = d.Number });
            }
            return train;
        }

        public static TrainModel GetById(int id)
        {
            var data = DataFactory.TrainRepo().Get(id);
            if (data == null)
                return null;
            return new TrainModel
            {
                Name = data.Name,
                Category = data.Category,
                Number = data.Number
            };
        }

        public static bool Create(TrainModel obj)
        {
            Train t = new Train { Name = obj.Name, Category = obj.Category, Number = obj.Number };
            return DataFactory.TrainRepo().Create(t);
        }

        public static bool Update(TrainModel obj)
        {
            Train t = new Train { Id=obj.Id, Name = obj.Name, Category = obj.Category, Number = obj.Number };
            return DataFactory.TrainRepo().Update(t);
        }

        public static bool Delete(int id)
        {
            return DataFactory.TrainRepo().Delete(id);
        }
    }
}
