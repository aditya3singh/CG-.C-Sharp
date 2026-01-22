using System;

namespace RefClass
{

    public interface I1
    {
        void M1();
        void M2();
    }
    public interface I2
    {
        void M3();
    }
    public interface I3
    {
        void M4();
    }

    public class A : I1, I2, I3
    {

        public void M1()
        {
            Console.WriteLine("M1 from I1");
        }

        public void M2()
        {
            Console.WriteLine("M2 from I1");
        }

        public void M3()
        {
            Console.WriteLine("M3 from I2");
        }

        public void M4()
        {
            Console.WriteLine("M4 from I3");
        }
    }
    public class B : A
    {
        public void M5()
        {
            Console.WriteLine("New method M5 from Class B");
        }
    }
}
