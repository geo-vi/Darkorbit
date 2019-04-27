using Darkorbit.Network.Messages;
using DotNetty.Transport.Channels;

namespace Darkorbit.Network
{
    public abstract class IMessageResponse
    {
        public IChannelHandlerContext context;
        public virtual void OnReceive(Message message) { }
    }
}
