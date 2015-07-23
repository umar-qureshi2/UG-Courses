using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Capt_Raza___Lab_2
{
    /// <summary>
    /// To Convert string to int File Size
    /// </summary>

    class SizeCoversion
    {
        /// <summary>
        /// Converts string File Size to int
        /// </summary>
        /// <param name="str">File Size With Unit</param>
        /// <returns>File Size in KB</returns>
        public static int Convert(string str)
        {       
            str=str.ToLower();
            if (str.Contains("mb"))
            {
                str.Replace("mb", "");
                return (int.Parse(str) * 1024);
            }
            else if (str.Contains("gb"))
            {
                str.Replace("gb", "");
                return (int.Parse(str) * 1024 * 1024);
            }
            else if (str.Contains("kb"))
            {
                str.Replace("kb", "");
                return (int.Parse(str));
            }
            else
            {
                return int.Parse(str);
            }   
        }
    }
}
