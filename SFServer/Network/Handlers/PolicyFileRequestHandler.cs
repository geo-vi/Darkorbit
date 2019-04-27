using System;
using System.IO;
using System.Text;
using DotNetty.Buffers;
using DotNetty.Transport.Channels;

namespace Darkorbit.Network.Handlers
{
    public class PolicyFileRequestHandler : ChannelHandlerAdapter
    {
        private static string _content; 
        
        static PolicyFileRequestHandler()
        {
            _content = String.Empty;
        }

        public PolicyFileRequestHandler()
        {
            if (_content.Equals(String.Empty))
                _content = File.ReadAllText("policy-file.xml");
        }

        public override async void ChannelRead(IChannelHandlerContext context, object message)
        {
            var buffer = message as IByteBuffer;
            var requestString = buffer.ToString(Encoding.ASCII);

            if(requestString.Equals("<policy-file-request/>\0")) {
                //Console.WriteLine("Policy File Request");
                //throw new ArgumentException($"Not a Policy File Request, String given: {requestString}");
            

                // Response with the Policy File and close the Connection.
                var bytes = Encoding.ASCII.GetBytes(_content);

                var buffer2 = PooledByteBufferAllocator.Default.Buffer();
                buffer2.WriteBytes(bytes);

                await context.WriteAndFlushAsync(buffer2);
               // Console.WriteLine($"Policy Sent");
                await context.CloseAsync();
            }
        }

        public override void ExceptionCaught(IChannelHandlerContext context, Exception exception)
        {
            Console.WriteLine($"Exception: {exception}");
            context.CloseAsync();
        }
    }
}
