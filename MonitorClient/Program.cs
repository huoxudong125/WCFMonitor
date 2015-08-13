using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorClient
{
    class Program
    {
        static void Main(string[] args)
        {
            WCFMonitorClient proxy = new WCFMonitorClient("monitor");
            PermissiveCertificatePolicy.Enact("CN=localhost");

            try
            {
                var services = proxy.GetServices();
                Console.WriteLine("Serivces" + Environment.NewLine + "-----------------");
                foreach (string service in services)
                {
                    Console.WriteLine(service);
                }
                Console.WriteLine("-----------------" + Environment.NewLine);
                string retval = proxy.GetProcessInfo("Seahawks");
                Console.WriteLine(retval);
                Console.Read();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
