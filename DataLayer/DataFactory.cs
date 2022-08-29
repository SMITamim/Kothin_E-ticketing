using DataLayer.EF;
using DataLayer.Interfaces;
using DataLayer.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DataFactory
    {
        static ETicketEntities db = new ETicketEntities();

        public static IRepo<Train, int> TrainRepo()
        {
            return new TrainRepo(db);
        }

        public static IRepo<Train_Schedules, int> Train_ScheduleRepo()
        {
            return new Train_ScheduleRepo(db);
        }

        public static IRepo<Train_Stations, int> Train_StationRepo()
        {
            return new Train_StationRepo(db);
        }
        public static IRepo<Ticket, int> TicketRepo()
        {
            return new TicketRepo(db);
        }
        public static IRepo<Train_Compartments, int> Train_CompartmentRepo()
        {
            return new Train_CompartmentRepo(db);
        }
        public static IRepo<Manage_Trains, int> Manage_TrainRepo()
        {
            return new Manage_TrainRepo(db);
        }

        public static IRepo<Airple_Schedules, int> Airple_ScheduleRepo()
        {
            return new Airple_SchedulesRepo(db);
        }

        public static IRepo<Airplane, int> AirplaneRepo()
        {
            return new AirplaneRepo(db);
        }

        public static IRepo<Car, int> CarRepo()
        {
            return new CarRepo(db);
        }
        public static IRepo<Admin, int> AdminRepo()
        {
            return new AdminRepo(db);
        }
        public static IRepo<Bus, int> BusRepo()
        {
            return new BusRepo(db);
        }
        public static IRepo<Customer, int> CustomerRepo()
        {
            return new CustomerRepo(db);
        }

        public static IAuthRepo<Customer> AuthRepo()
        {
            return new CustomerRepo(db);
        }

        public static IRepo<Token, int> TokenRepo()
        {
            return new TokenRepo(db);
        }
    }
}
