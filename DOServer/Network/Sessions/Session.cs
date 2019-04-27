using System;
using Darkorbit.Network.Messages;
using DotNetty.Buffers;
using DotNetty.Transport.Channels;

namespace Darkorbit.Network.Sessions
{
    public class Session
    {
        public string Id { get; set; }
        
        public IChannelHandlerContext Context { get; set; }


        public void SendMessage(Message message) 
        {
            if (Context == null)
                throw new NullReferenceException("Context is null");

            var buffer = PooledByteBufferAllocator.Default.DirectBuffer();
            message.Write(buffer);

            var wrapperBuffer = PooledByteBufferAllocator.Default.DirectBuffer(buffer.WriterIndex + 2);

            wrapperBuffer.WriteShort(buffer.WriterIndex);
            wrapperBuffer.WriteBytes(buffer);

            Context.WriteAndFlushAsync(wrapperBuffer);
        }
       
    }
}
