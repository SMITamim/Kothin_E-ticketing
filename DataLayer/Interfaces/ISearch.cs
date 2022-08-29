using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface ISearch<CLASS>
    {
        List<CLASS> Search(string from, string to);
    }
}
