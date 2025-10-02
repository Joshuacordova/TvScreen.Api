using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public partial class Schedule
    {
        public Guid ScheduleId { get; set; }
        public Guid ContentId { get; set; }
        public Guid ChannelId { get; set; }
        public DateTime AiringStart { get; set; }
        public DateTime AiringEnd { get; set; }
        public bool IsRecurring { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
