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
    public class AppClient : CreatedEntityTime
    {
        [ForeignKey("user")]
        public Guid user_id {  get; set; }
        public User? user { get; set; }

        [MaxLength(30)]
        public string app_client_name { get; set; } = string.Empty;

        public AppType app_type { get; set; }

        [Required]
        public string api_key { get; set; } = string.Empty;
        public decimal balance { get; set; }
        public ICollection<AdView> AdViews { get; set; } = new List<AdView>();
        public ICollection<ClickEvent> ClickEvents { get; set; } = new List<ClickEvent>();

    }
}
