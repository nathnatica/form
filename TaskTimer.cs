using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class TaskTimer
    {
        public Control control;
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
            if (tasks.Count > 0)
            {
                DateTime k = tasks.First().Key;
                Task v = tasks.First().Value;

                if (v.type == Constants.TASK_TYPE_GET_ITEM)
                {
                    control.Print("종목정보취득태스크. 종목: " + v.code);

                    tasks.Remove(k);

                    Task t = new Task();
                    t.type = Constants.TASK_TYPE_GET_DAY;
                    t.code = v.code;
                    t.startDate = OpenDays.GetPrevDay(Constants.DAY_GET_COUNT);
                    t.endDate = OpenDays.GetToday();
                    tasks.Add(DateTime.Now, t);
                } else if (v.type == Constants.TASK_TYPE_GET_DAY)
                {
                    control.Print("일봉정보취득태스크. 종목: " + v.code + ", 시작일: " + v.startDate +  ", 종료일: " + v.endDate);

                    tasks.Remove(k);

                }
            }
        }
    }
}
