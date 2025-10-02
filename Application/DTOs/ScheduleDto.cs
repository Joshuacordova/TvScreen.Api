using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public partial class ScheduleDto
    {
        public Guid ScheduleId { get; set; }
        public Guid? ContentId { get; set; }
        public Guid ChannelId { get; set; }
        public DateTime? AiringStart { get; set; }
        public DateTime? AiringEnd { get; set; }
        public bool IsRecurring { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    public class ScheduleMappingProfile: Profile
    {
        public ScheduleMappingProfile()
        {
            CreateMap<Schedule, ScheduleDto>()
                .ForMember(dest => dest.ScheduleId, opt => opt.MapFrom(src => src.ScheduleId))
                .ForMember(dest => dest.ContentId, opt => opt.MapFrom(src => src.ContentId))
                .ForMember(dest => dest.ChannelId, opt => opt.MapFrom(src => src.ChannelId))
                .ForMember(dest => dest.AiringStart, opt => opt.MapFrom(src => src.AiringStart))
                .ForMember(dest => dest.AiringEnd, opt => opt.MapFrom(src => src.AiringEnd))
                .ForMember(dest => dest.IsRecurring, opt => opt.MapFrom(src => src.IsRecurring))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.UpdatedAt));

            CreateMap<ScheduleDto, Schedule>()
                .ForMember(dest => dest.ScheduleId, opt => opt.MapFrom(src => src.ScheduleId))
                .ForMember(dest => dest.ContentId, opt => opt.MapFrom(src => src.ContentId))
                .ForMember(dest => dest.ChannelId, opt => opt.MapFrom(src => src.ChannelId))
                .ForMember(dest => dest.AiringStart, opt => opt.MapFrom(src => src.AiringStart))
                .ForMember(dest => dest.AiringEnd, opt => opt.MapFrom(src => src.AiringEnd))
                .ForMember(dest => dest.IsRecurring, opt => opt.MapFrom(src => src.IsRecurring))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.UpdatedAt));
        }
    }
}
