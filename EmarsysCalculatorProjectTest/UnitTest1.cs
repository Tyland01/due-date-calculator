using System;
using Xunit;
using EmarsysCalculatorProject1;

namespace EmarsysCalculatorProjectTest
{
    public class UnitTest1
    {
        [Fact]
        public void CalculateDueDate_ShouldReturnMondayAt4PM_WhenSubmittedFridayAt4PMWith16HourTurnaround()
        {
            // Arrange
            var calculator = new DueDateCalculator();
            var submitTime = new DateTime(2024, 4, 12, 16, 0, 0); // Friday, 4:00 PM
            var turnaroundHours = 16;

            // Act
            var dueDate = calculator.CalculateDueDate(submitTime, turnaroundHours);

            // Assert
            var expectedDueDate = new DateTime(2024, 4, 15, 16, 0, 0); // Monday, 4:00 PM
            Assert.Equal(expectedDueDate, dueDate);
        }
    }
}
