using System;

namespace Stress
{

	public class WorkerThreadEventArgs : EventArgs
	{
		public int CallNumber;
		public double AverageCallTime;
		public System.TimeSpan MethodCallTime;
		public System.TimeSpan ThreadCallTime;
		public string threadname;
		public int ThreadID;
        public int numberOfFails;
		public Exception err;

		public WorkerThreadEventArgs()
		{

		}
	}
}
