using System.ComponentModel.DataAnnotations;
using Vehicle;

namespace DemoTests
{
    [TestClass]
    public class DemoTests
    {
        /// <summary>
        /// Test depends on data annotations - see accomanying article.
        /// </summary>
        [Ignore]
        [TestMethod]
        public void TestBlankVehicleWithDataAnnotations()
        {
            var v = new Vehicle.Vehicle();
            Assert.IsNotNull(v);
            ValidationContext context = new ValidationContext(v);
            List<ValidationResult> validationResults = new List<ValidationResult>();
            bool valid = Validator.TryValidateObject(v, context, validationResults, true);
            Assert.Inconclusive();  //since data annotatiosn now removed
        }

        /// <summary>
        /// Test using fluent validation - see accomanying article.
        /// </summary>
        [TestMethod]
        public void TestBlankVehicleWithFluentValidations()
        {
            var v = new Vehicle.Vehicle();
            Assert.IsNotNull(v);
            VehicleValidator vvalidator = new VehicleValidator();
            var result = vvalidator.Validate(v);

            Assert.IsFalse(result.IsValid);
        }
    }
}