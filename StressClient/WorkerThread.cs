using System;
using System.Threading;
using System.Data;
using System.Diagnostics;


namespace Stress
{

	public class WorkerThread
	{
		private int m_intNumCalls;
        private int m_WaitPerCallmin;
        private int m_WaitPerCallmax;
		private double m_TotalCallTime;
		private System.Random rnd;
        int numFailures = 0;
        SeahawksClient proxy;

		public delegate void WorkerThreadEventHandler (object source, WorkerThreadEventArgs args);
 
		public event WorkerThreadEventHandler OnThreadStart;
		public event WorkerThreadEventHandler OnThreadCompleted;
		public event WorkerThreadEventHandler OnMethodStart;
		public event WorkerThreadEventHandler OnMethodCompleted;
		public event WorkerThreadEventHandler OnThreadAborted;
		public event WorkerThreadEventHandler OnThreadError;

        public WorkerThread(int intNumCalls, int WaitPerCallMin, int WaitPerCallMax)
		{
			m_intNumCalls = intNumCalls;
            m_WaitPerCallmax = WaitPerCallMax;
            m_WaitPerCallmin = WaitPerCallMin;
		}

		public void BeginThread()
		{

            proxy = new SeahawksClient("Seahawks");
			WorkerThreadEventArgs myargs = new WorkerThreadEventArgs();
            myargs.ThreadID = Thread.CurrentThread.ManagedThreadId;
			myargs.threadname = Thread.CurrentThread.Name;
			myargs.ThreadCallTime = TimeSpan.Zero;
			myargs.CallNumber = 0;
			myargs.err = null;
            myargs.numberOfFails = 0;
            if (OnThreadStart != null)
                OnThreadStart(this, myargs);
            rnd = new Random(System.DateTime.Now.Millisecond * Thread.CurrentThread.ManagedThreadId);
			System.DateTime ThreadStartTime = System.DateTime.Now;
			m_TotalCallTime = 0;

			try
			{
                Thread.Sleep(rnd.Next(m_WaitPerCallmin, m_WaitPerCallmax + 1) * 1000);
				for (int intCallCounter = 0; intCallCounter < m_intNumCalls; intCallCounter++)
				{
                    bool methodError = false;
					myargs.MethodCallTime = TimeSpan.Zero;
					myargs.err = null;
					myargs.CallNumber = intCallCounter;
					
					if (OnMethodStart!=null)
						OnMethodStart(this, myargs);

					System.DateTime MethodStartTime = System.DateTime.Now;
                    TimeSpan methodcalltime;

					//*****************************
					//Make the call

                    try
                    {
                        DoSomething();
                    }
                    catch (Exception ex)
                    {
                        myargs.err = ex;
                        numFailures++;
                        myargs.numberOfFails = numFailures ;
                        methodError = true;

                        methodcalltime = System.DateTime.Now - MethodStartTime;
                        myargs.MethodCallTime = methodcalltime;
                        myargs.ThreadCallTime = (System.DateTime.Now - ThreadStartTime);
                        m_TotalCallTime += methodcalltime.TotalSeconds;
                        myargs.AverageCallTime = m_TotalCallTime / (intCallCounter + 1);
                        if (OnThreadError != null)
                            OnThreadError(this, myargs);
                    }


					//End Making the call
					//*****************************

                    if (!methodError)
                    {
                        methodcalltime = System.DateTime.Now - MethodStartTime;
                        myargs.MethodCallTime = methodcalltime;
                        myargs.ThreadCallTime = (System.DateTime.Now - ThreadStartTime);
                        m_TotalCallTime += methodcalltime.TotalSeconds;
                        myargs.AverageCallTime = m_TotalCallTime / (intCallCounter + 1);
                        if (OnMethodCompleted != null)
                            OnMethodCompleted(this, myargs);
                    }

                    if (intCallCounter < m_intNumCalls-1)
                    {
                        int sleeptime = rnd.Next(m_WaitPerCallmin, m_WaitPerCallmax + 1);
                        Thread.Sleep(sleeptime * 1000);
                    }

				}
				myargs.ThreadCallTime = (System.DateTime.Now - ThreadStartTime);
				if (OnThreadCompleted!=null)
					OnThreadCompleted(this,myargs);
			}

			catch(ThreadAbortException err)
			{
				myargs.ThreadCallTime = (System.DateTime.Now - ThreadStartTime);
				myargs.err = err;
				if (OnThreadAborted!=null)
					OnThreadAborted(this,myargs);
			}



			catch(Exception err)
			{
				myargs.ThreadCallTime = (System.DateTime.Now - ThreadStartTime);
				myargs.err = err;
				if (OnThreadError!=null)
					OnThreadError(this,myargs);
			}


		}


		void DoSomething()
		{
            try
            {
                proxy.BeatTheBroncos(35);
                proxy.BeatTheNiners(14);
                proxy.WinSuperbowl();
                
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

		}

	}
}
