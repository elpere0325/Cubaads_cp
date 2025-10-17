using Common;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Business : CreatedEntityTime
    {
        [ForeignKey("user")]
        public Guid user_id {  get; set; }
        public User? user { get; set; }

        [Required, MaxLength(30)]
        public string business_name { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string contact_email { get; set; } = string.Empty;
        public decimal balance { get; set; }
        public string category { get; set; } = string.Empty;
        public ICollection<Ad> Ads { get; set; } = new List<Ad>();

    }
}
