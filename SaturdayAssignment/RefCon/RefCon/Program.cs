using System;
using System.Reflection;
using System.Security.Policy;
using RefClass;

//class Program
//{
//    static void Main()
//    {
//        Assembly assembly = Assembly.LoadFrom(
//            @"C:\Users\singh\Downloads\RefClass\RefClass\bin\Debug\net10.0\RefClass.dll");

//        foreach (Type type in assembly.GetTypes())
//        {
//            Console.WriteLine($"\nType: {type.FullName}");

//            // List interfaces
//            foreach (Type iface in type.GetInterfaces())
//            {
//                Console.WriteLine($"  Implements Interface: {iface.Name}");
//            }

//            // List only methods declared in that type
//            MethodInfo[] methods = type.GetMethods(
//                BindingFlags.Public |
//                BindingFlags.NonPublic |
//                BindingFlags.Instance );

//            foreach (MethodInfo method in methods)
//            {
//                Console.WriteLine($"  Method: {method.Name}");
//            }
//        }

//        Console.ReadLine();
//    }
//}



class Program
{
    static void Main()
    {
        Assembly assembly = Assembly.LoadFrom(
            @"C:\Users\singh\Downloads\RefClass\RefClass\bin\Debug\net10.0\RefClass.dll");
        Console.WriteLine("Available Classes: \n");

        foreach(Type type in assembly.GetTypes())
        {
            if (type.IsClass)
            {
                Console.WriteLine(type.FullName);
            }
        }
        Console.WriteLine("\nMethods available in Class B:\n");

        Type B = assembly.GetType("RefClass.B");
        MethodInfo[] methods = B.GetMethods(
            BindingFlags.Public |
            BindingFlags.Instance);

        foreach (MethodInfo method in methods)
        {
            Console.WriteLine(method.Name);
        }

        Console.ReadLine();

    }
}