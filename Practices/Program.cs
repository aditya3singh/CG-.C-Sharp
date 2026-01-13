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
        Console.WriteLine("enter the text: ");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("The is the value :" + n);
        Func<int, int> squareLambda = x => x * x; ;
    }
}