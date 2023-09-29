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

    public class VehicleValidator:AbstractValidator<Vehicle>
    {
        public VehicleValidator()
        {
            RuleFor(vehicle => vehicle.Make).NotNull();
        }
    }
}