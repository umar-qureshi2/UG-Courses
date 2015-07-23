using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace sc_lab_5
{
    public partial class Form2 : Form
    {
        public string abc;
        string[] iden1 = null;
        public Stack<int> mystack = new Stack<int>();
        public Stack<int> ifkastack = new Stack<int>();
        public Stack<string> variableskastack = new Stack<string>();
        int count = 0, check1 = 0, count1 = 0, linkacheck = 0, endkacheck = 0, variablekacheck = 0 , aikaurchk = 0;
        string variable = "";
        public int err;



        public Form2()
        {
            InitializeComponent();
        }
        public Form2(string a)
        {
            InitializeComponent();
            count = 0; check1 = 0; count1 = 0; linkacheck = 0; endkacheck = 0; variablekacheck = 0; aikaurchk = 0;
            abc = a;

            richTextBox1.Text = null;
            richTextBox2.Text = null;
            richTextBox3.Text = null;
            textBox1.Text = null;
           

            int c = 0, b = 0;
            err = 0; 
            
            string[] token = abc.Split(new string[] {"\n" , "\r\n", " " }, StringSplitOptions.RemoveEmptyEntries);
            int j = token.Length;


            while (c != j)
            {
                richTextBox1.Text += token[c];
                richTextBox1.Text += "\r\n";
                c++;
            }

            while (b != j)
            {
                Hello(token[b]);
                b++;
            }

            if (count > 0)
            { textBox1.Text += "\r\nSquare Brackets Mismatch"; err++; }
            if (count1 > 0)
            { textBox1.Text += "\r\nIf statement END missing"; err++; }
            if (endkacheck < linkacheck - 2)
            { textBox1.Text += "\r\n; missing"; err++; }
            //if(endkacheck>linkacheck-2)
            //    textBox1.Text += "\r\nExtra ;";
            if (check1 < endkacheck + 2)
            { textBox1.Text += "\r\nDot missing for a new line"; err++; }
            label2.Text = Convert.ToString(err);

        }

       

        void Hello(string f)
        {
            string a = f;
            int x;
            float y;
            //label2.Text = Convert.ToString(err);        ////////////////////////////////////////////////////////
            if (variablekacheck == 1)
                variablekacheck = 2;
            if (aikaurchk == 1)
                aikaurchk = 2;

            bool tt = int.TryParse(a, out x);
            if (tt)
            {
                richTextBox2.Text += "Number"; variable = "Number";
            }
            bool xx = float.TryParse(a, out y);
            if (xx && !tt)
            {
                richTextBox2.Text += "Rational"; variable = "Rational";
            }
            else if (!xx && !tt)
            {
                if (a.Length < 2)
                {
                    //if (a == "+" || a == "-" || a == "/" || a == "*" || a == ">" || a == "<")
                      //  richTextBox2.Text += "Operator";
                    //if (a == "[" || a == "]" || a == "(" || a == ")" || a == "{" || a == "}" || a == "," || a == "#" || a == "'")
                      //  richTextBox2.Text += "Special Character";
                    /*if (check1 == 1)
                    {
                        if (a == ".")
                        {
                            richTextBox2.Text += "Start of New Line"; linkacheck++;
                        }
                        else
                        {
                            textBox1.Text += "\r\nDot missing for new Line";
                        }
                        check1 = 0;
                    }*/

                    if (a == ":" )
                    { richTextBox2.Text += "Assignment Operator"; variable = "Assignment Operator"; aikaurchk = 1; }
                    else if (a == "=")
                    { richTextBox2.Text += "Equality"; variable = "Equality"; }
                    else if (a == ".")
                    { richTextBox2.Text += "Start of New Line"; linkacheck++; check1++; variable = "1"; }
                    else if (a == "[")
                    {
                        richTextBox2.Text += "Function Body Start"; variable = "1";
                        count++;
                        mystack.Push(count);
                    }
                    else if (a == "]")
                    {
                        richTextBox2.Text += "Function body end"; variable = "1";
                        if (count == 0)
                        {
                            err++; textBox1.Text += "\r\nSquare Brackets Mismatch"; 
                        }
                        else
                        {
                            mystack.Pop();
                            count--;
                        }
                    }
                    else if (a == ",")
                    {richTextBox2.Text += "Till"; variable = "1";}
                    else if (a == "+")
                    {richTextBox2.Text += "Addition"; variable = "1";}
                    else if (a == "-")
                    {richTextBox2.Text += "Subtraction"; variable = "1";}
                    else if (a == "*")
                    {richTextBox2.Text += "Multiplication"; variable = "1";}
                    else if (a == "/")
                    {richTextBox2.Text += "Division"; variable = "1";}
                    else if (a == "%")
                    {richTextBox2.Text += "Remainder"; variable = "1";}
                    else if (a == "<" || a == ">")
                    { richTextBox2.Text += "String Cocatenate"; variable = "1"; }
                    else if (a == "&")
                    { richTextBox2.Text += "AND"; variable = "1"; }
                    else if (a == "#")
                    {richTextBox2.Text += "OR";variable = "1";}
                    else if (a == "?")
                    { richTextBox2.Text += "Any"; variable = "1"; }
                    else if (a == "(" || a == ")")
                    { richTextBox2.Text += "Precedence Bracket"; variable = "1"; }
                    else if (a == ";")
                    { richTextBox2.Text += "End of Line"; endkacheck++; variable = "1"; }



                    else if (isValid(Convert.ToString(a)) && a != "letter" && a != "rational" && a != "number")
                    { richTextBox2.Text += "Letter"; variable = "Letter"; }
                    else
                    { richTextBox2.Text += "INVALID"; err++; }
                }


                else
                {
                    if (a == "int" || a == "class" || a == "void" || a == "else" || a == "float" || a == "for" || a == "char" || a == "main")
                    { richTextBox2.Text += "Keyword"; variable = "1"; }
                    else if (a == "==" || a == "!=" || a == ">=" || a == "<=" || a == "++" || a == "--" || a == "+=")
                    { richTextBox2.Text += "Operator"; variable = "1"; }
                    else if (a == "\r\n")
                    { }
                    else if (a == "integer" || a == "rational" || a == "letter" || a == "number")
                    { richTextBox2.Text += "Datatype"; variable = "1"; }
                    else if (a == "var")
                    { richTextBox2.Text += "Variable"; variablekacheck = 1; variable = "1"; }
                    else if (a == "acquire")
                    { richTextBox2.Text += "Single Byte input"; variable = "1"; }
                    else if (a == "display")
                    { richTextBox2.Text += "Single Byte output"; variable = "1"; }
                    else if (a == "if")
                    {
                        richTextBox2.Text += "If statement Start"; variable = "1";
                        count1++;
                        ifkastack.Push(count1);
                    }
                    else if (a == "elif")
                    {
                        richTextBox2.Text += "Else if statement"; variable = "1";
                        if (count1 == 0)
                        {
                            err++; textBox1.Text += "\r\nIf statement Missing";
                        }
                    }
                    else if (a == "el")
                    {
                        richTextBox2.Text += "Else statement"; variable = "1";
                        if (count1 == 0)
                        {
                            err++; textBox1.Text += "\r\nIf statement Missing";
                        }
                    }
                    else if (a == "fi")
                    {
                        richTextBox2.Text += "If statement End"; variable = "1";
                        if (count1 == 0)
                        {
                            err++; textBox1.Text += "\r\nIf statement Missing";
                        }
                        else
                        {
                            ifkastack.Pop();
                            count1--;
                        }
                    }
                    else if (a == "repeat")
                    { richTextBox2.Text += "For Loop"; variable = "1"; variablekacheck = 1; }

                    else
                    {
                        if (a.StartsWith("_"))
                        {
                            char b = a.ElementAt(1);
                            if (isValid(Convert.ToString(b)))
                            {
                                // err += chk(a);
                            }
                            else
                                richTextBox2.Text += "String";
                        }

                        char c = a.ElementAt(0);
                        if (isValid(Convert.ToString(c)))
                        { richTextBox2.Text += "Identifier"; variable = "Identifier"; }
                        else
                        {
                            err += chkerr(a);
                        }

                    }
                }
            }


            if (variablekacheck == 2)
            {
                if (variable != "Letter" && variable != "Identifier")
                { textBox1.Text += "\r\nWrong name for type VAR"; err++; }
                else
                { variableskastack.Push(a); richTextBox3.Text += "\r\n"+ a; }
                variablekacheck = 0;
                variable = "";
            }
            if (variablekacheck == 0 )
                if (variable == "Identifier" || variable == "Letter")
                {
                    bool i  = variableskastack.Contains(a);
                    if (!i)
                    {
                        textBox1.Text += "\r\nWrong identifier or letter ' " + a + " '"; err++;
                    }
                }
            if (aikaurchk == 2)
            {
                bool abc =int.TryParse(a, out x);
                if (abc)
                { 
                    richTextBox3.Text += "              " + "number";
                    aikaurchk = 0;
                }
                else
                {
                    richTextBox3.Text += "     " + a;
                    aikaurchk = 0;
                }
            }


            richTextBox2.Text += "\r\n";
            //textBox1.Text += "\r\n";
            //label2.Text = Convert.ToString(err);
        }

//--------------------------------------------------------------------------------------------------------------       
//--------------------------------------------------------------------------------------------------------------
//--------------------------------------------------------------------------------------------------------------
//--------------------------------------------------------------------------------------------------------------       

        private static bool isValid(String str)
        { return Regex.IsMatch(str, @"^[a-zA-Z]+$"); }


//--------------------------------------------------------------------------------------------------------------       
//--------------------------------------------------------------------------------------------------------------
//--------------------------------------------------------------------------------------------------------------
//-------------------------------------------------------------------------------------------------------------- 
        
        public int chkerr(string a)
        {
            if (a.StartsWith("(") || a.StartsWith(")") || a.StartsWith("=") || a.StartsWith("!") || a.StartsWith("[") || a.StartsWith("]") || a.StartsWith(";") || a.StartsWith(":"))
            {
                richTextBox2.Text += "INVALID";
                return 1;
            }
            else
                richTextBox2.Text += "String";
            return 0;

        }

//--------------------------------------------------------------------------------------------------------------       
//--------------------------------------------------------------------------------------------------------------
//--------------------------------------------------------------------------------------------------------------
//-------------------------------------------------------------------------------------------------------------- 

        public int chk(string a)
        {
            int l = iden1.Length, i = 0;
            if (l == 0)
            {
                iden1[0] = a;
                return 0;
            }

            {
                while (i != l)
                {
                    if (iden1[i] == a)
                    {
                        richTextBox2.Text = "INVALID (repetition)";
                        return 1;
                    }
                    i++;
                }
                iden1[l] = a;
                richTextBox2.Text = "Identifier";
                return 0;
            }
        }



    }
}
