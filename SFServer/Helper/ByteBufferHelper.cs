using System.Text;
using DotNetty.Buffers;

namespace Darkorbit.Helper
{
    public static class ByteBufferHelper
    {
        public static void WriteUTF(this IByteBuffer buffer, string str)
        {
            buffer.WriteShort((short)str.Length);
            buffer.WriteBytes(Encoding.UTF8.GetBytes(str));
        }

        public static string ReadUTF(this IByteBuffer buffer)
        {
            var len = buffer.ReadShort();
            return buffer.ReadBytes(len).ToString(Encoding.UTF8);
        }
    }
}
