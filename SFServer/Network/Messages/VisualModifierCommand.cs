using DotNetty.Buffers;

namespace Darkorbit.Network.Messages
{
    class VisualModifierCommand : Message
    {
        public const int Id = 6297;
        public int userId = 0;

        public short modifier = 0;

        public int attribute = 0;

        public bool activated = false;

        public VisualModifierCommand(int userId, short modifier, int attribute, bool activated)
        {
            this.userId = userId;
            this.modifier = modifier;
            this.attribute = attribute;
            this.activated = activated;
        }

        public int GetId()
        {
            return Id;
        }

        public void Read(IByteBuffer param1)
        {
        }

        public void Write(IByteBuffer param1)
        {
            param1.WriteShort(Id);
            param1.WriteInt(userId);
            param1.WriteShort(modifier);
            param1.WriteInt(attribute);
            param1.WriteBoolean(activated);
        }
    }
}
