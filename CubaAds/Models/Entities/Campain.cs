using Common;
using Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Campain : CreatedEntityTime
    {
        [ForeignKey("ad")]
        public Guid ad_id { get; set; }
        public Ad? ad { get; set; }

        public DateTime end_date { get; set; }
        public int max_views { get; set; }
        public int view_count { get; set; }


        public AppType[]? allowed_app_type { get; set; }

    }
}
