using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class AdView: CreatedEntityTime
    {
        [ForeignKey("ad")]
        public Guid ad_id {  get; set; }
        public Ad? ad { get; set; }

        [ForeignKey("app_client")]
        public Guid app_id { get; set; }
        public AppClient? app_client { get; set; }

        public string device_id { get; set; } = string.Empty;
        public decimal earned {  get; set; }
        public decimal cost { get; set; }

    }
}
