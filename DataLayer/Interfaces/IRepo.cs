using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface IRepo<CLASS, ParmType>
    {
        List<CLASS> GetAll();
        CLASS Get(ParmType id);
        bool Create(CLASS obj);
        bool Update(CLASS obj);
        bool Delete(ParmType id);
    }
}
