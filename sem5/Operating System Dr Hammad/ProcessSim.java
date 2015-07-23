/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package processsim;
import java.util.Iterator;
import java.util.LinkedList;
import java.util.Queue;

/**
 *
 * @author hamza
 */

public class ProcessSim {

    /**
     * @param args the command line arguments
     */
    private class PCB
{
        PCB() {;}
        public int state;
        public int startTime;
        public int currentBurstTime;
         public int secondBurstTime;
        public int totalExecutionTime;
        public int currentExecutionTime;
        public int currentWaitingTime;
        public int nextWaitTime;
         public void setVal(int  st,int cbt,int sbt,int tet,int cwt,int nwt)
         {
             state=0;
             startTime=st;
             currentBurstTime=cbt;
             secondBurstTime=sbt;
             totalExecutionTime=tet;
             currentExecutionTime=0;
             currentWaitingTime=cwt;
             nextWaitTime=nwt;
         }
    }

    public static void main(String[] args) {
        // TODO code application logic here
        
         PCB p1,p2,p3,temp=null;
         Iterator it;
        int running=0;
        
        p1.setVal(1, 8, 1, 10,20,20);
        p2.setVal(9, 10, 7, 19,10,20);
        p3.setVal(20, 10, 10, 25,40,40);
        int t=1;
          Queue<PCB> readyQ=new LinkedList<PCB>();
            Queue<PCB> waitingQ=new LinkedList<PCB>();
            while(t!=0)
            {
                if(t==p1.startTime)
                    readyQ.add(p1);
                if(t==p2.startTime)
                    readyQ.add(p2);
                if(t==p3.startTime)
                    readyQ.add(p3);
                if(running==0)
                {
                    temp=readyQ.poll();
                    if(temp!= null)
                       running=1;
                }
                if(temp!=null)
                {
                temp.currentBurstTime--;
                temp.currentExecutionTime++;
                if(temp.currentBurstTime<=0)
                {
                    switch(temp.startTime)
                    {
                        case 1:
                            p1.currentBurstTime=p1.secondBurstTime;
                            p1.secondBurstTime=1;
                            p1.currentExecutionTime=temp.currentExecutionTime;
                            if(p1.currentExecutionTime<p1.totalExecutionTime)
                                waitingQ.add(p1);
                            break;
                        case 9:
                            p2.currentBurstTime=p2.secondBurstTime;
                            p2.secondBurstTime=1;
                            p2.currentExecutionTime=temp.currentExecutionTime;
                           if(p2.currentExecutionTime<p2.totalExecutionTime)
                                waitingQ.add(p2);
                            break;
                        case 20:
                            p3.currentBurstTime=p3.secondBurstTime;
                            p3.secondBurstTime=5;
                            p3.currentExecutionTime=temp.currentExecutionTime;
                            if(p3.currentExecutionTime<p3.totalExecutionTime)
                            {
                                p3.currentWaitingTime=temp.currentWaitingTime+2;
                                waitingQ.add(p3);
                            }
                            break;
                    };
                    temp=null;
                    running=0;
                }
                }
                 it=waitingQ.iterator();
                 while(it.hasNext())
        {
            PCB iteratorValue=(PCB)it.next();
            if(iteratorValue!=null)
            {
                iteratorValue.currentWaitingTime--;
                if(iteratorValue.currentWaitingTime<=0)
                { 
                    iteratorValue.currentWaitingTime=iteratorValue.nextWaitTime;
                    readyQ.add(iteratorValue);
                    
                    it.remove();}
            }
        }
            }
    }
}

