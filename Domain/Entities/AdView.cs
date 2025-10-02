using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AdView: CreatedEntityTime
    {
        public Guid ad_id {  get; set; }
        public Ad ad { get; set; }
        public Guid app_id { get; set; }
        public AppClient app_client { get; set; }
        public string device_id { get; set; }
        public decimal earned {  get; set; }
        public decimal cost { get; set; }





        public AdView(Ad ad, AppClient app_client, string device_id, decimal earned, decimal cost) 
        { 
            this.ad= ad;
            ad_id = ad.id;           
            this.app_client= app_client;
            app_id = app_client.id;
            this.device_id= device_id;
            this.earned= earned;
            this.cost= cost;
        }
    }
}
