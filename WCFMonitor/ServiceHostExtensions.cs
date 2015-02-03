﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace WCFMonitor
{
    public static class ServiceHostExtensions
    {
        public static ConcurrentDictionary<string, ServiceHostBase> serviceHostBases = new ConcurrentDictionary<string, ServiceHostBase>();
        private static FieldInfo serviceThrottleField;
        private static FieldInfo callsField;
        private static FieldInfo callsCountField;
        private static FieldInfo sessionsField;
        private static FieldInfo sessionsCountField;

        static ServiceHostExtensions()
        {
            Type serviceHostType = typeof(ServiceHostBase);
            serviceThrottleField = GetField(serviceHostType, "serviceThrottle");
            Type ServiceThrottleType = typeof(ServiceThrottle);
            callsField = GetField(ServiceThrottleType, "calls");
            callsCountField = GetField(callsField.FieldType, "count");
            sessionsField = GetField(ServiceThrottleType, "sessions");
            sessionsCountField = GetField(sessionsField.FieldType, "count");
        }

        private static FieldInfo GetField(Type type, string FieldName)
        {
            return type.GetField(FieldName, BindingFlags.Instance | BindingFlags.NonPublic);
        }

        public static void AddServiceHostForMonitoring(this ServiceHostBase host)
        {
            Debug.WriteLine("Trying to add " + host.Description.Name + " to monitored services");
            if (!serviceHostBases.TryAdd(host.Description.Name, host))
            {
                Debug.WriteLine("Cannot add " + host.Description.Name + " for monitoring");
            }
            else
            {
                Debug.WriteLine("Added " + host.Description.Name + " to monitored services");
            }
        }

        public static void RemoveServiceHostFromMonitoring(this ServiceHostBase host)
        {
            Debug.WriteLine("Removing ServiceHost " + host.Description.Name + " from monitoring");
            ServiceHostBase sh = null;
            if (!serviceHostBases.TryRemove(host.Description.Name,out sh))
            {
                Debug.WriteLine("Unable to remove ServiceHost " + host.Description.Name + " from monitoring");
            }
            else
            {
                Debug.WriteLine("Removed ServiceHost " + host.Description.Name + " from monitoring");
            }
        }

        public static ServiceHostBase GetServiceHost(string name)
        {
            ServiceHostBase host = null;
            if (ServiceHostExtensions.serviceHostBases.TryGetValue(name,out host))
            {
                return host;
            }
            return null;
        }

        private static ServiceThrottlingBehavior GetThrottleBehavior(this ServiceHostBase host)
        {
            ServiceThrottlingBehavior throttle = host.Description.Behaviors.Find<ServiceThrottlingBehavior>();
            return throttle;
        }


        public static int GetMaxCalls(this ServiceHostBase host)
        {
            ServiceThrottlingBehavior throttle = host.GetThrottleBehavior();
            if (throttle != null)
            {
                return throttle.MaxConcurrentCalls;
            }
            return 0;
        }

        public static int GetMaxSessions(this ServiceHostBase host)
        {
            ServiceThrottlingBehavior throttle = host.GetThrottleBehavior();
            if (throttle != null)
            {
                return throttle.MaxConcurrentSessions;
            }
            return 0;
        }

        public static int GetMaxInstances(this ServiceHostBase host)
        {
            ServiceThrottlingBehavior throttle = host.GetThrottleBehavior();
            if (throttle != null)
            {
                return throttle.MaxConcurrentInstances;
            }
            return 0;
        }


        public static int GetCurrentCalls(this ServiceHostBase host)
        {
            ServiceThrottle throttle = serviceThrottleField.GetValue(host) as ServiceThrottle;
            object Calls = callsField.GetValue(throttle);
            int numCalls = (int)callsCountField.GetValue(Calls);
            return numCalls;
        }

        public static int GetCurrentSessions(this ServiceHostBase host)
        {
            ServiceThrottle throttle = serviceThrottleField.GetValue(host) as ServiceThrottle;
            object Sessions = sessionsField.GetValue(throttle);
            int numSessions = (int)sessionsCountField.GetValue(Sessions);
            return numSessions;
        }

    }
}