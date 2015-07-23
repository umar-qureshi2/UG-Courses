using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace SDA_Pro_Classes
{
    class Login
    {
        private SqlConnection sqlcon;

        public Login()
        {

        }

        private DataSet Get_Data()
        {
            sqlcon = Database_Connection.SQL_Con;
            if (Database_Connection.isOpen)
            {
                //Wait Logic
            }
            //Data retrival Logic
        }

        private Person Create(string username, string password)
        {
            Person p;
            DataSet ds = Get_Data();            
            //authenticate from database
            //return appropriate type of Person
            //depending upon the username, password
            //such as SI, Crew Manager, CRWO etc
            return Person;
        }
    }
}
