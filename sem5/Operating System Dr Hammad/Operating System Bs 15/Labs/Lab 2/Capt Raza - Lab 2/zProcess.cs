using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Capt_Raza___Lab_2
{
    /// <summary>
    /// <para>Data Type for Process.</para>
    /// <para>Comprises of File Name, Size, Priority.</para>
    /// <para>Implements IComparable Interface</para>
    /// <para>Sorting based on Priority.</para>
    /// </summary>
    class zProcess:IComparable<zProcess>
    {
        /// <summary>
        /// Data Memebers
        /// </summary>
        string _fileName;        
        int _pri;
        int _size;

        /// <summary>
        /// Gets the File Name for the Process
        /// </summary>
        public String FileName
        {
            get
            {
                return this._fileName;
            }
        }

        /// <summary>
        /// Gets the Priority for the Process
        /// </summary>
        public int Pri
        {
            get
            {
                return this._pri;
            }
        }

        /// <summary>
        /// Gets the Size for the Process
        /// </summary>
        public int Size
        {
            get
            {
                return this._size;
            }
        }

        /// <summary>
        /// Reperesents a Process
        /// Gets the input from user
        /// </summary>        
        public zProcess()
        {
            Console.Write("Enter Filename with extesion =");
            this._fileName = Console.ReadLine();
            
            Console.Write("Enter File Size (like 40kb, 10mb) =");
            this._size = SizeCoversion.Convert(Console.ReadLine());
            
            Console.Write("Enter File Priority =");
            this._pri = int.Parse(Console.ReadLine());            
        }

        /// <summary>
        /// Write Contents of Process on Console
        /// </summary>
        public void show()
        {
            Console.WriteLine(this._fileName + "   " + this._size + "   " + this._pri);
        }
        
        /// <summary>
        /// Compares two zProcess objetcs based on Priority
        /// </summary>
        /// <param name="zp">Other zProcess to be compared</param>
        /// <returns>Integer based on Comarison</returns>
        public int CompareTo(zProcess zp)
        {
            if (this._pri > zp._pri)
                return 1;
            else if (this._pri < zp._pri)
                return -1;
            else
                return 0;
        }
    }
}
