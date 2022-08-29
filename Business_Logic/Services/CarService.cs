using BusinessLogic.BOs;
using DataLayer;
using DataLayer.EF;
using System.Collections.Generic;

namespace BusinessLogic.Services
{
    public class CarService
    {

        public static List<CarModel> GetAll()
        {

            var data = DataFactory.CarRepo().GetAll();
            List<CarModel> car = new List<CarModel>();
            foreach (var d in data)
            {
                car.Add(new CarModel { Ownername = d.Ownername, Ownerphone = d.Ownerphone, Owneremail = d.Owneremail, Drivername = d.Drivername, Driverphone = d.Driverphone, Brandname = d.Brandname, Category = d.Category, Isrent = d.Isrent, Regnumber = d.Regnumber });
            }
            return car;
        }

        public static bool Create(CarModel car)
        {

            Car n = new Car { Id = car.Id, Ownername = car.Ownername, Ownerphone = car.Ownerphone, Owneremail = car.Owneremail, Drivername = car.Drivername, Driverphone = car.Driverphone, Brandname = car.Brandname, Category = car.Category, Isrent = car.Isrent, Regnumber = car.Regnumber };
            return DataFactory.CarRepo().Create(n);
        }

        public static bool Update(CarModel car)
        {

            Car n = new Car { Id = car.Id, Ownername = car.Ownername, Ownerphone = car.Ownerphone, Owneremail = car.Owneremail, Drivername = car.Drivername, Driverphone = car.Driverphone, Brandname = car.Brandname, Category = car.Category, Isrent = car.Isrent, Regnumber = car.Regnumber };
            return DataFactory.CarRepo().Update(n);
        }

        public static bool Delete(int id)
        {

            return DataFactory.CarRepo().Delete(id);
        }

        public static CarModel GetById(int id)
        {

            var data = DataFactory.CarRepo().Get(id);
            if (data == null)
                return null;
            return new CarModel
            {
                Id = data.Id,
                Ownername = data.Ownername,
                Ownerphone = data.Ownerphone,
                Owneremail = data.Owneremail,
                Drivername = data.Drivername,
                Driverphone = data.Driverphone,
                Brandname = data.Brandname,
                Category = data.Category,
                Isrent = data.Isrent,
                Regnumber = data.Regnumber
            };
        }
    }

}

