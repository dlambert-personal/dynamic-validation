using System.ComponentModel.DataAnnotations;
using Vehicle;

namespace DemoTests
{
    [TestClass]
    public class DemoTests
    {
        #region Deprecated tests - these no longer work, but are left here to track examples in accompanying article
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
        [Ignore]
        [TestMethod]
        public void TestBlankVehicleWithFluentValidations()
        {
            var v = new Vehicle.Vehicle();
            Assert.IsNotNull(v);
            //var validator = new VehicleValidator();
            //var result = validator.Validate(v);

            //Assert.IsFalse(result.IsValid);
        }
        #endregion

        /// <summary>
        /// Test using fluent validation - see accomanying article.
        /// </summary>
        [TestMethod]
        public void TestBlankVehicleWithSearchValidations()
        {
            var v = new Vehicle.Vehicle();
            Assert.IsNotNull(v);
            var validator = new SearchVehicleValidator();
            var result = validator.Validate(v);
            Assert.IsFalse(result.IsValid);  // expect one field to be non-null

            v.Make = "not null";
            result = validator.Validate(v);
            Assert.IsTrue(result.IsValid);  // expect one field to be non-null

            v.Make = null;
            v.Model = "not null";
            result = validator.Validate(v);
            Assert.IsTrue(result.IsValid);  // expect one field to be non-null

            v.Model = null;
            v.VIN = "not null";
            result = validator.Validate(v);
            Assert.IsTrue(result.IsValid);  // expect one field to be non-null
        }

        /// <summary>
        /// Test using fluent validation - see accomanying article.
        /// </summary>
        [TestMethod]
        public void TestWithTwoValidatorTypes()
        {
            var v = new Vehicle.Vehicle() { Make = "Yugo"};
            var svalidator = new SearchVehicleValidator();
            var result = svalidator.Validate(v);
            Assert.IsTrue(result.IsValid);  // one non-null field here is sufficient to be valid 

            var lvalidator = new ListingVehicleValidator();
            result = lvalidator.Validate(v);
            Assert.IsFalse(result.IsValid);  // all fields must now be valid
        }
    }
}