using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApplication4
{
    class MLFeedbackQueues
    {
        public Process[] processes_list;
        public Queue<Process>[] MLFQ_Queues;
        public Process inCPU;
        public bool CPUavailable;
        public int current_time;
        public int SleepTime;

        public MLFeedbackQueues(Process[] PList)   //contructor takes processes list and gets ready to simulate them
        {
            MLFQ_Queues = new Queue<Process>[4];
            for (int i = 0; i < 4; i++)
            {
                MLFQ_Queues[i] = new Queue<Process>();
            }
            processes_list = PList;
            current_time = -1;
            CPUavailable = true;
            SleepTime = 10;   //it is animation delay
        }


        public bool Simulate(TextBox t1,TextBox t2, TextBox t3, TextBox t4, Label l1, Label time)
        {
            
            Application.DoEvents();
            current_time++;

            
            time.Text = current_time.ToString();
            
            for (int i = 0; i < processes_list.Length && processes_list[i]!=null; i++)
            {
                if (processes_list[i].arrival_time == current_time)
                {
                    processes_list[i].priority = 0;
                    processes_list[i].remaining_quantum = 4;
                    MLFQ_Queues[processes_list[i].priority].Enqueue(processes_list[i]);
                }
            }

            #region SYNC   
            //it syncs labels and texts with data
            string[] q = new string[4];
            for (int i = 0; i < 4; i++)
            {
                q[i] = "";
                Process[] temp = MLFQ_Queues[i].ToArray();
                for (int j = 0; j < temp.Length; j++)
                {
                    q[i] += temp[j].name + " | ";
                }
            }
            t1.Text = q[0];
            t2.Text = q[1];
            t3.Text = q[2];
            t4.Text = q[3];
            l1.Text = CPUavailable ? "--" : inCPU.name; Application.DoEvents(); Thread.Sleep(SleepTime);
            #endregion

            if (!CPUavailable)
            {
                inCPU.remaining_quantum--;
                inCPU.remaining_burst--;
                if (inCPU.remaining_quantum==0 || inCPU.remaining_burst==0)
                {
                    
                    if (inCPU.remaining_burst<=0)
                    {
                        inCPU.end_time = current_time;
                    }
                    else
                    {
                        inCPU.priority += 1;
                        inCPU.remaining_quantum = inCPU.priority <= 2 ? 8 : inCPU.remaining_burst;
                        MLFQ_Queues[inCPU.priority].Enqueue(inCPU);
                    }
                    CPUavailable = true;
                }
            }

            #region sync
            for (int i = 0; i < 4; i++)
            {
                q[i] = "";
                Process[] temp = MLFQ_Queues[i].ToArray();
                for (int j = 0; j < temp.Length; j++)
                {
                    q[i] += temp[j].name + " | ";
                }
            }
            t1.Text = q[0];
            t2.Text = q[1];
            t3.Text = q[2];
            t4.Text = q[3];
            l1.Text = CPUavailable ? "--" : inCPU.name; Application.DoEvents(); Thread.Sleep(SleepTime);
            #endregion

            if (CPUavailable)
            {
                if (MLFQ_Queues[0].Count>0)
                {
                    inCPU = MLFQ_Queues[0].Dequeue(); CPUavailable = false;
                }
                else if (MLFQ_Queues[1].Count > 0)
                {
                    inCPU = MLFQ_Queues[1].Dequeue(); CPUavailable = false;
                }
                else if (MLFQ_Queues[2].Count > 0)
                {
                    inCPU = MLFQ_Queues[2].Dequeue(); CPUavailable = false;
                }
                else if (MLFQ_Queues[3].Count > 0)
                {
                    inCPU = MLFQ_Queues[3].Dequeue(); CPUavailable = false;
                }
                else
                {
                    return !Process.AllProcessesSimulated(processes_list);  //all processes done signal
                }
            }

            #region sync
            for (int i = 0; i < 4; i++)
            {
                q[i] = "";
                Process[] temp = MLFQ_Queues[i].ToArray();
                for (int j = 0; j < temp.Length; j++)
                {
                    q[i] += temp[j].name + " | ";
                }
            }
            t1.Text = q[0];
            t2.Text = q[1];
            t3.Text = q[2];
            t4.Text = q[3];
            l1.Text = CPUavailable ? "--" : inCPU.name; Application.DoEvents(); Thread.Sleep(SleepTime);
            return true;    //signals to continue simulation as more unfinished processes
        }
            #endregion
    }
}
