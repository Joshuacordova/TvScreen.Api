using Application.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators
{
    public class ContentCatalogValidator: AbstractValidator<ContentCatalogDto>
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
}
