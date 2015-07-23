using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Capr_Raza___Lab_3
{
    class zProcess:IComparable<zProcess>
    {
        private string _processName;
        private int _execTime;
        private int _id;
        private static int _counter = 0;

        public int ExecTime
        {
            get
            {
                return this._execTime;
            }
        }

        public zProcess()
        {
            zProcess._counter++;
            Console.Write("Enter Process Name=");
            this._processName = Console.ReadLine();
            Console.Write("Enter Process Exec Time in ms=");
            this._execTime= int.Parse(Console.ReadLine());
            this._id = zProcess._counter;
        }

        public override string ToString()
        {
            return this._id + " - " + this._processName + " - " + this._execTime;
        }

        public int CompareTo(zProcess p)
        {
            return this._id - p._id;
        }
    }
}
