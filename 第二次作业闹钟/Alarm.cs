using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AlarmClock
{
    public delegate void AlarmHandler(object sender, DateTime time);
    class Alarm
    {
        public event AlarmHandler OnAlarm;
        public event AlarmHandler OnTick;

        public void Start()
        {
            OnAlarm += OnAlarm_Process;
            OnTick += OnTick_Process;
            DateTime AlarmTime = DateTime.Now.AddSeconds(5);
            while (true)
            {
                DateTime CurTime = DateTime.Now;
                TimeSpan delta = AlarmTime - CurTime;
                // 误差小于0.1秒触发闹钟事件
                if(Math.Abs(delta.TotalSeconds) < 0.1) { 
                    OnAlarm(this, AlarmTime); 
                }
                OnTick(this, CurTime);
                Thread.Sleep(1000);
            }
        }

        void OnAlarm_Process(Object sender,DateTime time)
        {
            Console.WriteLine($"闹钟:{time}");
        }
        void OnTick_Process(Object sender,DateTime time)
        {
            Console.WriteLine($"现在时间:{time}");
        }
    }
}
