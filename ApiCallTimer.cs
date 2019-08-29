using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace WindowsFormsApp1
{
    class ApiCallTimer
    {
        private int interval;

        private Timer timer;

        public void SetInterval(int interval)
        {
            this.interval = interval;
        }

        public void Start()
        {
            timer = new Timer();
            timer.Interval = this.interval;
            timer.Elapsed += OnTimerEvent;
            timer.Start();
        }

        public void Stop()
        {
            this.timer.Stop();
        }

        public static void OnTimerEvent(object source, EventArgs e)
        {
            Console.WriteLine(DateTime.Now.ToString());
        }
    }
}
