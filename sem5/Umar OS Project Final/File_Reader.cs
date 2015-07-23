using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace WindowsFormsApplication4
{
    class FileOpening
    {
        StreamReader opened_file;
        public Process[] processes_list;

        public Process[] getProcessList()
        {
            if (processes_list!=null)
            {
                int i = 0;
                while (!opened_file.EndOfStream && (i-100)<0)
                {
                    string Line = opened_file.ReadLine();
                    string[] Process_attribs = Line.Split('\t');
                    processes_list[i] = new Process(Process_attribs[0], int.Parse(Process_attribs[1]), int.Parse(Process_attribs[2]));
                    i++;
                }
            }
            return processes_list;
        }

        public FileOpening(string path)
        {
            opened_file = new StreamReader(path);
            if (opened_file != null)
            {
                processes_list = new Process[1000];//program can hold max 1000 processes you can input at run time but that is not much useful
            }
        }
    }
}
