using DotNetty.Buffers;

namespace Darkorbit.Network.Messages
{
    public interface Message
    {
        int GetId();
        void Read(IByteBuffer param1);
        void Write(IByteBuffer param1);
    }
}