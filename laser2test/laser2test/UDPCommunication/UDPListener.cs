using System;
using System.Net;
using System.Threading;
using System.Net.Sockets;
using PositionListener.UDPCommunication;

namespace PositionListener
{
    public class UDPListener
    {
        protected UdpClient client;
        protected Thread worker;
        protected bool isAlive;
        protected IMessageHandler handler;

        public UDPListener(IMessageHandler handler, UdpClient udpClient)
        {
            this.client = udpClient;
            this.handler = handler;
            worker = new Thread(new ThreadStart(run));
            isAlive = true;
            worker.Start();
        }


        public void stop()
        {
            isAlive = false;
            client.Close();
            worker.Interrupt();
            worker.Join();
        }


        public void run()
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 0);
            int x=0;
            int y=0;
            while (isAlive)
            {
                try
                {
                    byte[] buffer = client.Receive(ref endPoint);
                    if (handler != null)
                    {
                        handler.onMessageReceived(endPoint.Address, buffer, buffer.Length);
                    }
                }
                catch (Exception e)
                {
                    System.Console.WriteLine(e.ToString());
                }
            }
        }
    }
}
