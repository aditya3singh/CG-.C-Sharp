using System;

namespace GymStream
{
    public class InvalidTierException : Exception
    {
        public InvalidTierException(string message) : base(message) { }
    }

    public class Membership
    {
        public string Tier { get; set; }
        public int DurationInMonths { get; set; }
        public double BasePricePerMonth { get; set; }

        public bool ValidateEnrollment()
        {
            if (Tier != "Basic" && Tier != "Premium" && Tier != "Elite")
            {
                throw new InvalidTierException(
                    "Tier not recognized. Please choose an available membership plan."
                );
            }

            if (DurationInMonths <= 0)
            {
                throw new Exception("Duration must be at least one month.");
            }

            return true;
        }
        public double CalculateTotalBill()
        {
            double total = DurationInMonths * BasePricePerMonth;
            double discountRate = 0;

            switch (Tier)
            {
                case "Basic":
                    discountRate = 2;
                    break;
                case "Premium":
                    discountRate = 7;
                    break;
                case "Elite":
                    discountRate = 12;
                    break;
            }

            double discountAmount = total * (discountRate / 100);
            return total - discountAmount;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Membership member = new Membership();

            try
            {
                Console.WriteLine("--- GymStream Enrollment Portal ---");

                Console.WriteLine("Enter membership tier:");
                member.Tier = Console.ReadLine();

                Console.WriteLine("Enter duration:");
                member.DurationInMonths = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter monthly price:");
                member.BasePricePerMonth = Convert.ToDouble(Console.ReadLine());

                if (member.ValidateEnrollment())
                {
                    Console.WriteLine("Enrollment Successful.");
                    double finalAmount = member.CalculateTotalBill();
                    Console.WriteLine($"Final Bill Amount: {finalAmount:F2}");
                }
            }
            catch (InvalidTierException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
