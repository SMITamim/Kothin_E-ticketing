using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.BOs
{
    public class BusModel
    {
        public int Id { get; set; }
        public string Regnumber { get; set; }
        public string Ownername { get; set; }
        public string Ownernumber { get; set; }
        public int Ownerphone{ get; set; }
        public string Owneremail { get; set; }
        public string Drivername{ get; set; }
        public int Driverphone{ get; set; }
        public string Isdoubledecker { get; set; }
        public string Category { get; set; }
        public string Coach { get; set; }

    }
}
