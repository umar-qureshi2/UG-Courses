using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Capt_Raza___Lab_2
{
    /// <summary>
    /// <para>List of zProcesses</para>
    /// <para>Provide Basic Sorting</para>
    /// </summary>
    class ListzProcess
    {
        /// <summary>
        /// <para>Implements IComparer Interface</para>
        /// <para>Sorting Based on Process File Size</para>
        /// </summary>
        class CSortAscBySize : IComparer<zProcess>
        {
            /// <summary>
            /// Compare Two zProcess objects Based on Size
            /// </summary>
            /// <param name="zp1">First zProcess to Compare</param>
            /// <param name="zp2">Second zProcess to Compare</param>
            /// <returns>Integer based on Comparison</returns>
            public int Compare(zProcess zp1, zProcess zp2)
            {
                if (zp1.Size > zp2.Size)
                    return 1;
                else if (zp1.Size < zp2.Size)
                    return -1;
                else
                    return 0;
            }
        }

        /// <summary>
        /// <para>Implements IComparer Interface</para>
        /// <para>Sorting Based on Process File Extension</para>
        /// </summary>
        class CSortAscByDocExt : IComparer<zProcess>
        {
            /// <summary>
            /// Compare Two zProcess objects Based on Doc Ext
            /// </summary>
            /// <param name="zp1">First zProcess to Compare</param>
            /// <param name="zp2">Second zProcess to Compare</param>
            /// <returns>Integer based on Comparison</returns>
            public int Compare(zProcess zp1, zProcess zp2)
            {
                if (zp1.FileName.Contains(".doc") && zp2.FileName.Contains(".doc"))
                    return string.Compare(zp1.FileName, zp2.FileName);
                else if (zp1.FileName.Contains(".doc"))
                    return -1;
                else if (zp2.FileName.Contains(".doc"))
                    return 1;
                else
                    return string.Compare(zp1.FileName, zp2.FileName);
            }
        }

        /// <summary>
        /// Data Member
        /// List of zProcess
        /// </summary>
        List<zProcess> _lp = new List<zProcess>();
        
        /// <summary>
        /// Constructor
        /// Creates new ListzProcess object
        /// <para>Initializes Data members</para>
        /// </summary>
        public ListzProcess()
        {
            this._lp = new List<zProcess>();
        }

        /// <summary>
        /// Add zProcess object to List
        /// </summary>
        /// <param name="fn">File Name for zProcess</param>
        /// <param name="p">Priority for zProcess</param>
        /// <param name="sz">File Size for zProcess</param>
        public void Add()
        {
            this._lp.Add(new zProcess());
        }

        /// <summary>
        /// Get Number of items in List
        /// </summary>
        public int Count
        {
            get
            {
                return this._lp.Count;
            }
        }

        /// <summary>
        /// Shows all elements of the List
        /// </summary>
        public void show()
        {
            foreach (zProcess zp in this._lp)
            {
                zp.show();
            }
            Console.WriteLine();
        }


        /// <summary>
        /// Sort List Asc by Priority
        /// </summary>
        public void SortAscByPri()
        {
            this._lp.Sort();
        }

        /// <summary>
        /// Sort List Asc by File Size
        /// </summary>
        public void SortAscBySize()
        {
            this._lp.Sort(new CSortAscBySize());
        }

        /// <summary>
        /// Sort List Asc by Doc Ext
        /// </summary>
        public void SortAscByDocExt()
        {
            this._lp.Sort(new CSortAscByDocExt());
        }
    }
}
