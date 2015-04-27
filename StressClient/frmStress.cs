using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Threading;

namespace Stress
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class frmStress : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ColumnHeader clmInCall;
		private System.Windows.Forms.ColumnHeader clmThreadStatus;
		private System.Windows.Forms.ColumnHeader clmThreadID;
		private System.Windows.Forms.ListView lsvResults;
		private System.Windows.Forms.ColumnHeader clmThread;
		private System.Windows.Forms.ColumnHeader clmCallNumber;
		private System.Windows.Forms.ColumnHeader clmLastCallTime;
		private System.Windows.Forms.ColumnHeader clmAverageCallTime;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button cmdAbortAll;
		private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.TextBox txtWaitPerCallMin;
		private System.Windows.Forms.TextBox txtCallsPerThread;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ProgressBar prgCompletedCalls;
		private System.Windows.Forms.TextBox txtNumThreads;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button cmdBegin;


		Thread[] MyThreads = null;
		int intNumThreads = 0;
		int intCallsPerThread = 0;
        int waitTimePerCallMin;
        int waitTimePerCallMax;
		double[,] CallTimes = null;
		int intNumThreadsCompleted = 0;
		private System.Windows.Forms.ContextMenu cmnuResults;
		private System.Windows.Forms.MenuItem mnuAbort;
        private ColumnHeader clmNumFailures;
        private TextBox txtWaitPerCallMax;
        private GroupBox groupBox1;
        private Label label6;
        private Label label5;


		private enum ColumnIndex
		{
			ThreadNum = 0,
			ThreadID = 1,
			InCall = 2,
			ThreadStatus = 3,
			CallNumber = 4,
			LastCallTime = 5,
			AverageCallTime = 6,
            Failures = 7
		}



		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmStress()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.clmInCall = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmThreadStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmThreadID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lsvResults = new System.Windows.Forms.ListView();
            this.clmThread = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmCallNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmLastCallTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmAverageCallTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmnuResults = new System.Windows.Forms.ContextMenu();
            this.mnuAbort = new System.Windows.Forms.MenuItem();
            this.label4 = new System.Windows.Forms.Label();
            this.cmdAbortAll = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.txtWaitPerCallMin = new System.Windows.Forms.TextBox();
            this.txtCallsPerThread = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.prgCompletedCalls = new System.Windows.Forms.ProgressBar();
            this.txtNumThreads = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdBegin = new System.Windows.Forms.Button();
            this.clmNumFailures = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtWaitPerCallMax = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // clmInCall
            // 
            this.clmInCall.Text = "In Call";
            this.clmInCall.Width = 51;
            // 
            // clmThreadStatus
            // 
            this.clmThreadStatus.Text = "ThreadStatus";
            this.clmThreadStatus.Width = 95;
            // 
            // clmThreadID
            // 
            this.clmThreadID.Text = "ThreadID";
            this.clmThreadID.Width = 61;
            // 
            // lsvResults
            // 
            this.lsvResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmThread,
            this.clmThreadID,
            this.clmInCall,
            this.clmThreadStatus,
            this.clmCallNumber,
            this.clmLastCallTime,
            this.clmAverageCallTime,
            this.clmNumFailures});
            this.lsvResults.ContextMenu = this.cmnuResults;
            this.lsvResults.FullRowSelect = true;
            this.lsvResults.Location = new System.Drawing.Point(17, 216);
            this.lsvResults.MultiSelect = false;
            this.lsvResults.Name = "lsvResults";
            this.lsvResults.Size = new System.Drawing.Size(585, 272);
            this.lsvResults.TabIndex = 21;
            this.lsvResults.UseCompatibleStateImageBehavior = false;
            this.lsvResults.View = System.Windows.Forms.View.Details;
            this.lsvResults.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lsvResults_MouseDown);
            // 
            // clmThread
            // 
            this.clmThread.Text = "Thread";
            this.clmThread.Width = 47;
            // 
            // clmCallNumber
            // 
            this.clmCallNumber.Text = "Call Number";
            this.clmCallNumber.Width = 77;
            // 
            // clmLastCallTime
            // 
            this.clmLastCallTime.Text = "Last Call Time";
            this.clmLastCallTime.Width = 83;
            // 
            // clmAverageCallTime
            // 
            this.clmAverageCallTime.Text = "Average Call Time";
            this.clmAverageCallTime.Width = 110;
            // 
            // cmnuResults
            // 
            this.cmnuResults.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuAbort});
            // 
            // mnuAbort
            // 
            this.mnuAbort.DefaultItem = true;
            this.mnuAbort.Index = 0;
            this.mnuAbort.Text = "ABORT";
            this.mnuAbort.Click += new System.EventHandler(this.mnuAbort_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(120, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 24);
            this.label4.TabIndex = 23;
            this.label4.Text = "Right click to abort a thread";
            this.label4.UseCompatibleTextRendering = true;
            // 
            // cmdAbortAll
            // 
            this.cmdAbortAll.Location = new System.Drawing.Point(40, 160);
            this.cmdAbortAll.Name = "cmdAbortAll";
            this.cmdAbortAll.Size = new System.Drawing.Size(75, 23);
            this.cmdAbortAll.TabIndex = 22;
            this.cmdAbortAll.Text = "Abort All";
            this.cmdAbortAll.UseCompatibleTextRendering = true;
            this.cmdAbortAll.Click += new System.EventHandler(this.cmdAbortAll_Click);
            // 
            // lblError
            // 
            this.lblError.Location = new System.Drawing.Point(378, 27);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(224, 160);
            this.lblError.TabIndex = 20;
            this.lblError.Click += new System.EventHandler(this.lblError_Click);
            // 
            // txtWaitPerCallMin
            // 
            this.txtWaitPerCallMin.Location = new System.Drawing.Point(7, 29);
            this.txtWaitPerCallMin.Name = "txtWaitPerCallMin";
            this.txtWaitPerCallMin.Size = new System.Drawing.Size(40, 20);
            this.txtWaitPerCallMin.TabIndex = 19;
            this.txtWaitPerCallMin.Text = "1";
            // 
            // txtCallsPerThread
            // 
            this.txtCallsPerThread.Location = new System.Drawing.Point(152, 56);
            this.txtCallsPerThread.Name = "txtCallsPerThread";
            this.txtCallsPerThread.Size = new System.Drawing.Size(100, 20);
            this.txtCallsPerThread.TabIndex = 17;
            this.txtCallsPerThread.Text = "1";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(40, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 23);
            this.label2.TabIndex = 16;
            this.label2.Text = "Number of Calls Per Thread";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label2.UseCompatibleTextRendering = true;
            // 
            // prgCompletedCalls
            // 
            this.prgCompletedCalls.Location = new System.Drawing.Point(17, 198);
            this.prgCompletedCalls.Name = "prgCompletedCalls";
            this.prgCompletedCalls.Size = new System.Drawing.Size(585, 10);
            this.prgCompletedCalls.TabIndex = 15;
            // 
            // txtNumThreads
            // 
            this.txtNumThreads.Location = new System.Drawing.Point(152, 24);
            this.txtNumThreads.Name = "txtNumThreads";
            this.txtNumThreads.Size = new System.Drawing.Size(100, 20);
            this.txtNumThreads.TabIndex = 12;
            this.txtNumThreads.Text = "1";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(40, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "Number of Threads:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.UseCompatibleTextRendering = true;
            // 
            // cmdBegin
            // 
            this.cmdBegin.Location = new System.Drawing.Point(40, 128);
            this.cmdBegin.Name = "cmdBegin";
            this.cmdBegin.Size = new System.Drawing.Size(75, 23);
            this.cmdBegin.TabIndex = 13;
            this.cmdBegin.Text = "Begin Test";
            this.cmdBegin.UseCompatibleTextRendering = true;
            this.cmdBegin.Click += new System.EventHandler(this.cmdBegin_Click);
            // 
            // clmNumFailures
            // 
            this.clmNumFailures.Text = "Failures";
            // 
            // txtWaitPerCallMax
            // 
            this.txtWaitPerCallMax.Location = new System.Drawing.Point(56, 29);
            this.txtWaitPerCallMax.Name = "txtWaitPerCallMax";
            this.txtWaitPerCallMax.Size = new System.Drawing.Size(40, 20);
            this.txtWaitPerCallMax.TabIndex = 24;
            this.txtWaitPerCallMax.Text = "3";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtWaitPerCallMax);
            this.groupBox1.Controls.Add(this.txtWaitPerCallMin);
            this.groupBox1.Location = new System.Drawing.Point(258, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(107, 55);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Wait Per Call";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Min";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(53, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "Max";
            // 
            // frmStress
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(632, 507);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmdAbortAll);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.txtCallsPerThread);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.prgCompletedCalls);
            this.Controls.Add(this.txtNumThreads);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdBegin);
            this.Controls.Add(this.lsvResults);
            this.Name = "frmStress";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stress Me Out";
            this.Load += new System.EventHandler(this.frmStress_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new frmStress());
		}

		private void frmStress_Load(object sender, System.EventArgs e)
		{
		
		}


		void myWorkerThread_OnMethodStart(object source, WorkerThreadEventArgs args)
		{
			int Threadnum = Convert.ToInt16(args.threadname);
			lsvResults.Items[Threadnum].SubItems[(int)ColumnIndex.InCall].Text = "true";
			lsvResults.Items[Threadnum].SubItems[(int)ColumnIndex.CallNumber].Text = args.CallNumber.ToString();
		}

		void myWorkerThread_OnMethodCompleted(object source, WorkerThreadEventArgs args)
		{
			int Threadnum = Convert.ToInt16(args.threadname);
			double dblCallTime = args.MethodCallTime.TotalSeconds;
			CallTimes[Threadnum,args.CallNumber] = dblCallTime;
			
			decimal decCallTime = Convert.ToDecimal(dblCallTime);
			decCallTime = decimal.Round(decCallTime,2);
			decimal decAverageTime = Convert.ToDecimal(args.AverageCallTime);
			decAverageTime = decimal.Round(decAverageTime,2);

			lsvResults.Items[Threadnum].SubItems[(int)ColumnIndex.InCall].Text = "false";
			lsvResults.Items[Threadnum].SubItems[(int)ColumnIndex.LastCallTime].Text = decCallTime.ToString();
			lsvResults.Items[Threadnum].SubItems[(int)ColumnIndex.AverageCallTime].Text = decAverageTime.ToString();
            lsvResults.Items[Threadnum].BackColor = System.Drawing.Color.White;
            lsvResults.Items[Threadnum].SubItems[(int)ColumnIndex.ThreadStatus].Text = "Running";

			prgCompletedCalls.PerformStep();
		}


		void myWorkerThread_OnThreadStart(object source, WorkerThreadEventArgs args)
		{
			int Threadnum = Convert.ToInt16(args.threadname);
			lsvResults.Items[Threadnum].SubItems[(int)ColumnIndex.ThreadID].Text = args.ThreadID.ToString();
			lsvResults.Items[Threadnum].SubItems[(int)ColumnIndex.ThreadStatus].Text = "Running";
            lsvResults.Items[Threadnum].SubItems[(int)ColumnIndex.Failures].Text = args.numberOfFails.ToString();
		}
		

		void myWorkerThread_OnThreadCompleted(object source, WorkerThreadEventArgs args)
		{
			intNumThreadsCompleted++;
			if (intNumThreadsCompleted == intNumThreads)
				cmdBegin.Enabled = true;

			int Threadnum = Convert.ToInt16(args.threadname);
			double dblTotalCallTime = 0;
			double dblAverageCallTime = 0;
			for(int CallCounter=0;CallCounter<intCallsPerThread;CallCounter++)
				dblTotalCallTime += CallTimes[Threadnum,CallCounter];
			dblAverageCallTime = dblTotalCallTime / intCallsPerThread;

			decimal decAverageCallTime = Convert.ToDecimal(dblAverageCallTime);
			decAverageCallTime = decimal.Round(decAverageCallTime,2);
			string strAverageCallTime = string.Format("{0}",dblAverageCallTime);

			lsvResults.Items[Threadnum].SubItems[(int)ColumnIndex.InCall].Text = "false";
			lsvResults.Items[Threadnum].SubItems[(int)ColumnIndex.ThreadStatus].Text = "Finished";
			lsvResults.Items[Threadnum].SubItems[(int)ColumnIndex.AverageCallTime].Text = decAverageCallTime.ToString();
			lsvResults.Items[Threadnum].BackColor = System.Drawing.Color.DeepSkyBlue;
		}


		void myWorkerThread_OnThreadAborted(object source, WorkerThreadEventArgs args)
		{
			intNumThreadsCompleted++;
			if (intNumThreadsCompleted == intNumThreads)
				cmdBegin.Enabled = true;
			int Threadnum = Convert.ToInt16(args.threadname);
			lsvResults.Items[Threadnum].SubItems[(int)ColumnIndex.InCall].Text = "false";
			lsvResults.Items[Threadnum].SubItems[(int)ColumnIndex.ThreadStatus].Text = "Aborted";
			lsvResults.Items[Threadnum].BackColor = System.Drawing.Color.Yellow;
		}


		void myWorkerThread_OnThreadError(object source, WorkerThreadEventArgs args)
		{
			intNumThreadsCompleted++;
			if (intNumThreadsCompleted == intNumThreads)
				cmdBegin.Enabled = true;
			string results = string.Format("Error:  Thread {0}\t   Call#: {1}\n{2}",
				args.threadname,
				args.CallNumber,
				args.err.Message);
			lblError.Text = lblError.Text + results + "\n";
			int Threadnum = Convert.ToInt16(args.threadname);

            double dblCallTime = args.MethodCallTime.TotalSeconds;
            CallTimes[Threadnum, args.CallNumber] = dblCallTime;

            decimal decCallTime = Convert.ToDecimal(dblCallTime);
            decCallTime = decimal.Round(decCallTime, 2);
            decimal decAverageTime = Convert.ToDecimal(args.AverageCallTime);
            decAverageTime = decimal.Round(decAverageTime, 2);

            lsvResults.Items[Threadnum].SubItems[(int)ColumnIndex.LastCallTime].Text = decCallTime.ToString();
            lsvResults.Items[Threadnum].SubItems[(int)ColumnIndex.AverageCallTime].Text = decAverageTime.ToString();
			lsvResults.Items[Threadnum].SubItems[(int)ColumnIndex.InCall].Text = "false";
			lsvResults.Items[Threadnum].SubItems[(int)ColumnIndex.ThreadStatus].Text = "Error";
			lsvResults.Items[Threadnum].BackColor = System.Drawing.Color.Goldenrod;
            lsvResults.Items[Threadnum].SubItems[(int)ColumnIndex.Failures].Text = args.numberOfFails.ToString();
            prgCompletedCalls.PerformStep();
		}


		private void cmdBegin_Click(object sender, System.EventArgs e)
		{
			lblError.Text = "";
			intNumThreadsCompleted = 0;
			cmdBegin.Enabled = false;

			intNumThreads = Convert.ToInt16(txtNumThreads.Text);
			intCallsPerThread = Convert.ToInt16(txtCallsPerThread.Text);
            waitTimePerCallMin = Convert.ToInt16(txtWaitPerCallMin.Text);
            waitTimePerCallMax = Convert.ToInt16(txtWaitPerCallMax.Text );
			CallTimes = new double[intNumThreads,intCallsPerThread];

			prgCompletedCalls.Value = 0;
			prgCompletedCalls.Maximum = intCallsPerThread * intNumThreads;
			prgCompletedCalls.Step = 1;

			lsvResults.Items.Clear();
           

			MyThreads = new Thread[intNumThreads];
			for (int intThreadStartCounter = 0; intThreadStartCounter < intNumThreads; intThreadStartCounter++)
			{
				ListViewItem lsvItem = lsvResults.Items.Add(intThreadStartCounter.ToString());
				for (int counter=0;counter<7;counter++)
					lsvItem.SubItems.Add("");
				lsvItem.SubItems[(int)ColumnIndex.ThreadNum].Text = intThreadStartCounter.ToString();
				lsvItem.SubItems[(int)ColumnIndex.InCall].Text = "false"; 
				lsvItem.SubItems[(int)ColumnIndex.ThreadStatus].Text = "Not Started";
                lsvItem.SubItems[(int)ColumnIndex.Failures].Text = "0";

                WorkerThread myWorkerThread = new WorkerThread(intCallsPerThread, waitTimePerCallMin, waitTimePerCallMax);
				myWorkerThread.OnMethodStart +=new Stress.WorkerThread.WorkerThreadEventHandler(myWorkerThread_OnMethodStart);
				myWorkerThread.OnMethodCompleted +=new Stress.WorkerThread.WorkerThreadEventHandler(myWorkerThread_OnMethodCompleted);
				myWorkerThread.OnThreadStart +=new Stress.WorkerThread.WorkerThreadEventHandler(myWorkerThread_OnThreadStart);
				myWorkerThread.OnThreadCompleted +=new Stress.WorkerThread.WorkerThreadEventHandler(myWorkerThread_OnThreadCompleted);
				myWorkerThread.OnThreadError +=new Stress.WorkerThread.WorkerThreadEventHandler(myWorkerThread_OnThreadError);
				myWorkerThread.OnThreadAborted +=new Stress.WorkerThread.WorkerThreadEventHandler(myWorkerThread_OnThreadAborted);

				ThreadStart thrdstrt = new ThreadStart(myWorkerThread.BeginThread);
				MyThreads[intThreadStartCounter] = new Thread(thrdstrt);
				MyThreads[intThreadStartCounter].Name = intThreadStartCounter.ToString();
				MyThreads[intThreadStartCounter].Start();
			}
		}



		private void lsvResults_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (lsvResults.SelectedItems.Count == 0)
				cmnuResults.MenuItems[0].Visible = false;
			else
				cmnuResults.MenuItems[0].Visible = true;

		}



		private void cmdAbortAll_Click(object sender, System.EventArgs e)
		{
			if (MyThreads == null)
				return;
			for (int counter = 0; counter < intNumThreads; counter++)
			{
				if (MyThreads[counter].IsAlive)
					MyThreads[counter].Abort();
			}
		}



		private void mnuAbort_Click(object sender, System.EventArgs e)
		{
			if (lsvResults.SelectedItems.Count == 0)
				return;
			string strThreadnum = lsvResults.SelectedItems[0].Text;
			lblError.Text = lblError.Text + "Aborting Thread: " + strThreadnum + "\n";
			int intThreadnum = Convert.ToInt16(strThreadnum);
			if (MyThreads[intThreadnum].IsAlive)
				MyThreads[intThreadnum].Abort();
		}

        private void lblError_Click(object sender, EventArgs e)
        {

        }




	}
}
