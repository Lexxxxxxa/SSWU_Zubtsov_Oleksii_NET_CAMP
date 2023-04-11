using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Task_3
{
    public class ElectricityReading
    {
        public DateTime Date { get; set; }
        public int Value { get; set; }
    }

    public class Apartment
    {
        public int Number { get; set; }
        public string Owner { get; set; }
        public List<ElectricityReading> Readings { get; set; } = new List<ElectricityReading>();

        public decimal CalculateCost(decimal rate)
        {
            decimal total = 0;
            for (int i = 1; i < Readings.Count; i++)
            {
                decimal usage = Readings[i].Value - Readings[i - 1].Value;
                total += usage * rate;
            }
            return total;
        }

        public void PrintInfo(decimal rate)
        {
            Console.WriteLine($"Apartment #{Number} ({Owner})");
            Console.WriteLine("Date     Indicator      Used     Expenditure");
            Console.WriteLine("-------------------------------------------");
            for (int i = 0; i < Readings.Count; i++)
            {
                ElectricityReading current = Readings[i];
                DateTime date = current.Date;
                string formattedDate = date.ToString("dd.MM.yy");
                decimal usage = 0, cost = 0;
                if (i > 0)
                {
                    usage = current.Value - Readings[i - 1].Value;
                    cost = usage * rate;
                }
                Console.WriteLine($"{formattedDate,-9} {current.Value,-12} {usage,-13} {cost,10:F2}");
            }
            Console.WriteLine();
        }

        public int DaysSinceLastReading()
        {
            if (Readings.Count > 0)
            {
                DateTime lastDate = Readings[Readings.Count - 1].Date;
                TimeSpan span = DateTime.Now - lastDate;
                return (int)span.TotalDays;
            }
            else
            {
                return 0;
            }
        }
    }
}
