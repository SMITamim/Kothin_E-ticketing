using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.BOs
{
    public class SearchModel
    {
        public int TrainId { get; set; }
        public string TrainName { get; set; }
        public string TrainType { get; set; }
        public string DepartureTime { get; set; }
        public string ArraivalTime { get; set; }
    }
}
