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
    public class AuthServices
    {
        public static string LoginUser(string username, string password)
        {
            var user = DataFactory.AuthRepo().Validate(username,password);
            if (user == null)
                return null;
            else
            {
                Guid uid = Guid.NewGuid();  //this will creaet a UID
                string user2 = user.Id+","+"customer"; //user ID And Role
                var bytes = Encoding.UTF8.GetBytes(user2);  //Convert it to Byte
                var encoded = Convert.ToBase64String(bytes);    //Convert it to Base64
                var t = uid.ToString() + "." + encoded; //concate uid with encoded id role
                Token token = new Token { Token1 = t, User = user.Id, Exp = DateTime.Now.AddHours(5).ToString() };
                var existing = DataFactory.TokenRepo().Get(user.Id);
                if(existing==null)
                {
                    DataFactory.TokenRepo().Create(token);
                }
                else
                {
                    DataFactory.TokenRepo().Update(token);
                }  
                return t;
            }
        }

        public static bool CheckToken(string token)
        {
            var t = token.Split('.')[0];
            var encoded = token.Split('.')[1];
            var id_role = Encoding.UTF8.GetString(Convert.FromBase64String(encoded));
            var id = Int32.Parse(id_role.Split(',')[0]);
            var dbToken = DataFactory.TokenRepo().Get(id);
            if (dbToken == null || !dbToken.Token1.Equals(token))
                return false;
            else
                return true;
        }
    }
}
