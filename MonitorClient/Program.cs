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
                string retval = proxy.GetProcessInfo("Seahawks");
                Console.WriteLine(retval);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
