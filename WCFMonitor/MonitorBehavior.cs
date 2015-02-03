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

namespace WCFMonitor
{
    public class MonitorBehavior : Attribute, IServiceBehavior
    {
        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        {

        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            serviceHostBase.AddServiceHostForMonitoring();
            serviceHostBase.Closing += serviceHostBase_Closing;
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
