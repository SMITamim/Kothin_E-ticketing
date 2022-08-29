using BusinessLogic.BOs;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class TrainSearchService
    {
        public static List<SearchModel> TrainSearch(int _from, int _to)
        {
            var managetrains = DataFactory.Manage_TrainRepo().GetAll();
            var fromStation = (from t in managetrains
                               where t.StationId == _from
                               select t).ToList();
            var toStation = (from t in managetrains
                             where t.StationId == _to
                             select t).ToList();
            /*var data = (from t in managetrains where (t.StationId == _from || t.StationId == _to) && t.StationId == _from select 
                        new SearchModel { 
                            TrainId = t.Train.Id, 
                            TrainName = t.Train.Name, 
                            TrainType = t.Train.Category, 
                            ArraivalTime = t.Train_Schedules.ArraivalTime, 
                            DepartureTime = t.Train_Schedules.DepartureTime 
                        }).ToList();*/
            List<SearchModel> list=new List<SearchModel>();
            foreach (var from in fromStation)
            {
                foreach(var to in toStation)
                {
                    if(from.Train.Name.Equals(to.Train.Name))
                    {
                        list.Add(new SearchModel { TrainId=from.TrainId, TrainName=from.Train.Name, TrainType=from.Train.Category, ArraivalTime=from.Train_Schedules.ArraivalTime, DepartureTime= from.Train_Schedules.DepartureTime});
                    }
                }
            }
            return list;
        }
    }
}
