using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace SignalRChat.Hubs
{
    public class Chat : Hub
    {
        public void SendMessage(string message, string firstName)
        {
            var msg = string.Format("{0}: {1}", firstName, message);
            Clients.All.addMessage(msg);
        }

        public void JoinRoom(string room, string firstName)
        {
            Groups.Add(firstName, room);
            Clients.Caller.joinRoom(room);
        }

        public void SendMessageToRoom(string message, string[] rooms, string firstName)
        {
            var msg = string.Format("{0}: {1}", firstName, message);

            for (int i = 0; i < rooms.Length; i++)
            {
                Clients.Group(rooms[i]).addMessage(msg);
            }
        }
    }
}