using Domain.Common;
using Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Pricing : Entity
    {
        public AppType app_type {  get; set; }
        public AdTypes ad_type { get; set; }
        public decimal cost_per_view { get; set; }
        public decimal payout_per_view { get; set; }


        protected Pricing() { }


        public Pricing (AppType app_type, AdTypes ad_type,  decimal cost_per_view, decimal payout_per_view)
        {
            this.app_type = app_type;
            this.ad_type = ad_type;
            this.cost_per_view = cost_per_view;
            this.payout_per_view= payout_per_view;
        }
    }
}
