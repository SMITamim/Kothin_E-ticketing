using BusinessLogic.BOs;
using DataLayer;
using DataLayer.EF;
using System.Collections.Generic;

namespace BusinessLogic.Services
{
    public class AirplaneService
    {
        public static List<AirplaneModel> GetAll()
        {
            var data = DataFactory.AirplaneRepo().GetAll();
            List<AirplaneModel> airplane = new List<AirplaneModel>();
            foreach (var d in data)
            {
                airplane.Add(new AirplaneModel { Model = d.Model, Company = d.Company, Seatdata = d.SeatData });
            }
            return airplane;
        }

        public static AirplaneModel GetById(int id)
        {
            var data = DataFactory.AirplaneRepo().Get(id);
            if (data == null)
                return null;
            return new AirplaneModel
            {
                Model = data.Model,
                Company = data.Company,
                Seatdata = data.SeatData
            };
        }

        public static bool Create(AirplaneModel Airplane)
        {

            Airplane n = new Airplane { Model = Airplane.Model, Company = Airplane.Company, SeatData = Airplane.Seatdata }; ;
            return DataFactory.AirplaneRepo().Create(n);
        }

        public static bool Update(AirplaneModel Airplane)
        {

            Airplane n = new Airplane { Model = Airplane.Model, Company = Airplane.Company, SeatData = Airplane.Seatdata }; ;
            return DataFactory.AirplaneRepo().Update(n);
        }

        public static bool Delete(int id)
        {

            return DataFactory.AirplaneRepo().Delete(id);
        }


    }
}


