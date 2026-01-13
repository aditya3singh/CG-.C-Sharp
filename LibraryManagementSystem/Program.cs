class Program
{
    static void Main()
    {
        Library library = new Library();

        library[101] = "C#";
        library[102] = "Me";

        Console.WriteLine(library[101]);
        Console.WriteLine(library[102]);

    }
}
