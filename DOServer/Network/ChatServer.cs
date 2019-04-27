using System;
using System.Threading.Tasks;
using Darkorbit.Network.Auth;
using DotNetty.Handlers.Logging;
using DotNetty.Transport.Bootstrapping;
using DotNetty.Transport.Channels;
using DotNetty.Transport.Channels.Sockets;

namespace Darkorbit.Network
{
    public class ChatServer
    {
        public int Backlog { get; }
        public int Port { get; }

        private readonly ServerBootstrap _bootstrap;
        private readonly MultithreadEventLoopGroup _bossEventLoopGroup;
        private readonly MultithreadEventLoopGroup _workerEventLoopGroup;
        private IChannel _channel;

        public ChatServer(int port,
            int backlog)
        {
            Port = port;
            Backlog = backlog;

            _bootstrap = new ServerBootstrap();
            _bossEventLoopGroup = new MultithreadEventLoopGroup(1);
            _workerEventLoopGroup = new MultithreadEventLoopGroup();
        }

        protected void Initialize()
        {
            _bootstrap.Group(_bossEventLoopGroup,
                _workerEventLoopGroup);

            // Set Channel Type to Tcp.
            _bootstrap.Channel<TcpServerSocketChannel>();

            // Set Server Options
            _bootstrap.Option(ChannelOption.SoLinger, 0);
            _bootstrap.Option(ChannelOption.SoBacklog, Backlog);

            _bootstrap.Handler(new LoggingHandler(LogLevel.INFO));
            _bootstrap.ChildHandler(new ChatSessionInitializer());

            _bootstrap.ChildOption(ChannelOption.SoLinger, 0);
            _bootstrap.ChildOption(ChannelOption.SoKeepalive, true);
            _bootstrap.ChildOption(ChannelOption.TcpNodelay, true);
            _bootstrap.ChildOption(ChannelOption.SoReuseaddr, true);
            Console.WriteLine("ChatServer Started");


        }
        public async Task StartAsync()
        {
            Initialize();
            _channel = await _bootstrap.BindAsync(Port);
        }

    }
}
