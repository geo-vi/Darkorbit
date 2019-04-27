using System.Collections.Generic;
using DotNetty.Transport.Channels;

namespace Darkorbit.Network.Sessions
{
    public class SessionManager : Singleton<SessionManager>
    {
        public Dictionary<IChannelHandlerContext, Session> sessions;
        public Dictionary<double, IChannelHandlerContext> SessionByEntity = new Dictionary<double, IChannelHandlerContext>();
        // PUT HERE YOUR LISTS AND DICTIONARYS
        public int LastObject = 199900000;
        public SessionManager()
        {
            sessions = new Dictionary<IChannelHandlerContext, Session>();
        }

        public void Add(Session session)
        {
//            var added = false;
//            foreach (Session item in sessions.Values)
//            {
//                if (item.Id == session.Id)
//                {
//                    session.User = sessions[item.Context].User;
//                    sessions.Remove(item.Context);
//                    sessions.Add(session.Context, session);
//                    added = true;
//                    break;
//                }
//            }
//            if (!added)
//            {
//                sessions.Add(session.Context, session);
//            }
//            if (!SessionByEntity.ContainsKey(session.User.EntityId))
//                SessionByEntity.Add(session.User.EntityId, session.Context);
//            else
//                SessionByEntity[session.User.EntityId] = session.Context;
        }
        public int GenerateEntityId()
        {
            var CurrentId = LastObject;
            LastObject++;
            return CurrentId;
        }
        //TODO Add Remove, Update

    }
}
