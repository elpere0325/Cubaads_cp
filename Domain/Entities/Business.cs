using Domain.Common;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Business : CreatedEntityTime
    {
        public Guid user_id {  get; set; }
        public User user { get; set; }
        public string business_name { get; set; }
        public string contact_email { get; set; }
        public decimal balance { get; set; }
        public string category { get; set; }
        public ICollection<Ad> Ads { get; set; } = new List<Ad>();


      


        public Business( User user, string business_name, string contact_email, decimal balance, string category) 
        {            
            this.user = user;
            user_id = user.id;
            this.business_name = business_name;
            this.contact_email = contact_email;
            this.balance = balance;
            this.category = category;
        }
    }
}
