using DataLayer.EF;
using DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repos
{
    internal class TokenRepo : IRepo<Token, int>
    {
        ETicketEntities db;
        public TokenRepo(ETicketEntities db)
        {
            this.db = db;
        }
        public bool Create(Token obj)
        {
            try
            {
                db.Tokens.Add(obj);
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
                db.Tokens.Remove(Get(id));
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Token Get(int id)
        {
            return db.Tokens.Where(x=>x.User==id).SingleOrDefault();
        }

        public List<Token> GetAll()
        {
            return db.Tokens.ToList();
        }

        public bool Update(Token obj)
        {
            try
            {
                Token old = db.Tokens.Where(x => x.Id == obj.Id).SingleOrDefault();
                if (old != null)
                {
                    db.Entry(old).CurrentValues.SetValues(obj);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
