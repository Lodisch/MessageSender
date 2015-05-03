using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MessageReciever.Models;
using MessageReciever.Models.EntityModel;
using Microsoft.Owin.Hosting;

namespace MessageReciever.Controllers
{
    public class MessageController : Controller
    {
        public MessageDbEntities context = new MessageDbEntities(); 
        public const string url = "http://localhost:8080/";
        
        public ActionResult Index()
        {
            GetConnection();
            
            return View();
        }

        public ActionResult DisplayMessages()
        {
            var messages = context.MessageTables.Select(message => new MessageModel
            {
                Msg = message.Message, Date = message.RecievedAt
            }).ToList();
           
            return View(messages);
        }

        private void GetConnection()
        {          
            WebApp.Start<Startup>(url);
          
        }
    }
}