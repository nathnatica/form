﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class ApiCallTimer
    {
        public Control control;
        private int apiCallInterval = 1;
        private int interval;
        private Timer timer;

        public SortedDictionary<DateTime, Task> apiTasks;
        public SortedDictionary<DateTime, Task> tasks;
        private DateTime lastCall = DateTime.Now;

        public void SetInterval(int interval)
        {
            this.interval = interval;
        }

        public void Start()
        {
            timer = new Timer();
            timer.Interval = this.interval;
            timer.Tick += new EventHandler(OnTimerEvent);
            timer.Start();
        }

        public void Stop()
        {
            this.timer.Stop();
        }

        public void OnTimerEvent(object source, EventArgs e)
        {
            if (apiTasks.Count > 0)
            {
                DateTime k = apiTasks.First().Key;
                Task v = apiTasks.First().Value;

                if (lastCall.AddMilliseconds(apiCallInterval).CompareTo(DateTime.Now) < 0)
                {
                    if (v.type == Constants.TASK_TYPE_API_GET_ITEM)
                    {
                        control.Print("종목정보취득API콜. 종목: " + v.code);

                        // TODO API CALL
                        apiTasks.Remove(k);

                        Task t = new Task();
                        t.type = Constants.TASK_TYPE_GET_ITEM;
                        t.code = v.code;
                        tasks.Add(DateTime.Now, t);
                    }
                }
            }
        }
    }
}
