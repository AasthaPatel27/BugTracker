using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BugTrackingService;
using System.ServiceModel;

namespace BugTrackingServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            Type userManageSerType = typeof(UserManagementService);
            Uri userManageSerTcpUri = new Uri("net.tcp://localhost:8010/UserManagementService");
            Uri userManageSerHttpUri = new Uri("http://localhost:8000/UserManagementService");
            ServiceHost userServiceHost = new ServiceHost(userManageSerType, userManageSerTcpUri, userManageSerHttpUri);
            userServiceHost.Open();
            Console.WriteLine("User Management Service Hosted Successfully...........\n\n");
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();
            userServiceHost.Close();
        }
    }
}
