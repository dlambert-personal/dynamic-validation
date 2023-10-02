using FluentValidation;
using FluentValidation.Validators;
using System.ComponentModel.DataAnnotations;

namespace Vehicle
{
    public class Vehicle
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string VIN { get; set; }
    }

    public class SearchVehicleValidator:AbstractValidator<Vehicle>
    {
        public SearchVehicleValidator()
        {

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