using System.ComponentModel.DataAnnotations;
using DeepDive.Validation;
namespace DeepDiveTest
{
    
        [TestClass]
      public class DateNotInPastAttributeTests
        {
            private readonly DateNotInPastAttribute _attribute = new();

        //DateValidation test

            [TestMethod]
            public void IsDateValid_Yesterday()
            {
                
                var yesterday = DateTime.Today.AddDays(-1);

              
                bool result = _attribute.IsValid(yesterday);

               
                Assert.IsFalse(result);
            }

        [TestMethod]
        public void IsDateValid_Today()
        {
           
            var day = DateTime.Today;

           
            bool result = _attribute.IsValid(day);

           
            Assert.IsTrue(result);
        }

    }
}
