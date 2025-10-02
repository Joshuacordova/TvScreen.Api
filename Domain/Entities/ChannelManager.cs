using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public partial class ChannelManager
    {
        public Guid ChannelId { get; set; }
        public string ChannelName { get; set; } = null!;
        public string ChannelCode { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string Language { get; set; } = null!;
        public string LogoUrl { get; set; } = null!;
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
