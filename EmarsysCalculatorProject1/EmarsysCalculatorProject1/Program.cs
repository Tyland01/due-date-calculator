using System;

namespace EmarsysCalculatorProject1
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new DueDateCalculator();

            // Edge Case 1: Submit at 4:50 PM on Monday, with 2 hours turnaround
            var submitTime1 = new DateTime(2024, 4, 15, 16, 50, 0); // Monday, 4:50 PM
            var turnaroundHours1 = 2;
            var dueDate1 = calculator.CalculateDueDate(submitTime1, turnaroundHours1);
            Console.WriteLine($"Submit Time: {submitTime1}");
            Console.WriteLine($"Turnaround Time: {turnaroundHours1} hours");
            Console.WriteLine($"Calculated Due Date: {dueDate1}\n");

            // Edge Case 2: Submit at 4:00 PM on Friday, with 8 hours turnaround
            var submitTime2 = new DateTime(2024, 4, 12, 16, 0, 0); // Friday, 4:00 PM
            var turnaroundHours2 = 8;
            var dueDate2 = calculator.CalculateDueDate(submitTime2, turnaroundHours2);
            Console.WriteLine($"Submit Time: {submitTime2}");
            Console.WriteLine($"Turnaround Time: {turnaroundHours2} hours");
            Console.WriteLine($"Calculated Due Date: {dueDate2}\n");

            // Edge Case 3: Submit at 9:30 AM on Monday, with 8 hours turnaround
            var submitTime3 = new DateTime(2024, 4, 15, 9, 30, 0); // Monday, 9:30 AM
            var turnaroundHours3 = 8;
            var dueDate3 = calculator.CalculateDueDate(submitTime3, turnaroundHours3);
            Console.WriteLine($"Submit Time: {submitTime3}");
            Console.WriteLine($"Turnaround Time: {turnaroundHours3} hours");
            Console.WriteLine($"Calculated Due Date: {dueDate3}\n");
        }
    }
}