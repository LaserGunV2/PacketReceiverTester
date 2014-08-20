using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.ComponentModel;
using System.Net;

namespace PositionListener.UDPCommunication
{
    public class ByteBufferReaderWriter
    {
        public static int DATALENGTH_INT = 4;

        //gk thread safe
        protected byte[] buffer;
        protected MemoryStream outStream;
        protected BinaryWriter writer;

        public ByteBufferReaderWriter(int bufferSize)
        {
            buffer = new byte[bufferSize];
            outStream = new MemoryStream(buffer);
            writer = new BinaryWriter(outStream);
        }

        public void reset()
        {
            outStream.Position = 0;
        }

        public void writeInt(int input)
        {
            writer.Write((long)IPAddress.HostToNetworkOrder(input));
            writer.Flush();
        }

        public byte[] getBuffer()
        {
            return buffer;
        }

        public long getBufferLength()
        {
            return outStream.Position;
        }


        public static int ByteArrToInt(byte[] buffer,int index)
        {
            return IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer, index));
        }
    }
}
