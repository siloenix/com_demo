using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Text;
using System.Threading;
using test.driver;

namespace test.simulator
{
    
    public class Simulator
    {
        private string WAIT_COMMAND = "wait: ";
        private string WRITE_COMMAND = "write: ";
        
        
        private ComDriver _driver;
        private List<string> instructions;
        private Thread listenerThread;

        public Simulator(SerialPort port)
        {
            _driver = new ComDriver(port);
            if (port.IsOpen)
            {
                port.Close();
            }
        }

        public void ReadInstructions(string filePath)
        {
            string file = File.ReadAllText(filePath);
            instructions = new List<string>(file.Split("\r\n"));
        }

        public void Simulate(int repeat = 1)
        {
            if (repeat == -1)
            {
                repeat = 999999;
            }

            listenerThread = _driver.Listen();

            while (repeat-- > 0)
            {
                try
                {
                    _simulate();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            
            _driver.Close();
        }

        private void _simulate()
        {
            foreach (string instruction in instructions)
            {
                Console.WriteLine(instruction);
                if (instruction.StartsWith(WRITE_COMMAND))
                {
                    _driver.Write(instruction.Replace(WRITE_COMMAND, ""));
                } else if (instruction.StartsWith(WAIT_COMMAND))
                {
                    var millisecondsTimeout = Int32.Parse(instruction.Replace(WAIT_COMMAND, ""));
                    Thread.CurrentThread.Join(millisecondsTimeout);
                    // Thread.Sleep(millisecondsTimeout);
                }
            }
        }
    }
}