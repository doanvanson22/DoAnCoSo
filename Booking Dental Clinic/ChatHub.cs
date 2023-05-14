using System;
using System.Web;
using Microsoft.AspNet.SignalR;
namespace Booking_Dental_Clinic
{
    public class ChatHub : Hub
    {
        public void Send(string name, string message)
        {
            // Call the addNewMessageToPage method to update clients.
            Clients.All.addNewMessageToPage(name, message);
        }
    }
}