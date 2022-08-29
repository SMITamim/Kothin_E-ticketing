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
    public class Train_ScheduleServices
    {
        public static List<Train_ScheduleModel> GetAll()
        {
            var data = DataFactory.Train_ScheduleRepo().GetAll();
            List<Train_ScheduleModel> schedule = new List<Train_ScheduleModel>();
            foreach (var d in data)
            {
                schedule.Add(new Train_ScheduleModel { Id = d.Id, ArraivalTime = d.ArraivalTime, DepartureTime = d.DepartureTime });
            }
            return schedule;
        }

        public static Train_ScheduleModel GetById(int id)
        {
            var data = DataFactory.Train_ScheduleRepo().Get(id);
            if (data == null)
                return null;
            return new Train_ScheduleModel
            {
                Id = data.Id,
                ArraivalTime = data.ArraivalTime,
                DepartureTime = data.DepartureTime
            };
        }

        public static bool Create(Train_ScheduleModel obj)
        {
            Train_Schedules t = new Train_Schedules { ArraivalTime = obj.ArraivalTime, DepartureTime = obj.DepartureTime };
            return DataFactory.Train_ScheduleRepo().Create(t);
        }

        public static bool Update(Train_ScheduleModel obj)
        {
            Train_Schedules t = new Train_Schedules { Id = obj.Id, ArraivalTime = obj.ArraivalTime, DepartureTime = obj.DepartureTime };
            return DataFactory.Train_ScheduleRepo().Update(t);
        }

        public static bool Delete(int id)
        {
            return DataFactory.Train_ScheduleRepo().Delete(id);
        }
    }
}