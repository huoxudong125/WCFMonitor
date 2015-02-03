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
            string retval = string.Format("Process Name: {0}{10} ServiceName: {1}{10} GCMode: {2}{10} Bitness: {3}{10} MaxCalls: {4}{10} CurrentCalls: {5}{10} MaxSessions: {6}{10} CurrentSessions: {7}{10} MaxInstances: {8}{10} LastError: {9}{10}",
                pi.ProcessName,
                pi.ServiceName,
                pi.GCMode,
                pi.Bitness,
                pi.MaxCalls,
                pi.Calls,
                pi.MaxSessions,
                pi.Sessions,
                pi.MaxInstances,
                pi.LastError,
                Environment.NewLine);
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
