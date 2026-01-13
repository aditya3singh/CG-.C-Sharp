using System;

namespace LogisticsApp
{
    public class Shipment
    {
        public string ShipmentCode { get; set; }
        public string TransportMode { get; set; }
        public double Weight { get; set; }
        public int StorageDays { get; set; }
    }

    public class ShipmentDetails : Shipment
    {
        public bool ValidateShipmentCode()
        {
            if (string.IsNullOrEmpty(ShipmentCode) || ShipmentCode.Length != 7)
                return false;

            if (!ShipmentCode.StartsWith("GC#"))
                return false;

            string numericPart = ShipmentCode.Substring(3);
            return int.TryParse(numericPart, out _);
        }

        public double CalculateTotalCost()
        {
            double pricePerKg = 0;

            switch (TransportMode)
            {
                case "Sea":
                    pricePerKg = 15.00;
                    break;
                case "Air":
                    pricePerKg = 50.00;
                    break;
                case "Land":
                    pricePerKg = 25.00;
                    break;
                default:
                    return 0.00;
            }

            double totalCost = (Weight * pricePerKg) + Math.Sqrt(StorageDays);

            return Math.Round(totalCost, 2);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ShipmentDetails shipment = new ShipmentDetails();

            Console.WriteLine("Enter the shipment code:");
            shipment.ShipmentCode = Console.ReadLine();

            if (shipment.ValidateShipmentCode())
            {
                Console.WriteLine("Enter transport mode (Sea/Air/Land):");
                shipment.TransportMode = Console.ReadLine();

                Console.WriteLine("Enter weight (kg):");
                shipment.Weight = double.Parse(Console.ReadLine());

                Console.WriteLine("Enter storage days:");
                shipment.StorageDays = int.Parse(Console.ReadLine());

                double finalCost = shipment.CalculateTotalCost();
                Console.WriteLine($"The total shipping cost is {finalCost:F2}");
            }
            else
            {
                Console.WriteLine("Invalid shipment code");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
