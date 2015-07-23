using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MyCompiler
{
    class Parser
    {
        public static int pos;

        static bool isoperator(char e)			//operator fn
        {
            return (e == '+' || e == '-' || e == '*' || e == '/' || e == '%' || e == '^') ? true : false;
        }
        static bool openbrackets(char c)		//open brackets fn
        {
            return (c == '[' || c == '{' || c == '(') ? true : false;
        }
        static bool closebrackets(char c)		//closing brackets fn
        {
            return (c == ']' || c == '}' || c == ')') ? true : false;
        }
        static int priority(char e)		//fn to chk priority of operators
        {
            int pr = 0;
            if (e == '^')
                pr = 3;
            else if (e == '*' || e == '/' || e == '%')
                pr = 2;
            else if (e == '+' || e == '-')
                pr = 1;
            return pr;
        }

        static bool isalpha(char c)
        {
            if (Regex.IsMatch(c.ToString(), @"^[a-zA-Z]+$"))
                return true;

            return false;
        }

        static bool isdigit(char c)
        {
            if (Regex.IsMatch(c.ToString(), @"^[0-9]+$"))
                return true;

            return false;
        }

        public static int InfixExpression(string ar)
        {
            Stack<char> s = new Stack<char>();
            Stack<char> s2 = new Stack<char>();
            int i = 0, x = 0;
            bool ch = true;
            pos = 0;
            char cha;
            while (i < ar.Length)
            {
                if (openbrackets(ar[i]))		//Brackets chk
                {
                    if (!(s2.Count <= 0))
                    {
                        cha = s2.Pop();
                        if (isalpha(cha))
                        {
                            pos = i + 1;
                            return 7;
                        }
                        else
                        {
                            s.Push(ar[i]);
                            s2.Push(cha);
                        }
                    }
                    else
                        s.Push(ar[i]);
                }
                else if (closebrackets(ar[i]))
                {
                    cha = s.Pop();
                    if (ar[i] == ']' && cha == '[' || ar[i] == '}' && cha == '{' || ar[i] == ')' && cha == '(')
                        ch = true;
                    else
                    {
                        pos = i + 1;
                        return 2;
                    }
                }
                else if (s2.Count <= 0)		//chk stack is empty
                {
                    if (isalpha(ar[i]))		//if empty push alphabets in the stack
                    {
                        s2.Push(ar[i]);
                        x++;
                    }
                    else if (isdigit(ar[i]))
                    {
                        s2.Push(ar[i]);
                        x++;
                    }
                    else if (isoperator(ar[i]))
                    {
                        pos = i + 1;
                        return 4;
                    }
                }
                else if (!(s2.Count <= 0))
                {
                    if (isalpha(ar[i]))			//if alphabet(s) it checks there is no alphabet behind
                    {
                        cha = s2.Pop();
                        if (isalpha(cha))
                        {
                            pos = i + 1;
                            return 5;
                        }
                        else
                        {
                            s2.Push(cha);
                            s2.Push(ar[i]);
                        }
                        x++;
                    }
                    else if (isdigit(ar[i]))			//if expression has digit, error
                    {
                        cha = s2.Pop();
                        if (isdigit(cha))
                        {
                            pos = i + 1;
                            return 5;
                        }
                        else
                        {
                            s2.Push(cha);
                            s2.Push(ar[i]);
                        }
                        x++;
                    }
                    else if (isoperator(ar[i]))		//if operator(s) it chks there is no operator behind
                    {
                        cha = s2.Pop();
                        if (isoperator(cha))
                        {
                            pos = i + 1;
                            return 6;
                        }
                        else if (isalpha(cha))
                        {
                            s2.Push(cha);
                            s2.Push(ar[i]);
                        }
                        else if (isdigit(cha))
                        {
                            s2.Push(cha);
                            s2.Push(ar[i]);
                        }
                        /*else if(!s.isempty())
                        {
                        char ch1=s.pop();
                        if(openbrackets(ch1))
                        return 7;
                        else
                        s.push(ch1);
                        }*/
                        x--;
                    }
                }
                if (!isoperator(ar[i]) && !isalpha(ar[i]) && !openbrackets(ar[i]) && !closebrackets(ar[i]) && !isdigit(ar[i]) && ar[i] != ' ')
                {
                    pos = i + 1;
                    return 8;
                }
                i++;
            }
            if (!(s.Count <= 0))
            {
                pos = i + 1;
                return 2;
            }
            if (x == 1)
                return 1;

            return 0;
        }

        public static string converter(string ar)			//convertor infix to postfix
        {
            Stack<char> s = new Stack<char>();
            string post = null;
            char cha;
            foreach (char c in ar)
            {
                if (isdigit(c) || isalpha(c))		//insert alphabets & digits in postfix
                {
                    post += c;
                }
                else if (c == ' ' || c == '\t')			//space & tab has been ignored
                {
                    continue;
                }
                else if (c == '(')					//open brackets are push in the stack
                {
                    s.Push(c);
                }
                else if (c == ')')					//close brackets pop the stack until it find its corresponding open brackets
                {
                    cha = s.Pop();
                    while (cha != '(')
                    {
                        post += cha;
                        cha = s.Pop();
                    }
                }
                else if (c == '{')
                {
                    s.Push(c);
                }
                else if (c == '}')
                {
                    cha = s.Pop();
                    while (cha != '{')
                    {
                        post += cha;
                        cha = s.Pop();
                    }
                }
                else if (c == '[')
                {
                    s.Push(c);
                }
                else if (c == ']')
                {
                    cha = s.Pop();
                    while (cha != '[')
                    {
                        post += cha;
                        cha = s.Pop();
                    }
                }
                else if (isoperator(c))		//operators with low priority are pushed w.r.t precious in the stack
                {									//and operators with high priority are inserted in the string
                    if (s.Count <= 0)
                        s.Push(c);
                    else
                    {
                        bool chk = true;
                        cha = s.Pop();
                        while (priority(cha) >= priority(c))		//chk whether the operator has higher priority
                        {
                            post += cha;
                            chk = false;
                            if (s.Count > 0)
                                cha = s.Pop();
                            else
                                break;
                        }
                        if(chk)
                            s.Push(cha);
                        s.Push(c);
                    }
                }
            }

            while (!(s.Count <= 0))				//insert all the remaining operators in the postfix
            {
                cha = s.Pop();
                post += cha;
            }

            return post;
        }


        static char[] temp = new char[50];
        static void init()
        {
            int z;
            for (z = 0; z < 50; z++)
                temp[z] = ' ';
        }

        public static float evaluate(string p)		//get values 4 operands
        {
            Stack<float> s = new Stack<float>();
            init();
            float a, b, val;
            int j = 0, x = 0, z;
            float[] tem = new float[50];

            foreach(char c in p)
            {
                if (isalpha(c))				//gives value for alphabets. Same alphabets have the same values i.e.,any number of a has the same value 
                {
                    for (z = 0; z < 5; z++)
                    {
                        if (c == temp[z])
                            break;
                    }
                    if (c != temp[z])			//if the alphabet(s) is/are repeat their value(s) are same
                    {
                        temp[j] = c;
                        j++;
                        Console.Write("Enter value for " + c + ": ");
                        val = Console.Read();
                        tem[x++] = val;
                        s.Push(val);
                    }
                    else
                        s.Push(tem[z]);
                }
                else if (isdigit(c))
                {
                    for (z = 0; z < 5; z++)
                    {
                        if (c == temp[z])
                            break;
                    }
                    if (c != temp[z])			//if the alphabet(s) is/are repeat their value(s) are same
                    {
                        temp[j] = c;
                        j++;
                        val = float.Parse(c.ToString());
                        tem[x++] = val;
                        s.Push(val);
                    }
                    else
                        s.Push(tem[z]);
                }
                else if (isoperator(c))		//solve the postfix expression w.r.t operator
                {
                    a = s.Pop();
                    b = s.Pop();
                    if (c == '+')
                        s.Push(b + a);
                    if (c == '-')
                        s.Push(b - a);
                    if (c == '*')
                        s.Push(b * a);
                    if (c == '/')
                    {
                        if (a == 0)
                        {
                            MessageBox.Show(null, "Dividing by 0 is not possible" + Environment.NewLine + "\nMaths error... ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        s.Push(b / a);
                    }
                    if (c == '%')
                    {
                        int cc = int.Parse(a.ToString());
                        int dd = int.Parse(b.ToString());
                        s.Push(dd % cc);
                    }
                    if (c == '^')
                    {
                        float f = 1;
                        for (a = 0; a > 0; a--)
                            f *= b;
                        s.Push(f);
                    }
                }
            }
            return s.Pop();
        }

    }
}
