using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Component
{
    public class Seahawks : ISeahawks
    {
        public string BeatTheNiners(int pointSpread)
        {
            Debug.WriteLine("Thread: " + Thread.CurrentThread.ManagedThreadId.ToString() + "\t" + "BeatTheNiners");
            return "Go Hawks!";
        }

        public string BeatTheBroncos(int pointSpread)
        {
            Debug.WriteLine("Thread: " + Thread.CurrentThread.ManagedThreadId.ToString() + "\t" + "BeatTheBroncos");
            Thread.Sleep(1000);
            return "Feed the Beast!";
        }

        public string WinSuperbowl()
        {
            Debug.WriteLine("Thread: " + Thread.CurrentThread.ManagedThreadId.ToString() + "\t" + "WinSuperbowl");
            Thread.Sleep(5000);
            return "Legion of Boom!";
        }
    }

    public class Seahawks2 : ISeahawks
    {
        public string BeatTheNiners(int pointSpread)
        {
            Debug.WriteLine("Thread: " + Thread.CurrentThread.ManagedThreadId.ToString() + "\t" + "BeatTheNiners");
            return "Go Hawks!";
        }

        public string BeatTheBroncos(int pointSpread)
        {
            Debug.WriteLine("Thread: " + Thread.CurrentThread.ManagedThreadId.ToString() + "\t" + "BeatTheBroncos");
            Thread.Sleep(1000);
            return "Feed the Beast!";
        }

        public string WinSuperbowl()
        {
            Debug.WriteLine("Thread: " + Thread.CurrentThread.ManagedThreadId.ToString() + "\t" + "WinSuperbowl");
            Thread.Sleep(5000);
            return "Legion of Boom!";
        }
    }
}
