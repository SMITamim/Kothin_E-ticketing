using BusinessLogic.BOs;
using DataLayer;
using DataLayer.EF;
using System.Collections.Generic;

namespace Business_Logic.Services
{
    public class Airple_SchedulesServices
    {
        public static List<Airple_SchedulesModel> GetAll()
        {
            var data = DataFactory.Airple_ScheduleRepo().GetAll();
            List<Airple_SchedulesModel> schedule = new List<Airple_SchedulesModel>();
            foreach (var d in data)
            {
                schedule.Add(new Airple_SchedulesModel { Id = d.Id, ArrivalTime = d.ArrivalTime, DepartureTime = d.DepartureTime });
            }
            return schedule;
        }

        public static Airple_SchedulesModel GetById(int id)
        {
            var data = DataFactory.Airple_ScheduleRepo().Get(id);
            if (data == null)
                return null;
            return new Airple_SchedulesModel
            {
                Id = data.Id,
                ArrivalTime = data.ArrivalTime,
                DepartureTime = data.DepartureTime
            };
        }

        public static bool Create(Airple_SchedulesModel obj)
        {
            Airple_Schedules t = new Airple_Schedules { ArrivalTime = obj.ArrivalTime, DepartureTime = obj.DepartureTime };
            return DataFactory.Airple_ScheduleRepo().Create(t);
        }

        public static bool Update(Airple_SchedulesModel obj)
        {
            Airple_Schedules t = new Airple_Schedules { Id = obj.Id, ArrivalTime = obj.ArrivalTime, DepartureTime = obj.DepartureTime };
            return DataFactory.Airple_ScheduleRepo().Update(t);
        }

        public static bool Delete(int id)
        {
            return DataFactory.Train_ScheduleRepo().Delete(id);
        }
    }
}

