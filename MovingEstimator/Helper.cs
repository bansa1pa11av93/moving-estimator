using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovingEstimator
{
    public static class Helper
    {
        public static string JourDeSemaine(DayOfWeek j)
        {
            switch (j)
            {
                case DayOfWeek.Sunday: return "Dimanche ";
                case DayOfWeek.Monday: return "Lundi ";
                case DayOfWeek.Tuesday: return "Mardi ";
                case DayOfWeek.Wednesday: return "Mercredi ";
                case DayOfWeek.Thursday: return "Jeudi ";
                case DayOfWeek.Friday: return "Vendredi ";
                case DayOfWeek.Saturday: return "Samedi ";
            }
            return " ";
        }
        public static string Day_of_week(DayOfWeek d)
        {
            switch (d)
            {
                case DayOfWeek.Sunday: return "Sunday ";
                case DayOfWeek.Monday: return "Monday ";
                case DayOfWeek.Tuesday: return "Tuesday ";
                case DayOfWeek.Wednesday: return "Wednesday ";
                case DayOfWeek.Thursday: return "Thursday ";
                case DayOfWeek.Friday: return "Friday ";
                case DayOfWeek.Saturday: return "Saturday ";
            }
            return " ";
        }
        public static double MinimumBilled(double h)
        {
            if (h < 2) return 2;
            if (h < 3) return 3;
            double rounded_Minimum = h * .75;
            if (h * .75 < 3) return 3;
            return QuarterRound(h * .75);
        }
        public static double QuarterRound(double q)
        {
            double nearestInt = Math.Truncate(q);
            double fractionalPart = q - nearestInt;

            if (fractionalPart < 0.125) return nearestInt;
            if (fractionalPart < 0.375) return nearestInt + 0.25;
            if (fractionalPart < 0.625) return nearestInt + 0.5;
            if (fractionalPart < 0.875) return nearestInt + 0.75;

            return nearestInt + 1.0;
        }
    }
}
