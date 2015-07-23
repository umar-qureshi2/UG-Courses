using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Capt_Raza___Lab_2
{
    /// <summary>
    /// Implments the Lab 2 Task
    /// </summary>

    class Program
    {
        static void Main(string[] args)
        {
            ListzProcess lp = new ListzProcess();

            string ch="";

            Console.WriteLine("Enter 2 to Stop Entering Data");

            while (true)
            {
                try
                {                    
                    Console.Write("\n1.Yes\n2.No\nEnter New Process =");
                    ch = Console.ReadLine();
                    if (ch.ToLower() == "1")
                        lp.Add();
                    if (ch.ToLower() == "2")
                        break;                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.Clear();

            if (lp.Count > 0)
            {

                Console.WriteLine("Process List Contents");
                lp.show();

                Console.WriteLine("Sorted Asc by Pri");
                lp.SortAscByPri();
                lp.show();

                Console.WriteLine("Sorted Asc by Size");
                lp.SortAscBySize();
                lp.show();

                Console.WriteLine("Sorted Asc by Doc Ext");
                lp.SortAscByDocExt();
                lp.show();
            }
            else
            {
                Console.WriteLine("No Process Entered");
            }
            Console.ReadKey();
        }
    }
}
