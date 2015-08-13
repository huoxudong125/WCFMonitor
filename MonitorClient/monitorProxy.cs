﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Collections.Generic;
namespace WCFMonitor
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ProcessInfoData", Namespace="http://schemas.datacontract.org/2004/07/WCFMonitor")]
    public partial class ProcessInfoData : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private string AuthTypeField;
        
        private byte BitnessField;
        
        private int CallsField;
        
        private string GCModeField;
        
        private bool IsErrorField;
        
        private string LastErrorField;
        
        private int MaxCallsField;
        
        private int MaxInstancesField;
        
        private int MaxSessionsField;
        
        private string ProcessNameField;
        
        private string[] ServiceBehaviorsField;
        
        private System.ServiceModel.ConcurrencyMode ServiceConcurrencyModeField;
        
        private string ServiceHostTypeField;
        
        private System.ServiceModel.InstanceContextMode ServiceInstanceContextModeField;
        
        private int SessionsField;
        
        private string UserNameField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string AuthType
        {
            get
            {
                return this.AuthTypeField;
            }
            set
            {
                this.AuthTypeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public byte Bitness
        {
            get
            {
                return this.BitnessField;
            }
            set
            {
                this.BitnessField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Calls
        {
            get
            {
                return this.CallsField;
            }
            set
            {
                this.CallsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string GCMode
        {
            get
            {
                return this.GCModeField;
            }
            set
            {
                this.GCModeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsError
        {
            get
            {
                return this.IsErrorField;
            }
            set
            {
                this.IsErrorField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LastError
        {
            get
            {
                return this.LastErrorField;
            }
            set
            {
                this.LastErrorField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int MaxCalls
        {
            get
            {
                return this.MaxCallsField;
            }
            set
            {
                this.MaxCallsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int MaxInstances
        {
            get
            {
                return this.MaxInstancesField;
            }
            set
            {
                this.MaxInstancesField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int MaxSessions
        {
            get
            {
                return this.MaxSessionsField;
            }
            set
            {
                this.MaxSessionsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ProcessName
        {
            get
            {
                return this.ProcessNameField;
            }
            set
            {
                this.ProcessNameField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string[] ServiceBehaviors
        {
            get
            {
                return this.ServiceBehaviorsField;
            }
            set
            {
                this.ServiceBehaviorsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.ServiceModel.ConcurrencyMode ServiceConcurrencyMode
        {
            get
            {
                return this.ServiceConcurrencyModeField;
            }
            set
            {
                this.ServiceConcurrencyModeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ServiceHostType
        {
            get
            {
                return this.ServiceHostTypeField;
            }
            set
            {
                this.ServiceHostTypeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.ServiceModel.InstanceContextMode ServiceInstanceContextMode
        {
            get
            {
                return this.ServiceInstanceContextModeField;
            }
            set
            {
                this.ServiceInstanceContextModeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Sessions
        {
            get
            {
                return this.SessionsField;
            }
            set
            {
                this.SessionsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UserName
        {
            get
            {
                return this.UserNameField;
            }
            set
            {
                this.UserNameField = value;
            }
        }
    }
}


[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(Namespace="urn:WCFMonitor", ConfigurationName="IWCFMonitor")]
public interface IWCFMonitor
{
    
    [System.ServiceModel.OperationContractAttribute(Action="urn:WCFMonitor/IWCFMonitor/GetProcessInfo", ReplyAction="urn:WCFMonitor/IWCFMonitor/GetProcessInfoResponse")]
    string GetProcessInfo(string ServiceName);
    
    [System.ServiceModel.OperationContractAttribute(Action="urn:WCFMonitor/IWCFMonitor/GetProcessObjInfo", ReplyAction="urn:WCFMonitor/IWCFMonitor/GetProcessObjInfoResponse")]
    WCFMonitor.ProcessInfoData GetProcessObjInfo(string ServiceName);
    
    [System.ServiceModel.OperationContractAttribute(Action="urn:WCFMonitor/IWCFMonitor/GetServices", ReplyAction="urn:WCFMonitor/IWCFMonitor/GetServicesResponse")]
    List<string> GetServices();
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public interface IWCFMonitorChannel : IWCFMonitor, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public partial class WCFMonitorClient : System.ServiceModel.ClientBase<IWCFMonitor>, IWCFMonitor
{
    
    public WCFMonitorClient()
    {
    }
    
    public WCFMonitorClient(string endpointConfigurationName) : 
            base(endpointConfigurationName)
    {
    }
    
    public WCFMonitorClient(string endpointConfigurationName, string remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public WCFMonitorClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public WCFMonitorClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(binding, remoteAddress)
    {
    }
    
    public string GetProcessInfo(string ServiceName)
    {
        return base.Channel.GetProcessInfo(ServiceName);
    }
    
    public WCFMonitor.ProcessInfoData GetProcessObjInfo(string ServiceName)
    {
        return base.Channel.GetProcessObjInfo(ServiceName);
    }
    
    public List<string> GetServices()
    {
        return base.Channel.GetServices();
    }
}
