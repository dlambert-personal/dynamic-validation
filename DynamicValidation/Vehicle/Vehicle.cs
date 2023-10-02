using FluentValidation;
using FluentValidation.Validators;
using System.ComponentModel.DataAnnotations;

namespace Vehicle
{
    public class Vehicle
    {
        public string? Make { get; set; }
        public string? Model { get; set; }
        public string? VIN { get; set; }
    }

    public class SearchVehicleValidator:AbstractValidator<Vehicle>
    {
        public SearchVehicleValidator()
        {
            RuleFor(v => v.Make).NotNull()
              .When(v => string.IsNullOrEmpty(v.Model) && string.IsNullOrEmpty(v.VIN))
              .WithMessage("At least one search criteria is required(1)");

            RuleFor(v => v.Model).NotNull()
              .When(v => v.Model != null)
              .WithMessage("At least one search criteria is required(2)");

            RuleFor(v => v.VIN).NotNull()
              .When(v => v.Make != null && v.Model != null)
              .WithMessage("At least one search criteria is required(3)");
        }
    }
    public class ListingVehicleValidator : AbstractValidator<Vehicle>
    {
        public ListingVehicleValidator()
        {
            RuleFor(vehicle => vehicle.Make).NotNull();
            RuleFor(vehicle => vehicle.Model).NotNull();
            RuleFor(vehicle => vehicle.VIN).NotNull();
        }
    }
}