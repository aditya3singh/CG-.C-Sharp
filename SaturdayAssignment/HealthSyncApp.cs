using System;

namespace HealthSyncApp
{
    
    public abstract class Consultant
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double PayoutAmount { get; set; }

        public bool ValidateConsultantId()
        {
            if (string.IsNullOrEmpty(Id) || Id.Length != 6)
                return false;

            if (!Id.StartsWith("DR"))
                return false;

            return int.TryParse(Id.Substring(2), out _);
        }

        public abstract void CalculateGrossPayout();

        public virtual double GetTaxRate()
        {
            return (PayoutAmount > 5000) ? 0.15 : 0.05;
        }

        public void ApplyTax()
        {
            double rate = GetTaxRate();
            double taxAmount = PayoutAmount * rate;
            PayoutAmount -= taxAmount;
        }
    }

    public class InHouse : Consultant
    {
        public double MonthlyStipend { get; set; }

        public override void CalculateGrossPayout()
        {
            double allowance = 0.20 * MonthlyStipend;
            double bonus = 0.10 * MonthlyStipend;
            PayoutAmount = MonthlyStipend + allowance + bonus;
        }
    }

    public class Visiting : Consultant
    {
        public int ConsultationsCount { get; set; }
        public int RatePerVisit { get; set; }

        public override void CalculateGrossPayout()
        {
            PayoutAmount = ConsultationsCount * RatePerVisit;
        }

        public override double GetTaxRate()
        {
            return 0.10;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1. In-House Consultant");
            Console.WriteLine("2. Visiting Consultant");
            Console.WriteLine("Choose consultant type:");
            int choice = int.Parse(Console.ReadLine());

            Consultant consultant =
                (choice == 1) ? new InHouse() : new Visiting();

            Console.WriteLine("Enter doctor id:");
            consultant.Id = Console.ReadLine();

            if (!consultant.ValidateConsultantId())
            {
                Console.WriteLine("Invalid doctor id");
                return;
            }

            Console.WriteLine("Enter doctor name:");
            consultant.Name = Console.ReadLine();

            if (consultant is InHouse ih)
            {
                Console.WriteLine("Enter monthly stipend:");
                ih.MonthlyStipend = double.Parse(Console.ReadLine());
            }
            else if (consultant is Visiting v)
            {
                Console.WriteLine("Enter consultations count:");
                v.ConsultationsCount = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter rate per visit:");
                v.RatePerVisit = int.Parse(Console.ReadLine());
            }

            consultant.CalculateGrossPayout();
            double gross = consultant.PayoutAmount;

            consultant.ApplyTax();

            Console.WriteLine($"Gross Payout : {gross:F2}");
            Console.WriteLine($"Net Payout : {consultant.PayoutAmount:F2}");
        }
    }
}
