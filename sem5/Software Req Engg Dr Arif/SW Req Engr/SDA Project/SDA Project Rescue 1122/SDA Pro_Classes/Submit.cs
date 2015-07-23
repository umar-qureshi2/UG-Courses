using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SDA_Pro_Classes
{
    class Submit
    {
        List<Person> per;

        public Submit()
        {
            per =new List<Person>();
        }

        public bool Register(Person p)
        {
            if (!per.Contains(p))
            {
                per.Add(p);
                return true;
            }
            return false;
        }

        public void submit(string param)
        {
            //Submission Logic
        }

        public void Inform()
        {
            for (int i = 0; i < per.Count; i++)
            {
                per[i].update();
            }
        }
    }
}
