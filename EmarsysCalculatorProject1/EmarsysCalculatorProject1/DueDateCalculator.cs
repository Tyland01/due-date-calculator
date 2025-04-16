using System;

namespace EmarsysCalculatorProject1
{
    public class DueDateCalculator
    {
        private readonly TimeSpan WorkDayStart = new TimeSpan(9, 0, 0);
        private readonly TimeSpan WorkDayEnd = new TimeSpan(17, 0, 0);
        private const int WorkHoursPerDay = 8;

        public DateTime CalculateDueDate(DateTime submitDate, int turnaroundHours)
        {
            if (turnaroundHours < 0)
                throw new ArgumentException("Turnaround time must be non-negative.");

            DateTime current = submitDate;

            // Step 1: Use time left today first
            TimeSpan timeLeftToday = WorkDayEnd - current.TimeOfDay;
            int hoursToUseToday = Math.Min(turnaroundHours, (int)timeLeftToday.TotalHours);

            current = current.AddHours(hoursToUseToday);
            turnaroundHours -= hoursToUseToday;

            // Step 2: If we used all hours, we're done
            if (turnaroundHours == 0)
                return current;

            // Step 3: After using time on Friday, ensure we move to Monday at 9:00 AM
            if (current.DayOfWeek == DayOfWeek.Friday)
            {
                // If we used some time on Friday, make sure to jump to Monday at 9 AM
                current = new DateTime(current.Year, current.Month, current.Day, 9, 0, 0).AddDays(3);
                turnaroundHours -= 8; // Use the full Monday 9 AM - 5 PM workday
            }

            // Step 4: Add full workdays (skip weekends)
            while (turnaroundHours >= WorkHoursPerDay)
            {
                current = AddOneWorkingDay(current);
                turnaroundHours -= WorkHoursPerDay;
            }

            // Step 5: Add remaining hours (after workday starts on Monday)
            if (turnaroundHours > 0)
            {
                current = AddWorkingHours(current, turnaroundHours);
            }

            return current;
        }

        private DateTime AddWorkingHours(DateTime date, int hours)
        {
            DateTime result = date;
            while (hours > 0)
            {
                TimeSpan timeLeftToday = WorkDayEnd - result.TimeOfDay;

                if (timeLeftToday.TotalHours >= hours)
                {
                    result = result.AddHours(hours);
                    hours = 0;
                }
                else
                {
                    hours -= (int)timeLeftToday.TotalHours;
                    result = AddOneWorkingDay(result.Date + WorkDayStart);
                }
            }

            return result;
        }


        // Adds one working day (skipping weekends)
        private DateTime AddOneWorkingDay(DateTime date)
        {
            DateTime next = date.AddDays(1);
            while (IsWeekend(next))
            {
                next = next.AddDays(1);
            }
            return new DateTime(next.Year, next.Month, next.Day, WorkDayStart.Hours, WorkDayStart.Minutes, WorkDayStart.Seconds);
        }
        
        // Check if the date is a weekend (Saturday or Sunday)
        private bool IsWeekend(DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
        }
    }
}