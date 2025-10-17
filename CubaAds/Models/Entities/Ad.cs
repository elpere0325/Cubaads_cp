using Common;
using Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Ad : CreatedEntityTime
    {
        [ForeignKey("business")]
        public Guid business_id {  get; set; }
        public Business? business { get; set; }

        [Required]
        public string media_url { get; set; } = string.Empty;

        [Required]
        public MediaType media_type { get; set; }

        public Status status { get; set; }
        public AdTypes ad_type { get; set; }

        [MaxLength(200)]
        public string description { get; set; } = string.Empty;

        public string target_url { get; set; } = string.Empty;

        public ICollection<AdView> Adviews { get; set; } = new List<AdView>();
        public ICollection<Campain> Campains { get; set;} = new List<Campain>();
        public ICollection<ClickEvent> ClickEvents { get; set; } = new List<ClickEvent>();

    }
}
