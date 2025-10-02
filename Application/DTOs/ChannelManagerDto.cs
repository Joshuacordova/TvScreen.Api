using AutoMapper;
using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class ChannelManagerDto
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

    public class ChannelManagerValidators : AbstractValidator<ChannelManagerDto>
    {
        public ChannelManagerValidators()
        {
            RuleFor(c => c.ChannelName)
                .NotEmpty()
                .WithMessage("ChannelName is required.");
            RuleFor(c => c.ChannelCode)
                .NotEmpty()
                .WithMessage("ChannelCode is required.");
            RuleFor(c => c.Country)
                .NotEmpty()
                .WithMessage("Country is required.");
            RuleFor(c => c.Language)
                .NotEmpty()
                .WithMessage("Organization is required.");
            RuleFor(c => c.LogoUrl)
                .NotEmpty()
                .WithMessage("Organization is required.");
        }
    }

    public class ChannelManagerMappingProfile : Profile
    {
        public ChannelManagerMappingProfile()
        {
            CreateMap<ChannelManager, ChannelManagerDto>()
                .ForMember(dest => dest.ChannelId, opt => opt.MapFrom(src => src.ChannelId))
                .ForMember(dest => dest.ChannelName, opt => opt.MapFrom(src => src.ChannelName))
                .ForMember(dest => dest.ChannelCode, opt => opt.MapFrom(src => src.ChannelCode))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country))
                .ForMember(dest => dest.Language, opt => opt.MapFrom(src => src.Language))
                .ForMember(dest => dest.LogoUrl, opt => opt.MapFrom(src => src.LogoUrl))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => src.UpdatedAt));

            CreateMap<ChannelManagerDto, ChannelManager>()
                .ForMember(dest => dest.ChannelId, opt => opt.MapFrom(src => src.ChannelId))
                .ForMember(dest => dest.ChannelName, opt => opt.MapFrom(src => src.ChannelName))
                .ForMember(dest => dest.ChannelCode, opt => opt.MapFrom(src => src.ChannelCode))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country))
                .ForMember(dest => dest.Language, opt => opt.MapFrom(src => src.Language))
                .ForMember(dest => dest.LogoUrl, opt => opt.MapFrom(src => src.LogoUrl))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => src.UpdatedAt));
        }
    }
}
