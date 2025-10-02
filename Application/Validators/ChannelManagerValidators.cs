using Application.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators
{
    public class ChannelManagerValidators: AbstractValidator<ChannelManagerDto>
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
}
