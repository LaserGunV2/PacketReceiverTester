using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace PositionListener.UDPCommunication
{
    public class UDPCommManager
    {
        protected UDPListener listener;
        protected int port;
        protected UDPSender sender;

        public UDPCommManager(IMessageHandler handler, int port)
        {
            this.port = port;
            UdpClient client = new UdpClient(port);
            listener = new UDPListener(handler, client);
            sender = new UDPSender(client);
        }

        public void send(IPAddress target ,byte[] buffer, int length)
        {
            sender.send(target, port, buffer, length);
        }

        public void cleanup()
        {
            listener.stop();
        }
    }
}
