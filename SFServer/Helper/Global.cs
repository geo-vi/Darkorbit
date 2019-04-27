using System;
using Darkorbit.Network.Messages;
using Darkorbit.Network.Sessions;
using DotNetty.Buffers;

namespace Darkorbit.Helper
{
    public static class Global
    {


        /**
        * Description:
        * 	Send a packet to every user in new server
        * 
        * @param message: the message to send
        */
        public static void SendMessageToAll(Message message)
        {
            foreach (var item in SessionManager.Instance.sessions)
            {
                item.Value.SendMessage(message);
            }
        }

        /**
        * Description:
        * 	Send a packet to every user in the map 
        * 
        * @param mapID: the map to send the message
        * @param message: the message to send
        */
        public static void SendMessageToMap(int mapID, Message message)
        {
            foreach (var item in SessionManager.Instance.sessions)
            {
                SendMessage(message, item.Value);
            }
        }
     
        public static void SendMessage(Message message, Session session)
        {
            if (session.Context == null)
                throw new NullReferenceException("Context is null");

            var buffer = PooledByteBufferAllocator.Default.DirectBuffer();
            message.Write(buffer);

            var wrapperBuffer = PooledByteBufferAllocator.Default.DirectBuffer(buffer.WriterIndex + 2);

            wrapperBuffer.WriteShort(buffer.WriterIndex);
            wrapperBuffer.WriteBytes(buffer);

            session.Context.WriteAndFlushAsync(wrapperBuffer);
        }
    
        
    }
}
