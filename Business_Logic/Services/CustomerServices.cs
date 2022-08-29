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
    public class CustomerServices
    {
        public static List<CustomerModel> GetAll()
        {
            var data = DataFactory.CustomerRepo().GetAll();
            List<CustomerModel> customer = new List<CustomerModel>();
            foreach (var d in data)
            {
                customer.Add(new CustomerModel { Id = d.Id, Name = d.Name, Dob = d.Dob, Password = d.Password, Username = d.Username, Bloodgroup = d.Bloodgroup, Address = d.Address, Email = d.Email, Nid = d.Nid, Phone = d.Phone, Maritalstatus = d.Maritalstatus, Gender = d.Gender });

            }
            return customer;
        }
        public static CustomerModel GetById(int id)
        {
            var data = DataFactory.CustomerRepo().Get(id);
            if (data == null)
                return null;
            return new CustomerModel
            {
                Name = data.Name,
                Dob = data.Dob,
                Password = data.Password,
                Username = data.Username,
                Bloodgroup = data.Bloodgroup,
                Address = data.Address,
                Email = data.Email,
                Nid = data.Nid,
                Phone = data.Phone,
                Maritalstatus = data.Maritalstatus,
                Gender = data.Gender
            };

        }
        public static bool Create(CustomerModel obj)
        {
            Customer t = new Customer { Name = obj.Name, Dob = obj.Dob, Password = obj.Password, Username = obj.Username, Bloodgroup = obj.Bloodgroup, Address = obj.Address, Email = obj.Email, Nid = obj.Nid, Phone = obj.Phone, Maritalstatus = obj.Maritalstatus, Gender = obj.Gender };
            return DataFactory.CustomerRepo().Create(t);
        }
        public static bool Update(CustomerModel obj)
        {
            Customer t = new Customer { Id = obj.Id, Name = obj.Name, Dob = obj.Dob, Password = obj.Password, Username = obj.Username, Bloodgroup = obj.Bloodgroup, Address = obj.Address, Email = obj.Email, Nid = obj.Nid, Phone = obj.Phone, Maritalstatus = obj.Maritalstatus, Gender = obj.Gender };
            return DataFactory.CustomerRepo().Update(t);
        }
        public static bool Delete(int id)
        {
            return DataFactory.CustomerRepo().Delete(id);
        }
    }
}
