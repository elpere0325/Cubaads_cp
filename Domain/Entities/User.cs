using Domain.Common;
using Domain.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User : CreatedEntityTime
    {
        [Required, EmailAddress]
        public string email { get; set; } = string.Empty;

        [Required]
        public string password { get; set; } = string.Empty;

        [Required]
        public Rol rol { get; set; }
        public ICollection<Business> Businesses { get; set; } = new List<Business>();
        public ICollection<AppClient> AppClients { get; set; } = new List<AppClient>();


  

        public User(String email, string password, Rol rol) 
        {
            this.email = email;
            this.password = password;
            this.rol = rol;
        }
    }
}
