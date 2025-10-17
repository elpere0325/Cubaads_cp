using Common;
using Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities 
{
    public class Pricing : Entity
    {
        public AppType app_type {  get; set; }
        public AdTypes ad_type { get; set; }
        public decimal cost_per_view { get; set; }
        public decimal payout_per_view { get; set; }


    }
}
