using System;

class Program
{
    public static void Main()
    {
        //Student st = new Student();
        //st.Name = "Alice";
        //st.Password = "secure123";
        //st.StudentID = 101;
        //st.Marks = 85;
        //st.Age = 20;

        //Console.WriteLine($"Name: {st.Name}");
        //Console.WriteLine
        //Console.WriteLine("enter the text: ");
        //int n = int.Parse(Console.ReadLine());
        //Console.WriteLine("The is the value :" + n);
        //Func<int, int> squareLambda = x => x * x;



        // this the part of the Exception practices

        try
        {
            int[] numbers = { 1, 2, 3 };
            int result = numbers[2] / 0; // Multiple possible exceptions
            Console.WriteLine(result);
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine("Cannot divide by zero.");
        }
        catch (IndexOutOfRangeException ex)
        {
            Console.WriteLine("Invalid array index.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An unexpected error occurred: " + ex.Message);
        }


    }
}