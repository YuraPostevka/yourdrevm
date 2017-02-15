using BAL.Managers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace NotificationService
{
    public partial class Scheduler : ServiceBase
    {
        private int sleepTime = 30000;
        CancellationTokenSource tokenSource = new CancellationTokenSource();
        public Scheduler()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            //set only one thread(ex:  task.sleep(5sec))
            var t = Task.Run(() =>
            {

                while (!tokenSource.Token.IsCancellationRequested)
                {
                    CheckAndSendNotifications();
                    Thread.Sleep(sleepTime);
                }

            }, tokenSource.Token);
        }

        private void CheckAndSendNotifications()
        {
            NotificationServiceManager.WriteErrorLog("Timer ticked and job has been started: " + Thread.CurrentThread.ManagedThreadId);
        }

        protected override void OnStop()
        {
            tokenSource.Cancel();
            NotificationServiceManager.WriteErrorLog("Service stopped.");
        }
    }
}
