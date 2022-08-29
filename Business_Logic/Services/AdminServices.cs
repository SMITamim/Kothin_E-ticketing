using BusinessLogic.BOs;
using DataLayer;
using DataLayer.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class AdminServices
    {
        public static List<AdminModel>GetAll()
        {
            var data = DataFactory.AdminRepo().GetAll();
            List<AdminModel> admin = new List<AdminModel>();
            foreach (var d in data)
            {
                admin.Add(new AdminModel { Id = d.Id, Name = d.Name, Username = d.Username, Password = d.Password, Bloodgroup = d.Bloodgroup, Dob = d.Dob });
            }
            return admin;


        }
        public static AdminModel GetById(int id)
        {
            var data = DataFactory.AdminRepo().Get(id);
            if (data == null)
                return null;
            return new AdminModel
            {
                Name = data.Name,
                Username = data.Username,
                Password = data.Password,
                Bloodgroup = data.Bloodgroup,
                Dob = data.Dob
            };

        }
        public static bool Create(AdminModel obj)
        {
            Admin t = new Admin { Name = obj.Name, Username = obj.Username, Password = obj.Password, Bloodgroup = obj.Bloodgroup, Dob = obj.Dob };
            return DataFactory.AdminRepo().Create(t);
        }
        public static bool Update(AdminModel obj)
        {
            Admin t = new Admin { Id = obj.Id, Name = obj.Name, Username = obj.Username, Password = obj.Password, Bloodgroup = obj.Bloodgroup, Dob = obj.Dob };
            return DataFactory.AdminRepo().Update(t);
        }
        public static bool Delete(int id)
        {
            return DataFactory.AdminRepo().Delete(id);
        }
    }
}
