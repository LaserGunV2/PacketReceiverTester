using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;

namespace PositionListener.UDPCommunication
{
    public class UDPSender
    {
        protected UdpClient senderClient;

        public UDPSender(UdpClient udpClient)
        {

            this.senderClient = udpClient;
            
        }

        public void send(IPAddress target, int port, byte[] buffer, int length)
        {
            IPEndPoint endPoint = new IPEndPoint(target, port);
            senderClient.Send(buffer, length, endPoint);
        }
    }
}
