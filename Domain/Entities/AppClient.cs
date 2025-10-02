using Domain.Common;
using Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AppClient : CreatedEntityTime
    {
        public Guid user_id {  get; set; }
        public User user { get; set; }
        public string app_client_name { get; set; }
        public AppType type { get; set; }
        public string api_key { get; set; }
        public decimal balance { get; set; }



       
        

        public AppClient(User user, string app_client_name,  AppType type, string api_key, decimal balance)
        { 
            this.user = user;
            user_id = user.id;
            this.app_client_name = app_client_name;
            this.type = type;
            this.api_key = api_key;
            this.balance = balance;
        }

    }
}
