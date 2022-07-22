using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerMyFirstAPI
{
    public static class MyConfig
    {
        public static string ConnectionString { get { return @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MyFirstAPI;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"; } }
        public static string QueueName = "queuePOST";
        public static string HostName = "localhost";
    }
}
