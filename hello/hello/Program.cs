using System;
using logic;

namespace hello
{
    class Program
    {
        static void Main(string[] args)
        {
        	Console.Write("What's your name: ");
			var name = Console.ReadLine();
			var message = Class1.Greet(name);
			Console.WriteLine(message);
        }
    }
}
