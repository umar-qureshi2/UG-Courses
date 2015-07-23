using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Capr_Raza___Lab_3
{
    class Program
    {
        static void Main(string[] args)
        {
            zListProcess lp = new zListProcess();
            string choice="";
            while (choice.ToLower() != "n")
            {
                lp.Add();
                Console.WriteLine("To Stop Entering Process, enter n");
                choice = Console.ReadLine();
            }

            Console.WriteLine("List by STN");
            lp.SortBySPN();
            lp.Show();

            Console.WriteLine("List by FCFS");
            lp.SortByFCFS();
            lp.Show();

            Console.ReadKey();
        }
    }
}
