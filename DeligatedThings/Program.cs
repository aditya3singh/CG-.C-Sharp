
//delegate void ErrorDelegate(string msg);
//class Program
//{

//    static void Main()
//    {
//        //PaymentService service = new PaymentService();

//        //PaymentDelegate payment = service.ProcessPayment; // method reference

//        //decimal amount = 5000;

//        //if (amount.IsValidPayment())
//        //{
//        //    payment(amount); // 🔁 callback happens here
//        //}
//        //else
//        //{
//        //    Console.WriteLine("Invalid payment");
//        //}

//        //NotificationService service = new NotificationService();

//        //OrderDelegate notify = null;
//        //notify += service.SendEmail;
//        //notify += service.SendSMS;

//        //notify("ORD1001");

//        //Action<string> logActivity = message => Console.WriteLine("Log Entry: " + message);
//        //logActivity("User logged in at 10:30 AM");

//        //    Func<decimal, decimal, decimal> calculateDiscount = (price, discoutn) => price - (price * discoutn / 100);
//        //    Console.WriteLine(calculateDiscount(1000, 10));
//        //
//        //Predicate<int> isEligible = age => age >= 18;
//        //Console.WriteLine(isEligible(20));

//        //ErrorDelegate errorHandler = delegate (string msg)
//        //{
//        //    Console.WriteLine("Error: " + msg);
//        //};
//        //errorHandler("File not found");

//        Button btn = new Button();
//        btn.Clicked += () => Console.WriteLine("Button was clicked");
//        btn.Click();



//    }
//}


using System;

// 1️⃣ Custom delegate
delegate void ErrorDelegate(string msg);
delegate void SecurityAction(string location);

// 2️⃣ Program
class Program
{
    static void Main()
    {
        // ---------- BUTTON EVENT DEMO ----------
        Button btn = new Button();
        btn.Clicked += () => Console.WriteLine("Button was clicked");
        btn.Click();

        Console.WriteLine();

        // ---------- SECURITY SYSTEM DEMO ----------

        // Object initialization
        MotionSensor livingRoomSensor = new MotionSensor();
        AlarmSystem siren = new AlarmSystem();
        PoliceNotifier police = new PoliceNotifier();

        // Multicast delegate
        SecurityAction panicSequence = siren.SoundSiren;
        panicSequence += police.CallDispatch;

        // Linking delegate to sensor
        livingRoomSensor.OnEmergency = panicSequence;

        // Simulation
        livingRoomSensor.DetectIntruder("Main Lobby");
    }
}
