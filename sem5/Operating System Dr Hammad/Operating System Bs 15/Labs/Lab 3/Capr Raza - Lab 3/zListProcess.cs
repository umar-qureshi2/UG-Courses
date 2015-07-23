using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Capr_Raza___Lab_3
{
    class zListProcess
    {
        class zSortAscByShortestProcessNext:IComparer<zProcess>
        {
            public int Compare(zProcess p1, zProcess p2)
            {
                return p1.ExecTime - p2.ExecTime;
            }
        }

        List<zProcess> _listProcess;

        public zListProcess()
        {
            this._listProcess = new List<zProcess>();
        }

        public void Add()
        {
            this._listProcess.Add(new zProcess());
        }

        public void Show()
        {   
            for (int i = 0; i < this._listProcess.Count; i++)
            {
                Console.WriteLine(this._listProcess[i].ToString());
            }
        }

        public void SortByFCFS()
        {
            this._listProcess.Sort();
        }

        public void SortBySPN()
        {
            this._listProcess.Sort(new zSortAscByShortestProcessNext());
        }
    }
}
