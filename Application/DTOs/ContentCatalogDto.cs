using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class ContentCatalogDto
    {
        public Guid ContentId { get; set; }
        public string Title { get; set; } = null!;
        public string Type { get; set; } = null!;
        public GenreEnum Genre { get; set; }
        public string Language { get; set; } = null!;
        public string CountryOfOrigin { get; set; } = null!;
        public DateTime? ReleaseDate { get; set; }
        public int? DurationMinutes { get; set; }
        public string? Rating { get; set; }
        public string? Synopsis { get; set; }
        public string? Cast { get; set; }
        public string? Director { get; set; }
        public string? ProductionCompany { get; set; }
        public string? PostUrl { get; set; }
        public string? TrailerUrl { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    public class ContentCatalogValidator : AbstractValidator<ContentCatalogDto>
    {
        public ContentCatalogValidator()
        {
            RuleFor(c => c.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(200).WithMessage("Title cannot exceed 200 characters.");
            RuleFor(c => c.Type)
                .NotEmpty().WithMessage("Type is required.")
                .MaximumLength(50).WithMessage("Type cannot exceed 50 characters.");
            RuleFor(c => c.Genre)
                .IsInEnum().WithMessage("Invalid genre.");
            RuleFor(c => c.Language)
                .NotEmpty().WithMessage("Language is required.")
                .MaximumLength(100).WithMessage("Language cannot exceed 100 characters.");
            RuleFor(c => c.CountryOfOrigin)
                .NotEmpty().WithMessage("Country of Origin is required.")
                .MaximumLength(100).WithMessage("Country of Origin cannot exceed 100 characters.");
            RuleFor(c => c.ReleaseDate)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Release Date cannot be in the future.")
                .When(c => c.ReleaseDate.HasValue);
            RuleFor(c => c.DurationMinutes)
                .GreaterThan(0).WithMessage("Duration must be greater than 0 minutes.")
                .When(c => c.DurationMinutes.HasValue);
            RuleFor(c => c.Rating)
                .MaximumLength(10).WithMessage("Rating cannot exceed 10 characters.")
                .When(c => !string.IsNullOrEmpty(c.Rating));
            RuleFor(c => c.Synopsis)
                .MaximumLength(1000).WithMessage("Synopsis cannot exceed 1000 characters.")
                .When(c => !string.IsNullOrEmpty(c.Synopsis));
            RuleFor(c => c.Cast)
                .MaximumLength(500).WithMessage("Cast cannot exceed 500 characters.")
                .When(c => !string.IsNullOrEmpty(c.Cast));
            RuleFor(c => c.Director)
                .MaximumLength(200).WithMessage("Director cannot exceed 200 characters.")
                .When(c => !string.IsNullOrEmpty(c.Director));
            RuleFor(c => c.ProductionCompany)
                .MaximumLength(200).WithMessage("Production Company cannot exceed 200 characters.")
                .When(c => !string.IsNullOrEmpty(c.ProductionCompany));
            RuleFor(c => c.PostUrl)
                .Must(uri => Uri.IsWellFormedUriString(uri, UriKind.Absolute)).WithMessage("Post URL must be valid");
        }
    }

    public class ContentCatalogMappingProfile: Profile
    {
        public ContentCatalogMappingProfile()
        {
            CreateMap<ContentCatalog, ContentCatalogDto>()
                .ForMember(dest => dest.ContentId, opt => opt.MapFrom(src => src.ContentId))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre))
                .ForMember(dest => dest.Language, opt => opt.MapFrom(src => src.Language))
                .ForMember(dest => dest.CountryOfOrigin, opt => opt.MapFrom(src => src.CountryOfOrigin))
                .ForMember(dest => dest.ReleaseDate, opt => opt.MapFrom(src => src.ReleaseDate))
                .ForMember(dest => dest.DurationMinutes, opt => opt.MapFrom(src => src.DurationMinutes))
                .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => src.Rating))
                .ForMember(dest => dest.Synopsis, opt => opt.MapFrom(src => src.Synopsis))
                .ForMember(dest => dest.Cast, opt => opt.MapFrom(src => src.Cast))
                .ForMember(dest => dest.Director, opt => opt.MapFrom(src => src.Director))
                .ForMember(dest => dest.ProductionCompany, opt => opt.MapFrom(src => src.ProductionCompany))
                .ForMember(dest => dest.PostUrl, opt => opt.MapFrom(src => src.PostUrl))
                .ForMember(dest => dest.TrailerUrl, opt => opt.MapFrom(src => src.TrailerUrl))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => src.UpdatedAt));

            CreateMap<ContentCatalogDto, ContentCatalog>()
                .ForMember(dest => dest.ContentId, opt => opt.MapFrom(src => src.ContentId))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre))
                .ForMember(dest => dest.Language, opt => opt.MapFrom(src => src.Language))
                .ForMember(dest => dest.CountryOfOrigin, opt => opt.MapFrom(src => src.CountryOfOrigin))
                .ForMember(dest => dest.ReleaseDate, opt => opt.MapFrom(src => src.ReleaseDate))
                .ForMember(dest => dest.DurationMinutes, opt => opt.MapFrom(src => src.DurationMinutes))
                .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => src.Rating))
                .ForMember(dest => dest.Synopsis, opt => opt.MapFrom(src => src.Synopsis))
                .ForMember(dest => dest.Cast, opt => opt.MapFrom(src => src.Cast))
                .ForMember(dest => dest.Director, opt => opt.MapFrom(src => src.Director))
                .ForMember(dest => dest.ProductionCompany, opt => opt.MapFrom(src => src.ProductionCompany))
                .ForMember(dest => dest.PostUrl, opt => opt.MapFrom(src => src.PostUrl))
                .ForMember(dest => dest.TrailerUrl, opt => opt.MapFrom(src => src.TrailerUrl))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => src.UpdatedAt));


        }
    }
}
