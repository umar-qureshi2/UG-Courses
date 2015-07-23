using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsFormsApplication4
{
    public class Process
    {
        public int arrival_time { get; set; }
        public int end_time { get; set; }
        public string name { get; set; }
        public int burst { get; set; }
        public int remaining_quantum { get; set; }
        public int remaining_burst { get; set; } // equals burst-remaining_quantum
        public int priority { get; set; }

        public Process(string Pname,int ArrivalTime, int BurstTime)
        {
            name = Pname;
            arrival_time = ArrivalTime>-1?ArrivalTime:10;
            remaining_burst = burst = BurstTime>0?BurstTime:10;
        }


        public static double getAvgWaiting(Process[] pList)
        {
            double wait = 0,count=0;
            for (int i = 0; i < pList.Length && pList[i]!=null && pList[i].end_time!=0; i++)
            {
                wait += pList[i].end_time - (pList[i].arrival_time + pList[i].burst);
                count++;
            }
            return count == 0 ? -1 : wait / count;
        }

        public static bool AllProcessesSimulated(Process[] Plist)
        {
            for (int i = 0; i < Plist.Length && Plist[i] != null; i++)
            {
                if (Plist[i].end_time == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
