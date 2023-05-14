using Owin;
using Microsoft.Owin;
using System.Runtime.InteropServices;

[assembly: OwinStartup(typeof(Booking_Dental_Clinic.Startup))]
namespace Booking_Dental_Clinic
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            // Any connection or hub wire up and configuration should go here
            app.MapSignalR();

        }
    }
}
