namespace Home_Task_3
{
    public class Home_Task_3
    {// Не побачила копії екрану для виконання завдання 
        // задача розв'язується в Main, не ООП.
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
}
