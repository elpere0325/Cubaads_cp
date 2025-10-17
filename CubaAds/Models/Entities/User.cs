using Common;
using Types;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities 
{
    public class User : CreatedEntityTime
    {
        [Required, EmailAddress]
        public string email { get; set; } = string.Empty;

        [Required]
        public string password { get; set; } = string.Empty;

        [Required]
        public Rol rol { get; set; }

        public string refresh_token { get; set; } = string.Empty;
        public DateTime? refresh_token_expire { get; set; }
        public ICollection<Business> Businesses { get; set; } = new List<Business>();
        public ICollection<AppClient> AppClients { get; set; } = new List<AppClient>();

    }
}
