using Domain.Common;
using Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Ad : CreatedEntityTime
    {
        public Guid business_id {  get; set; }
        public Business business { get; set; }
        public string media_url { get; set; }
        public MediaType media_type { get; set; }
        public string description { get; set; }
        public string target_url { get; set; }
        public Status status { get; set; }
        public AdTypes ad_type { get; set; }



        public Ad(Business business, string media_url, MediaType media_type,
            string description, string target_url, Status status, AdTypes ad_type)
        {           
            this.business = business;
            business_id = business.id;
            this.media_url = media_url;
            this.media_type = media_type;
            this.description = description;
            this.target_url = target_url;
            this.status = status;
            this.ad_type = ad_type;
        }
    }
}
