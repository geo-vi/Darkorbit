using System.Collections.Generic;
using Darkorbit.Network.Messages;
using DotNetty.Buffers;
using DotNetty.Transport.Channels;

namespace Darkorbit.Network
{
    public class MessageListener
    {
        private Dictionary<Message, List<IMessageResponse>> Listeners { get; set; }

        private static MessageListener _instance;

        public static MessageListener Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new MessageListener();
                return _instance;
            }
        }

        public MessageListener()
        {
            Listeners = new Dictionary<Message, List<IMessageResponse>>();
        }

        public void Register<T>(IMessageResponse response) where T : Message, new()
        {
            var message = new T() as Message;
         
            if (Listeners.ContainsKey(message))
                Listeners[message].Add(response);
            else
                Listeners.Add(message, new List<IMessageResponse>() { response });
        }

        public void Handle(int messageId, IByteBuffer buffer, IChannelHandlerContext context)
        {
            foreach(var message in Listeners.Keys)
            {
                if(message.GetId() == messageId)
                {
                    message.Read(buffer);
                    Listeners[message].ForEach(response =>
                    {
                        // overwrite the current context
                        //TODO: this could be improved alot.
                        response.context = context;
                        response.OnReceive(message);
                    });
                }
            }
        }
    }
}
