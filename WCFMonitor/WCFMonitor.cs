using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCFMonitor
{
    public class WCFMonitor : IWCFMonitor
    {
        public string GetProcessInfo(string ServiceName)
        {
            ServiceHostBase host = ServiceHostExtensions.GetServiceHost(ServiceName);
            if (host == null)
                return string.Empty;
            ProcessInfoData pi = new ProcessInfoData(host);
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Process Name: {0}{1}", pi.ProcessName, Environment.NewLine);
            sb.AppendFormat("ServiceName Name: {0}{1}", pi.ServiceName, Environment.NewLine);
            sb.AppendFormat("ServiceHostType: {0}{1}", pi.ServiceHostType, Environment.NewLine);
            sb.AppendFormat("ConcurrencyMode: {0}{1}", pi.ServiceConcurrencyMode.ToString(), Environment.NewLine);
            sb.AppendFormat("InstanceContextMode: {0}{1}", pi.ServiceInstanceContextMode.ToString(), Environment.NewLine);
            sb.AppendFormat("GCMode: {0}{1}", pi.GCMode, Environment.NewLine);
            sb.AppendFormat("Bitness: {0}{1}", pi.Bitness, Environment.NewLine);
            sb.AppendFormat("MaxCalls: {0}{1}", pi.MaxCalls, Environment.NewLine);
            sb.AppendFormat("Calls: {0}{1}", pi.Calls, Environment.NewLine);
            sb.AppendFormat("MaxSessions: {0}{1}", pi.MaxSessions, Environment.NewLine);
            sb.AppendFormat("Sessions: {0}{1}", pi.Sessions, Environment.NewLine);
            sb.AppendFormat("MaxInstances: {0}{1}", pi.MaxInstances, Environment.NewLine);
            sb.AppendFormat("Behaviors: {0}", Environment.NewLine);
            int i = 0;
            foreach(string beh in pi.ServiceBehaviors)
            {
                sb.AppendFormat("\t{0,3}: {1}{2}",i.ToString(), beh, Environment.NewLine);
                i++;
            }
            sb.AppendFormat("LastError: {0}{1}", pi.LastError, Environment.NewLine);

            string retval = sb.ToString();

            return retval;
        }

        public ProcessInfoData GetProcessObjInfo(string ServiceName)
        {
            ServiceHostBase host = ServiceHostExtensions.GetServiceHost(ServiceName);
            if (host == null)
                return null;
            ProcessInfoData pi = new ProcessInfoData(host);
            return pi;
        }
    }
}
