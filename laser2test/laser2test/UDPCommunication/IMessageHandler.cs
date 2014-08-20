using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace PositionListener.UDPCommunication
{
    public interface IMessageHandler
    {
        void onMessageReceived(IPAddress sender, byte[] buffer, int length);
    }
}
