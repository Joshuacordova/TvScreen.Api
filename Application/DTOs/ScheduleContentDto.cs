using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class ScheduleContentDto
    {
        public Guid ScheduleId { get; set; }
        public string Title { get; set; }
        public string ChannelName { get; set; }
        public string ChannelCode { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

}
