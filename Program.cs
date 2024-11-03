namespace monte_carlo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Podaj promień r: ");
            if (double.TryParse(Console.ReadLine(), out double r))
            {
                // Oblicz liczbę punktów na podstawie promienia
                int numPoints = (int)(4 * r * r);
                int pointsInsideCircle = 0;
                Random random = new Random();

                // Mierzenie czasu
                int start = Environment.TickCount;

                for (int i = 0; i < numPoints; i++)
                {
                    // Generowanie losowych punktów
                    double x = random.NextDouble() * 2 * r - r; // Punkt w zakresie [-r, r]
                    double y = random.NextDouble() * 2 * r - r; // Punkt w zakresie [-r, r]

                    // Sprawdzenie, czy punkt jest wewnątrz koła
                    if (x * x + y * y <= r * r)
                    {
                        pointsInsideCircle++;
                    }
                }

                // Obliczanie wartości Pi
                double piEstimate = 4.0 * pointsInsideCircle / numPoints;

                // Mierzenie czasu
                int stop = Environment.TickCount;
                int elapsedTime = stop - start;

                Console.WriteLine($"Przybliżona wartość Pi: {piEstimate}");
                Console.WriteLine($"Liczba punktów w kole: {pointsInsideCircle}");
                Console.WriteLine($"Liczba punktów w kwadracie: {numPoints}");
                Console.WriteLine($"Czas obliczeń: {elapsedTime} ms");
            }
            else
            {
                Console.WriteLine("Nieprawidłowy promień.");
            }
        }
    }
}
