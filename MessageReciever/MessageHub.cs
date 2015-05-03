using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MessageReciever.Models;
using MessageReciever.Models.EntityModel;
using Microsoft.AspNet.SignalR;

namespace MessageReciever
{
    public class MessageHub : Hub
    {
        public MessageDbEntities context = new MessageDbEntities();    

        public void Send(string message)
        {
            Clients.All.addNewMessage(message);
        }

        public void MessageReciever(string message, DateTime date)
        {           
            context.MessageTables.Add(new MessageTable
            {
                Message = message,
                RecievedAt = date,               
            });

            string responseMsg = string.Format(@"Message:[{0}] was recieved by server at: {1}", message, date);
            Clients.All.RecieveDate(responseMsg);

            context.SaveChanges();
        }

        public void GetExceptionMessage(string message)
        {            
            string exResponse = string.Format(@"Connection successfull but something else went wrong: [Exception: {0}]", message);
            Clients.All.ExceptionMsg(exResponse);
        }
    }
}
