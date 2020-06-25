// Use this code inside a project created with the Visual C# > Windows Desktop > Console Application template.
// Replace the code in Program.cs with this code.

using System;
using System.Threading;
using System.IO.Ports;

namespace test
{
    public class Program
    {
        private static bool _continue;

        public static void Main()
        {
            var listenDriver = new ComDriver(new SerialPort("COM23"));
            var writeDriver = new ComDriver(new SerialPort("COM24"));

            _continue = true;

            Console.WriteLine("Type QUIT to exit");
            
            listenDriver.Listen();

            var stringComparer = StringComparer.OrdinalIgnoreCase;
            while (_continue)
            {
                var message = Console.ReadLine();

                if (stringComparer.Equals("quit", message))
                {
                    _continue = false;
                }
                else
                {
                    writeDriver.Write(message);
                }
            }

            listenDriver.Close();
            writeDriver.Close();
        }
    }
}