using System;
using System.Text;
using DotNetty.Buffers;
using DotNetty.Transport.Channels;
using NLog;

namespace Darkorbit.Network.Handlers
{
    public class GameMessageHandler : ChannelHandlerAdapter
    {
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();
        private PolicyFileRequestHandler policyFileRequestHandler = new PolicyFileRequestHandler();

        private bool _firstMessage = true;
        //here 
        public override void ChannelRead(IChannelHandlerContext context, object message)
        {
            policyFileRequestHandler.ChannelRead(context, message);
            var buffer = message as IByteBuffer;
            var requestString = buffer.ToString(Encoding.ASCII);

                var length = buffer.ReadableBytes;

         

                var hexDump = ByteBufferUtil.PrettyHexDump(buffer);
                Console.WriteLine(hexDump);

                while (buffer.ReaderIndex < (length - 4))
                {
                    var messageLength = buffer.ReadShort();
                    var messageId = buffer.ReadShort();

                    Console.WriteLine("PacketID Received: " + messageId + " Lenght: " + messageLength);

                    if (messageLength == 0) continue;

                    MessageListener.Instance.Handle(messageId, buffer, context);
                }
            
        }

       public override void ChannelReadComplete(IChannelHandlerContext context) => context.Flush();

        public override void ExceptionCaught(IChannelHandlerContext context, Exception exception)
        {
            Console.WriteLine($"Exception: {exception}");
            context.CloseAsync();
        }

        public override void ChannelActive(IChannelHandlerContext context)
        {
            policyFileRequestHandler.ChannelActive(context);
            var channel = context.Channel;
           
            Console.WriteLine("received a new connection.");
            base.ChannelActive(context);
        }
    }
}
