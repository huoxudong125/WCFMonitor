using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCFMonitor
{
    [ServiceContract(Namespace="urn:WCFMonitor")]
    interface IWCFMonitor
    {
        [OperationContract]
        string GetProcessInfo(string ServiceName);

        [OperationContract]
        ProcessInfoData GetProcessObjInfo(string ServiceName);

        [OperationContract]
        List<string> GetServices();
    }
}
