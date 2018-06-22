using System;
using System.IO.Ports;

/*
 * 
https://docs.microsoft.com/en-us/dotnet/api/system.io.ports.serialport?view=netcore-2.0
*/
namespace winser
{
    class Program
    {
        static void Main(string[] args)
        {
	        var port = new System.IO.Ports.SerialPort("COM3", 19200);

	        port.Open();

            Console.WriteLine("port open");
        }
    }
}
