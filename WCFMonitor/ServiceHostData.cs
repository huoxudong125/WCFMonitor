using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace WCFMonitor
{
    public class ServiceHostData
    {
        private Type serviceType;
        private ConcurrencyMode conncurrencyMode;
        private InstanceContextMode instanceContextMode;
        private List<string> serviceBehaviors = new List<string>();

        public Type ServiceType 
        {
            get { return serviceType; }
            set { serviceType = value; }
        }

        public ConcurrencyMode ServiceConcurrencyMode
        {
            get { return conncurrencyMode; }
            set { conncurrencyMode = value; }
        }


        public InstanceContextMode ServiceInstanceContextMode
        {
            get { return instanceContextMode; }
            set { instanceContextMode = value; }
        }

        public List<string> ServiceBehaviors
        {
            get { return serviceBehaviors ; }
            set { serviceBehaviors =  value; }
        }
    }
}
