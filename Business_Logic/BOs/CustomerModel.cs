using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.BOs
{
    public class CustomerModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Dob { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Bloodgroup { get; set; }
        [Required]
        public string Address{ get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public int Nid { get; set; }
        [Required]
        public int Phone { get; set; }
        [Required]
        public string Maritalstatus { get; set; }
        [Required]
        public string Gender { get; set; }

    }
}
