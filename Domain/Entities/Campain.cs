using Domain.Common;
using Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Campain : CreatedEntityTime
    {
        public Guid ad_id { get; set; }
        public Ad ad { get; set; }
        public DateTime end_date { get; set; }
        public int max_views { get; set; }
        public int view_count { get; set; }
        public AppType[] allowed_app_type { get; set; }
        

     

        public Campain(Ad ad, int max_views,int view_count, AppType[] allowed_app_type)
        {           
            this.ad = ad;
            ad_id = ad.id;
            this.max_views = max_views;
            this.view_count = view_count;
            this.allowed_app_type = allowed_app_type;
            
        }

    }
}
