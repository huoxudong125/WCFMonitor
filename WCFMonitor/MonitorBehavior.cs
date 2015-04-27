using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel.Description;
using System.ServiceModel.Channels;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel.Configuration;
using System.Diagnostics;

namespace WCFMonitor
{
    public class MonitorBehavior : Attribute, IServiceBehavior
    {
        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        {

        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            Debug.WriteLine("ServiceType: " + serviceDescription.ServiceType.ToString());
            serviceHostBase.AddServiceType(serviceDescription.ServiceType);
            ServiceBehaviorAttribute sbAtt = serviceHostBase.Description.Behaviors.Find<ServiceBehaviorAttribute>();
            if (sbAtt != null)
            {
                serviceHostBase.AddConcurrencyMode(sbAtt.ConcurrencyMode);
                serviceHostBase.AddInstanceContextMode(sbAtt.InstanceContextMode);
            }
            //serviceHostBase.AddConcurrencyMode(serviceHostBase.Description.Behaviors.


            serviceHostBase.AddServiceHostForMonitoring();


            serviceHostBase.Closing += serviceHostBase_Closing;
            serviceHostBase.Opened += serviceHostBase_Opened;
        }

        void serviceHostBase_Opened(object sender, EventArgs e)
        {
            ServiceHostBase host = sender as ServiceHostBase;
            host.SetBehaviors();

        }

        void serviceHostBase_Closing(object sender, EventArgs e)
        {
            ServiceHostBase host = sender as ServiceHostBase;
            host.RemoveServiceHostFromMonitoring();
        }

        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {

        }
    }

    public class MonitorBehaviorElement : BehaviorExtensionElement
    {
        public override Type BehaviorType
        {
            get { return typeof(MonitorBehavior); }
        }

        protected override object CreateBehavior()
        {
            return new MonitorBehavior();
        }
    }

}
