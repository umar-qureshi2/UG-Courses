using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCompiler
{
    class Scanner_CPP
    {
        String input;

        public Scanner_CPP(string s)
        {
            input = s;
        }

        public bool isEndOfStatement(string s)
        {
            if (s == ";")
                return true;
            return false;
        }

        public bool isKeyword(string s)
        {
            string keywords = "class,void,main,int,float,char,if,else,else if,for,return,double,string,static,var,boolean,bool,true,false,null,this,do,while";
            string[] _keywords = keywords.Split(',');
            foreach (string i in _keywords)
            {
                if (i == s)
                {
                    return true;
                }
            }

            return false;
        }

        public bool isChar(string s)
        {
            try
            {
                if (s[0] == '\'' && s[2] == '\'')
                    return true;
            }
            catch
            {
                return false;
            }
            return false;
        }

        public bool isInteger(string s)
        {
            int i_val = 0;
            if (int.TryParse(s, out i_val))
                return true;
            return false;
        }

        public bool isFloat(string s)
        {
            float f_val = 0;
            if (float.TryParse(s, out f_val))
                return true;
            return false;
        }

        public bool isOperator(string s)
        {
            string operators = "+,-,*,/,=,==,!=,>,>=,<,<=,++,--,+=,-=,&&,||,!";
            string[] _operators = operators.Split(',');
            foreach (string i in _operators)
            {
                if (s == i)
                {
                    return true;
                }
            }
            return false;
        }

        public string OperatorName(string s)
        {
            if (s == "+")
                return "Addation Operator";
            else if (s == "-")
                return "Subtraction Operator";
            else if (s == "*")
                return "Multiplication Operator";
            else if (s == "/")
                return "Division Operator";
            else if (s == "=")
                return "Assignment Operator";
            return null;
        }

        public bool isSpecialCharacter(string s)
        {
            string spec_char = " ( ) [ ] # { } ,";
            string[] _spec_char = spec_char.Split(' ');
            foreach (string j in _spec_char)
            {
                if (s == j)
                {
                    return true;
                }
            }
            return false;
        }

        public bool isVariableORidentifier(string s)
        {
            if (!isKeyword(s) && !isInteger(s) && !isFloat(s) && !isOperator(s) && !isSpecialCharacter(s) && !isEndOfStatement(s))
                return true;
            return false;
        }

        public bool isString(string s)
        {
            try
            {
                if (s[0] == '\"' && s[s.Length-1] == '\"')
                    return true;
            }
            catch
            {
                return false;
            }
            return false;
        }
    }
}
