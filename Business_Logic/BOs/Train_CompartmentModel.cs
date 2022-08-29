using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.BOs
{
    public class Train_CompartmentModel
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int TrainId { get; set; }
        public string Data { get; set; }
    }
}
