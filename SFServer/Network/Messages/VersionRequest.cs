using Darkorbit.Helper;
using DotNetty.Buffers;

namespace Darkorbit.Network.Messages
{
    class VersionRequest : Message
    {
        public const int Id = 666;
        public int playerId = 0;
        public string sessionId = "";
        public int GetId()
        {
            return Id;
        }

        public void Read(IByteBuffer param1)
        {
            playerId = param1.ReadInt();
            sessionId = param1.ReadUTF();
        }

        public void Write(IByteBuffer param1)
        {
            //No write Here
        }
    }
}
