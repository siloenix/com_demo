// Use this code inside a project created with the Visual C# > Windows Desktop > Console Application template.
// Replace the code in Program.cs with this code.

using System;
using System.Threading;
using System.IO.Ports;
using test.driver;
using test.simulator;

namespace test
{
    public class Program
    {
        public static void Main()
        {
            var portName = "COM23";
            var filename = "./instructions.txt";
            var iterations = 1;

            Console.WriteLine("Enter your com port name: (default COM23)");
            var inputPortName = Console.ReadLine();

            Console.WriteLine("Enter your instructions file: (default ./instructions.txt)");
            var inputFileName = Console.ReadLine();

            Console.WriteLine("Enter iterations count: (default 1)");
            var inputIterations = Console.ReadLine();
            
            if (inputPortName.Length > 0)
            {
                portName = inputPortName;
            }
            if (inputFileName.Length > 0)
            {
                filename = inputFileName;
            }
            if (inputIterations.Length > 0)
            {
                iterations = Int32.Parse(inputIterations);
            }
            
            
            var simulator = new Simulator(new SerialPort(portName));
            simulator.ReadInstructions(filename);
            simulator.Simulate(iterations);
        }
    }
}