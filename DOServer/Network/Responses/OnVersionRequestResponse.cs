using System;
using System.Collections.Generic;
using Darkorbit.Network.Messages;
using Darkorbit.Network.Sessions;

namespace Darkorbit.Network.Responses
{
    class OnVersionRequestResponse : IMessageResponse
    {
        public override void OnReceive(Message message)
        {
            VersionRequest loginMessage = message as VersionRequest;
            Console.WriteLine($"{loginMessage.playerId} is connecting with session_id: {loginMessage.sessionId}");
//            var User = new User();
//            User.EntityId = loginMessage.playerId;
//            var session = new Session()
//            {
//                Id = loginMessage.sessionId,
//                User = User,
//                Context = this.context
//            };
//            SessionManager.Instance.Add(session);
//            SendShips(session);

        }

        private void SendShips(Session session)
        {
//            var list = new List<VisualModifierCommand>();
//            list.Add(new VisualModifierCommand(session.User.EntityId, 23, 0, true));
//            session.SendMessage(new ShipInitCommand(session.User.EntityId,"test",87, 600,0,1000,1000,1000,1000,1000,100,1000,1000,1000,1,1,1,0,0,1, true, 1, 1, 1, 1, 1, 1, 21, "ok", 100, false, false, list));
        }
    }
}
