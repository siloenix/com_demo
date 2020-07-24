using System;
using System.IO.Ports;
using System.Threading;

namespace test.driver
{
    public class ComDriver
    {
        private ICommandListener _listener;
        private readonly SerialPort _port;
        private Thread _readThread;
        

        public ComDriver(SerialPort port)
        {
            _listener = new DefaultCommandListener();
            _port = port;
            _port.ReadTimeout = 500;
            _port.WriteTimeout = 500;
        }

        public void Write(string command)
        {
            if (!_port.IsOpen)
            {
                _port.Open();
            }
            _port.WriteLine(command);
        }

        public Thread Listen()
        {
            return Listen(_listener);
        }
        
        public Thread Listen(ICommandListener listener)
        {
            if (!_port.IsOpen)
            {
                _port.Open();
            }
            _listener = listener;
            _readThread = new Thread(() =>
            {
                while (Thread.CurrentThread.IsAlive)
                {
                    try
                    {
                        var command = _port.ReadLine();
                        listener.Process(command);
                    }
                    catch (TimeoutException) {}
                }
            });
            _readThread.Start();
            return _readThread;
        }

        public void StopListening()
        {
            _readThread.Interrupt();
        }

        public void Close()
        {
            StopListening();
            _port.Close();
        }
    }
}