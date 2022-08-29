using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.EF;
using DataLayer.Interfaces;

namespace DataLayer.Repos
{
    internal class CustomerRepo : IRepo<Customer, int>, IAuthRepo<Customer>
    {
        ETicketEntities db;
        public CustomerRepo(ETicketEntities db)
        {
            this.db = db;
        }
        public bool Create(Customer obj)
        {
            try
            {
                db.Customers.Add(obj);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool Delete(int id)
        {
            try
            {
                db.Customers.Remove((from n in db.Customers where n.Id == id select n).SingleOrDefault());
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Customer Get(int id)
        {
            return db.Customers.Find(id);
        }

        public List<Customer> GetAll()
        {
            return db.Customers.ToList();
        }

        public bool Update(Customer obj)
        {
            Customer old = db.Customers.Where(x => x.Id == obj.Id).SingleOrDefault();
            if (old != null)
            {
                db.Entry(old).CurrentValues.SetValues(obj);
                db.SaveChanges();
                return true;
            }
            return false;
        }
        public Customer Validate(string username, string password)
        {
            return db.Customers.Where(x=>x.Username.Equals(username) && x.Password.Equals(password)).SingleOrDefault();
        }
    }
}
