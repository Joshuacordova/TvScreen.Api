using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Cast
    {
        public Guid CastId { get; set; }
        public Guid ContentId { get; set; }
        public string? ActorName { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
