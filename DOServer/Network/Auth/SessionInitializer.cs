using Darkorbit.Network.Handlers;
using DotNetty.Handlers.Logging;
using DotNetty.Transport.Channels;
using DotNetty.Transport.Channels.Sockets;

namespace Darkorbit.Network.Auth
{
    public class SessionInitializer : ChannelInitializer<ISocketChannel>
    {

        protected override void InitChannel(ISocketChannel channel)
        {
            //Console.WriteLine("Pipe");
            var pipeline = channel.Pipeline;

            pipeline.AddLast("DebugLogging", new LoggingHandler(LogLevel.INFO));
            pipeline.AddLast("GameMessageHandler", new GameMessageHandler());

        }
    }
}
