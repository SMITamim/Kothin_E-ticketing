using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.BOs
{
    public class TokenModel
    {
        public int Id { get; set; }
        public string Token1 { get; set; }
        public string Exp { get; set; }
        public int User { get; set; }
    }
}
