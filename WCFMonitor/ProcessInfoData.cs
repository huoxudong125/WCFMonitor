using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace WCFMonitor
{
    [DataContract]
    public class ProcessInfoData
    {
        public ProcessInfoData()
        { }
        protected FieldInfo GetField(Type type, string FieldName)
        {
            return type.GetField(FieldName, BindingFlags.Instance | BindingFlags.NonPublic);
        }

        protected ServiceHostBase host = null;

        private string lastError = null;

        [DataMember]
        public string LastError
        {
            get { return lastError; }
            set { lastError = value; }
        }

        [DataMember]
        public bool IsError
        {
            get
            {
                return !String.IsNullOrEmpty(LastError);
            }
            set { }
        }

        private string serviceName;
        public string ServiceName
        {
            get { return serviceName; }
            set { serviceName = value; }
        }

        private int maxCalls;

        [DataMember]
        public int MaxCalls
        {
            get { return maxCalls; }
            set { maxCalls = value; }
        }


        private int maxSessions;

        [DataMember]
        public int MaxSessions
        {
            get { return maxSessions; }
            set { maxSessions = value; }
        }

        private int maxInstances;

        [DataMember]
        public int MaxInstances
        {
            get { return maxInstances; }
            set { maxInstances = value; }
        }

        private int calls;

        [DataMember]
        public int Calls
        {
            get { return calls; }
            set { calls = value; }
        }

        private int sessions;

        [DataMember]
        public int Sessions
        {
            get { return sessions; }
            set { sessions = value; }
        }

        private string userName;

        [DataMember]
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        private string servicehostType;
        [DataMember]
        public string ServiceHostType
        {
            get { return servicehostType; }
            set { servicehostType = value; }
        }

        private string authType;

        [DataMember]
        public string AuthType
        {
            get { return authType; }
            set { authType = value; }
        }

        private ConcurrencyMode serviceConcurrencyMode;

        [DataMember]
        public ConcurrencyMode ServiceConcurrencyMode
        {
            get { return serviceConcurrencyMode; }
            set { serviceConcurrencyMode = value; }
        }

        private InstanceContextMode instanceContextMode;
        [DataMember]
        public InstanceContextMode ServiceInstanceContextMode
        {
            get { return instanceContextMode; }
            set { instanceContextMode = value; }
        }

        private IEnumerable<string> serviceBehaviors;
        [DataMember]
        public IEnumerable<string> ServiceBehaviors
        {
            get { return serviceBehaviors; }
            set { serviceBehaviors = value; }
        }

        internal ProcessInfoData(ServiceHostBase Host)
        {

            if (Host == null)
            {
                lastError = "FATALERROR: Host cannot be null (ProcessInfo)";
                return;
            }
            try
            {
                serviceName = Host.Description.Name;
                maxCalls = 0;
                maxInstances = 0;
                calls = 0;
                sessions = 0;
                
                maxCalls = Host.GetMaxCalls();
                MaxSessions = Host.GetMaxSessions();
                MaxInstances = Host.GetMaxInstances();

                sessions = Host.GetCurrentSessions();
                calls = Host.GetCurrentCalls();
                servicehostType = Host.GetServiceType().ToString();
                serviceConcurrencyMode = Host.GetConcurrencyMode();
                instanceContextMode = Host.GetInstanceContextMode();
                serviceBehaviors = Host.GetServiceBehaviors();


            }
            catch (Exception ex)
            {
                lastError = ex.Message;
            }


        }

        [DataMember]
        public string ProcessName
        {
            get
            {
                return Process.GetCurrentProcess().ProcessName;
            }
            set { }
        }

        [DataMember]
        public string GCMode
        {
            get
            {
                return System.Runtime.GCSettings.IsServerGC ? "Server" : "Workstation";
            }
            set { }
        }

        [DataMember]
        public byte Bitness
        {
            get
            {
                return sizeof(ulong) * 8;

            }
            set { }
        }


    }

}
