namespace Home_Task_3
{
    public class Home_Task_3
    {
        public static void Main()
        {
            string filename = "data.txt";
            List<Apartment> apartments = new List<Apartment>();

            decimal rate = 0; // вартість одного кіловату електроенергії
            int quarter = 0;

            using (StreamReader reader = new StreamReader(filename))
            {
                string firstLine = reader.ReadLine();
                string[] parts = firstLine.Split();
                int count = int.Parse(parts[0]);
                quarter = int.Parse(parts[1]);
                for (int i = 0; i < count; i++)
                {
                    Apartment apartment = new Apartment();
                    apartment.Number = int.Parse(reader.ReadLine());
                    apartment.Owner = reader.ReadLine();
                    int readingsCount = int.Parse(reader.ReadLine());
                    for (int j = 0; j < readingsCount; j++)
                    {
                        string[] readingsParts = reader.ReadLine().Split();
                        ElectricityReading reading = new ElectricityReading();
                        reading.Date = DateTime.Parse(readingsParts[0]);
                        reading.Value = int.Parse(readingsParts[1]);
                        apartment.Readings.Add(reading);
                    }
                    apartments.Add(apartment);
                }
                rate = decimal.Parse(reader.ReadLine());
            }

            Console.WriteLine($"Information about apartments for {quarter} quarter");
            Console.WriteLine();
            foreach (Apartment apartment in apartments)
            {
                apartment.PrintInfo(rate);
                int daysSinceLastReading = apartment.DaysSinceLastReading();
                if (daysSinceLastReading > 30)
                {
                    Console.WriteLine($"Attention! The last readings have been taken {daysSinceLastReading} days ago.");
                    Console.WriteLine();
                }
            }

            decimal totalCost = 0;
            foreach (Apartment apartment in apartments)
            {
                totalCost += apartment.CalculateCost(rate);
            }
            Console.WriteLine($"Total electricity costs for the quarter {totalCost:F2}");
        }
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

    public class ElectricityReading
    {
        public DateTime Date { get; set; }
        public int Value { get; set; }
    }
}