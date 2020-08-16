using System;
using DesignPatternsTutorial.Decorator;

namespace DesignPatternsTutorial
{
    public class Program
    {
        public static void Main(string[] args)
        { 
            //Console.WriteLine("Hello World!");
            MyStringBuilder s = "hello ";
            s += "world";
            Console.WriteLine(s);

            Console.ReadLine();
        }
    }
}
