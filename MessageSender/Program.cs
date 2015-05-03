﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;
using System.Threading;

namespace MessageSender
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Compose message: ");
            var _msgHub = ConnectToHub();
            
            string message = null;
            
            
            while ((message = Console.ReadLine()) != null)
            {              
                _msgHub.On("RecieveDate", q => Console.WriteLine(q));
                _msgHub.Invoke("MessageReciever", message, DateTime.Now).Wait();               
            }
        }

        private static IHubProxy ConnectToHub()
        {
            Thread.Sleep(5000);
            IHubProxy _msgHub;
            string url = @"http://localhost:8080/";
            var connection = new HubConnection(url);
            _msgHub = connection.CreateHubProxy("MessageHub");
            connection.Start().Wait();
            return _msgHub;
        }
    }
}