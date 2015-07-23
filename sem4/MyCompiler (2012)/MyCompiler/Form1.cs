using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
//namespaces for compiling
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Reflection;
using System.Diagnostics;

namespace MyCompiler
{
	public partial class Form1 : Form
	{
		private string filepath = null;
		private StreamReader sPrint;        //for printing purpose.

		public Form1()
		{
			InitializeComponent();
		}

		private void Menu_Click(object sender, EventArgs e)
		{
			switch (((ToolStripMenuItem)sender).Name)
			{
				case "mNew":
					NewFile();
					break;
				case "mOpen":
					OpenFile();
					break;
				case "mSave":
					SaveFile();
					break;
				case "mSaveAs":
					SaveFileAs();
					break;
				case "mPrint":
					PrintFile();
					break;
				case "mExit":
					Application.Exit();
					break;

				case "mUndo":
					richTextBox1.Undo();
					break;
				case "mRedo":
					richTextBox1.Redo();
					break;
				case "mCut":
					richTextBox1.Cut();
					break;
				case "mCopy":
					richTextBox1.Copy();
					break;
				case "mPaste":
					richTextBox1.Paste();
					break;
				case "mSelectAll":
					richTextBox1.SelectAll();
					break;
			}
		}

		private void NewFile()
		{
			if (richTextBox1.Modified)
			{
				DialogResult r = MessageBox.Show(this, "Save Current File?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
				if (r == DialogResult.Yes)
					SaveFile();
			}
			richTextBox1.Clear();
			filepath = null;
		}

		private void OpenFile()
		{
			openFileDialog1.FileName = "";
			openFileDialog1.Filter = "Text File (*.txt)|*.txt|My File Format (*.saadi)|*.saadi|All Files (*.*)|*.*";
			//user cancel the dialogue
			if (openFileDialog1.ShowDialog() != DialogResult.OK)
				return;
			NewFile();
			StreamReader sr = null;
			try
			{
				sr = new StreamReader(openFileDialog1.FileName);
				richTextBox1.Text = sr.ReadToEnd();
				filepath = openFileDialog1.FileName;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Failed to open file.\n" + ex.Message);
			}
			finally
			{
				if (sr != null)
					sr.Close();
			}

		}

		private void SaveFile()
		{
			if (filepath == null)
			{
				SaveFileAs();
				return;
			}
			StreamWriter sw = null;
			try
			{
				sw = new StreamWriter(filepath);
				sw.WriteLine(richTextBox1.Text);
				//modified shud b = to false. since i'm nt chngng d content of richtextbox.
				richTextBox1.Modified = false;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Failed to save file.\n" + ex.Message);
			}
			finally
			{
				if (sw != null)
					sw.Close();
			}
		}

		private void SaveFileAs()
		{
			saveFileDialog1.Filter = "TextEdit (*.txt)|*.txt|My File Format (*.saadi)|*.saadi|All Files (*.*)|*.*";
			if (saveFileDialog1.ShowDialog() != DialogResult.OK)
				return;
			filepath = saveFileDialog1.FileName;
			SaveFile();
		}

		private void PrintFile()
		{
			if (printDialog1.ShowDialog() != DialogResult.OK)
				return;
			try
			{
				sPrint = new StreamReader(new MemoryStream(Encoding.ASCII.GetBytes(richTextBox1.Text)));

				printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument1_PrintPage);
				printDocument1.Print();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Failed to print file.\n" + ex.Message);
			}
			finally
			{
				if (sPrint != null)
					sPrint.Close();
			}
		}

		void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			//first it calculate number of lines to fit on to page
			float linesPerPage = e.MarginBounds.Height / richTextBox1.Font.GetHeight(e.Graphics);

			//loop to end of lines or end of stram
			for (int i = 0; i < linesPerPage && !sPrint.EndOfStream; i++)
			{
				//draw the lines
				e.Graphics.DrawString(sPrint.ReadLine(), richTextBox1.Font, Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Top
					+ (i * richTextBox1.Font.GetHeight(e.Graphics)), new StringFormat());
			}

			e.HasMorePages = !sPrint.EndOfStream;
		}

		private void fontToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			if (fontDialog1.ShowDialog() == DialogResult.OK)
				richTextBox1.Font = fontDialog1.Font;
		}

		private void colorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (colorDialog1.ShowDialog() == DialogResult.OK)
				richTextBox1.ForeColor = colorDialog1.Color;
		}

		private void symbolTableToolStripMenuItem_Click(object sender, EventArgs e)
		{
			#region for Sixteen++ symbol table

			string input = richTextBox1.Text;

			try
			{
				if (input != "")
				{
					string[] Ainput = input.Split(' ', '\n');

					//remove while space index to array.
					Ainput = Ainput.Where(x => !string.IsNullOrEmpty(x)).ToArray();
					string msg = "Token\t\tType";
					int lineCount = 0;

					foreach (string s in Ainput)
					{
						msg += Environment.NewLine;

						if (s.Contains('.'))
						{
							msg += s + "\t\t" + "Start_of_Line_" + (++lineCount).ToString();
						}

						if (s != ".")
						{
							msg += s + "\t\t";
							if (Scanner_Sixteen.isEndOfStatement(s))
								msg += "End_Of_Statement";
							else if (Scanner_Sixteen.isStart(s))
								msg += "Start_of_Program_Or_Function";
							else if (Scanner_Sixteen.isEnd(s))
								msg += "End_of_Program_Or_Function";
							else if (Scanner_Sixteen.isDataType(s))
								msg += "Data_Type";
							else if (Scanner_Sixteen.isSpecalCharacter(s))
								msg += "Special_Character";
							else if (Scanner_Sixteen.isNumber(s))
								msg += "Number_Literal";
							else if (Scanner_Sixteen.isRational(s))
								msg += "Rational_Literal";
							else if (Scanner_Sixteen.isKeyword(s))
								msg += "Keyword";
							else if (Scanner_Sixteen.isOperator(s))
								msg += "Operator";
							else if (Scanner_Sixteen.isChar(s))
								msg += "Character_Literal";
							else if (Scanner_Sixteen.isString(s))
								msg += "String Literal";
							else if (Scanner_Sixteen.isVariableORidentifier(s))
								msg += "Variable/Identifier";
						}

					}
					//new form is created here
					Form2 ss = new Form2(msg);
					ss.ShowDialog();
					//MessageBox.Show(this, msg, "Symbol Table", MessageBoxButtons.OK);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
			}

			if (input == "")
				MessageBox.Show(this, "Text Editor is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
			#endregion

			#region for Cpp symbol table
			//string input = richTextBox1.Text;

			//try
			//{
			//    if (input != "")
			//    {
			//        string[] Ainput = input.Split(' ', '\n');

			//        //remove while space index to array.
			//        Ainput = Ainput.Where(x => !string.IsNullOrEmpty(x)).ToArray();
			//        Scanner_CPP sc = new Scanner_CPP(Ainput[0]);
			//        string msg = "Token\t\tType";

			//        foreach (string s in Ainput)
			//        {
			//            msg += Environment.NewLine;
			//            msg += s + "\t\t";
			//            if (sc.isEndOfStatement(s))
			//                msg += "End Of Statement";
			//            else if (sc.isInteger(s))
			//                msg += "Integer Literal";
			//            else if (sc.isFloat(s))
			//                msg += "Float Literal";
			//            else if (sc.isKeyword(s))
			//                msg += "Keyword";
			//            else if (sc.isOperator(s))
			//            {
			//                if (sc.OperatorName(s) != null)
			//                    msg += sc.OperatorName(s);
			//                else
			//                    msg += "Operator";
			//            }
			//            else if (sc.isSpecialCharacter(s))
			//                msg += "Special Character";
			//            else if (sc.isChar(s))
			//                msg += "Character Literal";
			//            else if (sc.isString(s))
			//                msg += "String Literal";
			//            else if (sc.isVariableORidentifier(s))
			//                msg += "Variable/Identifier";
			//        }
			//        Form2 ss = new Form2(msg);
			//        ss.ShowDialog();
			//        MessageBox.Show(this, msg, "Symbol Table", MessageBoxButtons.OK);
			//    }
			//}
			//catch (Exception ex)
			//{
			//    MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
			//}

			//if (input == "")
			//    MessageBox.Show(this, "Text Editor is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
			#endregion
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string msg = "Saad Masood" + Environment.NewLine + Environment.NewLine + "Capt Salman Taj" + Environment.NewLine + "Capt Mohsin Iqbal";
			MessageBox.Show(this, msg, "About Us", MessageBoxButtons.OK);
		}

		private void errorListToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//expression checking function...
			string input = richTextBox1.Text;
			string post = null;

			try
			{
				if (input != "")
				{
					string[] Ainput = input.Split('\n');

					//remove while space index to array.
					Ainput = Ainput.Where(x => !string.IsNullOrEmpty(x)).ToArray();
					foreach (string s in Ainput)
					{
						int a = Parser.InfixExpression(s);
						string msg = null;
						if (a == 1)
						{
							msg += "Correct Expression " + Environment.NewLine;
							msg += "And after evaluating, result of this expression is : ";
							post = Parser.converter(s);
							msg += Parser.evaluate(post);
							MessageBox.Show(this, msg, "Correct", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
						}
						else if (a == 2)
							msg += "Bracket(s) error!!! at position " + Parser.pos + Environment.NewLine;
						else if (a == 3)
							msg += "Error!! due to digit(s), No digit required at position " + Parser.pos + Environment.NewLine;
						else if (a == 4)
							msg += "Error!! due to operator(s) at start " + Environment.NewLine;
						else if (a == 5)
							msg += "Error!!! two operands together without any operator at position " + Parser.pos + Environment.NewLine;
						else if (a == 6)
							msg += "Error!!! two operators together at position " + Parser.pos + Environment.NewLine;
						else if (a == 7)
							msg += "Error!!! No operator behind opening bracket(s) at position " + Parser.pos + Environment.NewLine;
						else if (a == 8)
							msg += "Error!!! Invalid operator(s) at position " + Parser.pos + Environment.NewLine;
						else if (a == 0)
							msg += "Error!!! Operator without operand at position " + s.Length + Environment.NewLine;
						if(a != 1)
							MessageBox.Show(this, msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
					}
				}

			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
			}

			if (input == "")
				MessageBox.Show(this, "Text Editor is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
		}

		private void runToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (filepath == null)
			{
				MessageBox.Show(this, "File must be save first. In order to compile.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
				return;
			}

			Convert();
		}

		string replace()
		{
			string rep;
            rep = richTextBox1.Text.Replace('.',' ');
			rep = rep.Replace("|+","+");
            rep = rep.Replace("|-", "-");
            rep = rep.Replace("|*", "*");
            rep = rep.Replace("|/", "/");
            rep = rep.Replace("|%", "%");
            rep = rep.Replace("<>", "+");
            rep = rep.Replace("|&", "&&");
            rep = rep.Replace("|#", "||");
            rep = rep.Replace("|<", "<");
            rep = rep.Replace("|>", ">");
            rep = rep.Replace("|<=", "<=");
            rep = rep.Replace("|>=", ">=");
            rep = rep.Replace("|==", "==");
			return rep;
		}

		struct temp
		{
            public string name;
            public string type;
		}

		void Convert()
		{
			if (richTextBox1.Text == "")
			{
				MessageBox.Show(this, "Text Editor is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
				return;
			}
			//file name pta karna hai
			string[] file_arr = filepath.Split('\\');
			string name = file_arr[file_arr.Length - 1];
			string simple_name = name.Remove(name.IndexOf('.'));
			string CSharpCode = "using System;\r\n\r\n namespace " + simple_name + " \t { \r\n\tpublic class " + simple_name + "\t{ \r\n\t\tpublic static void Main(String[] args) ";
			string[] lines = replace().Split('\n');
            lines = lines.Where(x => !string.IsNullOrEmpty(x)).ToArray();
			List<temp> list = new List<temp>();

			foreach (string line in lines)
			{
				if (line.Contains("var"))
				{
                    temp tt = new temp();
					CSharpCode += "\r\n\t\t\t";
                    if (line.Contains("number"))
                    {
                        CSharpCode += "int ";
                        tt.type = "int";
                    }
                    else if (line.Contains("rational"))
                    {
                        CSharpCode += "float ";
                        tt.type = "float";
                    }
                    else if (line.Contains("truth"))
                    {
                        CSharpCode += "bool ";
                        tt.type = "bool";
                    }
                    else if (line.Contains("letter"))
                    {
                        CSharpCode += "string ";
                    }

					string[] lin = line.Split(' ');
                    lin = lin.Where(x => !string.IsNullOrEmpty(x)).ToArray();
					CSharpCode += lin[1] + lin[lin.Length - 1];
                    tt.name = lin[1];
                    list.Add(tt);
				}
				else if (line.Contains("["))
				{
					CSharpCode += "\r\n\t\t";
					CSharpCode += "{";
				}
				else if (line.Contains("]"))
				{
					CSharpCode += "\r\n\t\t}\r\n\t}\r\n}";
				}
				else if (line.Contains("acquire"))
				{
					string[] lin = line.Split(' ');
                    lin = lin.Where(x => !string.IsNullOrEmpty(x)).ToArray();
					CSharpCode += "\r\n\t\t\t";
                    if (lin.Length <= 2)
                    {
                        CSharpCode += "Console.Read();";
                    }
                    else
                    {
                        bool chhk = true;
                        temp tt;
                        tt.name = lin[0];
                        tt.type = "int";
                        if (list.Contains(tt))
                        {
                            CSharpCode += lin[0] + " = int.Parse(Console.ReadLine())" + lin[lin.Length - 1];
                            chhk = false;
                        }

                        tt.type = "float";
                        if (list.Contains(tt))
                        {
                            CSharpCode += lin[0] + " = float.Parse(Console.ReadLine())" + lin[lin.Length - 1];
                            chhk = false;
                        }

                        tt.type = "bool";
                        if (list.Contains(tt))
                        {
                            CSharpCode += lin[0] + " = bool.Parse(Console.ReadLine())" + lin[lin.Length - 1];
                            chhk = false;
                        }
                        if(chhk)
                            CSharpCode += lin[0] + " = Console.ReadLine()" + lin[lin.Length - 1];
                    }
				}
				else if (line.Contains("display"))
				{
					string[] lin = line.Split(' ');
                    lin = lin.Where(x => !string.IsNullOrEmpty(x)).ToArray();
					CSharpCode += "\r\n\t\t\t";
                    if (line.Contains(")"))
                        CSharpCode += "Console.WriteLine(" + lin[lin.Length - 3] + ")" + lin[lin.Length - 1];
                    else if (line.Contains("\""))
                    {
                        CSharpCode += "Console.WriteLine(";
                        for(int i = 1 ; i < (lin.Length-1);i++)
                            CSharpCode += lin[i];
                        CSharpCode += ")" + lin[lin.Length - 1];
                    }
                    else
                        CSharpCode += "Console.WriteLine(" + lin[lin.Length - 2] + ")" + lin[lin.Length - 1];
				}
				else if (line.Contains("repeat"))
				{
					string[] lin = line.Split(' ');
                    lin = lin.Where(x => !string.IsNullOrEmpty(x)).ToArray();
					CSharpCode += "\r\n\t\t\t";
					CSharpCode += "for (" + lin[1] + " = " + lin[5] + " ; " + lin[1] + " < " + lin[3] + " ; " + lin[1] + "++)";
				}
				else if (line.Contains("{"))
				{
					CSharpCode += "\r\n\t\t\t";
					CSharpCode += "{";
				}
                else if (line.Contains("}") || line.Contains("fi"))
				{
					CSharpCode += "\r\n\t\t\t";
					CSharpCode += "}";
				}
				else if (line.Contains("="))
				{
					string[] lin = line.Split(' ');
                    lin = lin.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                    CSharpCode += "\r\n\t\t\t";
					if (lin.Length <= 4)
                        CSharpCode += lin[0] + " = " + lin[lin.Length - 2] + lin[lin.Length - 1];
					else
						CSharpCode += line;
				}

                else if (line.Contains("el") || line.Contains("elif"))
                {
                    CSharpCode += "\r\n\t\t\t}";
                    CSharpCode += "\r\n\t\t\t";
                    if (line.Contains("elif"))
                        CSharpCode += line.Replace("elif", "else if");
                    else if (line.Contains("el"))
                        CSharpCode += line.Replace("el", "else");
                    CSharpCode += "\r\n\t\t\t{";
                }

				else if(line.Contains("if"))
				{
                    CSharpCode += "\r\n\t\t";
                    CSharpCode += line;
                    CSharpCode += "\r\n\t\t\t{";
				}

			}

			#region compiling code
			CSharpCodeProvider codeProvider = new CSharpCodeProvider();

			// For Visual Basic Compiler try this :
			//Microsoft.VisualBasic.VBCodeProvider

			ICodeCompiler compiler = codeProvider.CreateCompiler();
			CompilerParameters parameters = new CompilerParameters();
			string appName = simple_name + ".exe";
			parameters.GenerateExecutable = true;
			if (appName == "")	
			{
				System.Windows.Forms.MessageBox.Show(this, "Application name cannot be empty");
				return ;
			}

			string output = "";
			for (int i = 0; i < (file_arr.Length - 1); i++)
			{
				output += file_arr[i] + "\\";
			}

			parameters.OutputAssembly = output + appName;

			if (simple_name == "")
			{
				System.Windows.Forms.MessageBox.Show(this, "Main Class Name cannot be empty");
				return ;
			}

			parameters.MainClass = simple_name + "." + simple_name;

			// Add available assemblies - this should be enough for the simplest
			// applications.
			foreach (Assembly asm in AppDomain.CurrentDomain.GetAssemblies()) 
			{
				parameters.ReferencedAssemblies.Add(asm.Location);
			}

			String code = CSharpCode;
			//System.Windows.Forms.MessageBox.Show(this, code);

			CompilerResults results = compiler.CompileAssemblyFromSource(parameters, code);

			if (results.Errors.Count > 0)
			{
				string errors = "Compilation failed:\n";
				foreach (CompilerError err in results.Errors)
				{
					errors += err.ToString() + "\n";
				}
				System.Windows.Forms.MessageBox.Show(this, errors, "There were compilation errors");
			}
			else
			{
				#region Executing generated executable
				// try to execute application

				try
				{
					if (!System.IO.File.Exists(output + appName))
					{
						MessageBox.Show(String.Format("Can't find {0}", appName), "Can't execute.", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}
					ProcessStartInfo pInfo = new ProcessStartInfo(output + appName);
					Process.Start(pInfo);
				}
				catch (Exception ex)
				{
					MessageBox.Show(String.Format("Error while executing {0}", appName) + ex.ToString(),
							"Can't execute.", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}

				#endregion
			}
			#endregion
		}

		private void lexemesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			#region for Sixteen++ symbol table

			string input = richTextBox1.Text;

			try
			{
				if (input != "")
				{
					string[] Ainput = input.Split(' ', '\n');

					//remove while space index to array.
					Ainput = Ainput.Where(x => !string.IsNullOrEmpty(x)).ToArray();
					string msg = "Token\t\tType";
					int lineCount = 0;

					foreach (string s in Ainput)
					{
						msg += Environment.NewLine;

						if (s.Contains('.'))
						{
							msg += s + "\t\t" + "Start_of_Line_" + (++lineCount).ToString();
						}

						if (s != ".")
						{
							msg += s + "\t\t";
							if (Scanner_Sixteen.isEndOfStatement(s))
								msg += "End_Of_Statement";
							else if (Scanner_Sixteen.isStart(s))
								msg += "Start_of_Program_Or_Function";
							else if (Scanner_Sixteen.isEnd(s))
								msg += "End_of_Program_Or_Function";
							else if (Scanner_Sixteen.isDataType(s))
								msg += "Data_Type";
							else if (Scanner_Sixteen.isSpecalCharacter(s))
								msg += "Special_Character";
							else if (Scanner_Sixteen.isNumber(s))
								msg += "Number_Literal";
							else if (Scanner_Sixteen.isRational(s))
								msg += "Rational_Literal";
							else if (Scanner_Sixteen.isKeyword(s))
								msg += "Keyword";
							else if (Scanner_Sixteen.isOperator(s))
								msg += "Operator";
							else if (Scanner_Sixteen.isChar(s))
								msg += "Character_Literal";
							else if (Scanner_Sixteen.isString(s))
								msg += "String Literal";
							else if (Scanner_Sixteen.isVariableORidentifier(s))
								msg += "Variable/Identifier";
						}

					}
					//new form is created here
					Form3 ss = new Form3(msg);
					ss.ShowDialog();
					//MessageBox.Show(this, msg, "Symbol Table", MessageBoxButtons.OK);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
			}

			if (input == "")
				MessageBox.Show(this, "Text Editor is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
			#endregion

			#region for Cpp symbol table
			//string input = richTextBox1.Text;

			//try
			//{
			//    if (input != "")
			//    {
			//        string[] Ainput = input.Split(' ', '\n');

			//        //remove while space index to array.
			//        Ainput = Ainput.Where(x => !string.IsNullOrEmpty(x)).ToArray();
			//        Scanner_CPP sc = new Scanner_CPP(Ainput[0]);
			//        string msg = "Token\t\tType";

			//        foreach (string s in Ainput)
			//        {
			//            msg += Environment.NewLine;
			//            msg += s + "\t\t";
			//            if (sc.isEndOfStatement(s))
			//                msg += "End Of Statement";
			//            else if (sc.isInteger(s))
			//                msg += "Integer Literal";
			//            else if (sc.isFloat(s))
			//                msg += "Float Literal";
			//            else if (sc.isKeyword(s))
			//                msg += "Keyword";
			//            else if (sc.isOperator(s))
			//            {
			//                if (sc.OperatorName(s) != null)
			//                    msg += sc.OperatorName(s);
			//                else
			//                    msg += "Operator";
			//            }
			//            else if (sc.isSpecialCharacter(s))
			//                msg += "Special Character";
			//            else if (sc.isChar(s))
			//                msg += "Character Literal";
			//            else if (sc.isString(s))
			//                msg += "String Literal";
			//            else if (sc.isVariableORidentifier(s))
			//                msg += "Variable/Identifier";
			//        }
			//        Form3 ss = new Form3(msg);
			//        ss.ShowDialog();
			//        MessageBox.Show(this, msg, "Symbol Table", MessageBoxButtons.OK);
			//    }
			//}
			//catch (Exception ex)
			//{
			//    MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
			//}

			//if (input == "")
			//    MessageBox.Show(this, "Text Editor is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
			#endregion
		}

		private void equivalentCCodeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (richTextBox1.Text == "")
			{
				MessageBox.Show(this, "Text Editor is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
				return;
			}
			//file name pta karna hai
            string[] file_arr = filepath.Split('\\');
            string name = file_arr[file_arr.Length - 1];
            string simple_name = name.Remove(name.IndexOf('.'));
            string CSharpCode = "using System;\r\n\r\n namespace " + simple_name + " \t { \r\n\tpublic class " + simple_name + "\t{ \r\n\t\tpublic static void Main(String[] args) ";

            string[] lines = replace().Split('\n');
            List<temp> list = new List<temp>();

            foreach (string line in lines)
            {
                if (line.Contains("var"))
                {
                    temp tt = new temp();
                    CSharpCode += "\r\n\t\t\t";
                    if (line.Contains("number"))
                    {
                        CSharpCode += "int ";
                        tt.type = "int";
                    }
                    else if (line.Contains("rational"))
                    {
                        CSharpCode += "float ";
                        tt.type = "float";
                    }
                    else if (line.Contains("truth"))
                    {
                        CSharpCode += "bool ";
                        tt.type = "bool";
                    }
                    else if (line.Contains("letter"))
                    {
                        CSharpCode += "string ";
                    }

                    string[] lin = line.Split(' ');
                    lin = lin.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                    CSharpCode += lin[1] + lin[lin.Length - 1];
                    tt.name = lin[1];
                    list.Add(tt);
                }
                else if (line.Contains("["))
                {
                    CSharpCode += "\r\n\t\t";
                    CSharpCode += "{";
                }
                else if (line.Contains("]"))
                {
                    CSharpCode += "\r\n\t\t}\r\n\t}\r\n}";
                }
                else if (line.Contains("acquire"))
                {
                    string[] lin = line.Split(' ');
                    lin = lin.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                    CSharpCode += "\r\n\t\t\t";
                    if (lin.Length <= 2)
                    {
                        CSharpCode += "Console.Read();";
                    }
                    else
                    {
                        bool chhk = true;
                        temp tt;
                        tt.name = lin[0];
                        tt.type = "int";
                        if (list.Contains(tt))
                        {
                            CSharpCode += lin[0] + " = int.Parse(Console.ReadLine())" + lin[lin.Length - 1];
                            chhk = false;
                        }

                        tt.type = "float";
                        if (list.Contains(tt))
                        {
                            CSharpCode += lin[0] + " = float.Parse(Console.ReadLine())" + lin[lin.Length - 1];
                            chhk = false;
                        }

                        tt.type = "bool";
                        if (list.Contains(tt))
                        {
                            CSharpCode += lin[0] + " = bool.Parse(Console.ReadLine())" + lin[lin.Length - 1];
                            chhk = false;
                        }
                        if (chhk)
                            CSharpCode += lin[0] + " = Console.ReadLine()" + lin[lin.Length - 1];
                    }
                }
                else if (line.Contains("display"))
                {
                    string[] lin = line.Split(' ');
                    lin = lin.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                    CSharpCode += "\r\n\t\t\t";
                    if (line.Contains(")"))
                        CSharpCode += "Console.WriteLine(" + lin[lin.Length - 3] + ")" + lin[lin.Length - 1];
                    else if (line.Contains("\""))
                    {
                        CSharpCode += "Console.WriteLine(";
                        for (int i = 1; i < (lin.Length - 1); i++)
                            CSharpCode += lin[i];
                        CSharpCode += ")" + lin[lin.Length - 1];
                    }
                    else
                        CSharpCode += "Console.WriteLine(" + lin[lin.Length - 2] + ")" + lin[lin.Length - 1];
                }
                else if (line.Contains("repeat"))
                {
                    string[] lin = line.Split(' ');
                    lin = lin.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                    CSharpCode += "\r\n\t\t\t";
                    CSharpCode += "for (" + lin[1] + " = " + lin[5] + " ; " + lin[1] + " < " + lin[3] + " ; " + lin[1] + "++)";
                }
                else if (line.Contains("{"))
                {
                    CSharpCode += "\r\n\t\t\t";
                    CSharpCode += "{";
                }
                else if (line.Contains("}") || line.Contains("fi"))
                {
                    CSharpCode += "\r\n\t\t\t";
                    CSharpCode += "}";
                }
                else if (line.Contains("="))
                {
                    string[] lin = line.Split(' ');
                    lin = lin.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                    CSharpCode += "\r\n\t\t\t";
                    if (lin.Length <= 4)
                        CSharpCode += lin[0] + " = " + lin[lin.Length - 2] + lin[lin.Length - 1];
                    else
                        CSharpCode += line;
                }

                else if (line.Contains("el") || line.Contains("elif"))
                {
                    CSharpCode += "\r\n\t\t\t}";
                    CSharpCode += "\r\n\t\t\t";
                    if (line.Contains("elif"))
                        CSharpCode += line.Replace("elif", "else if");
                    else if (line.Contains("el"))
                        CSharpCode += line.Replace("el", "else");
                    CSharpCode += "\r\n\t\t\t{";
                }

                else if (line.Contains("if"))
                {
                    CSharpCode += "\r\n\t\t";
                    CSharpCode += line;
                    CSharpCode += "\r\n\t\t\t{";
                }

            }

			Form4 ff = new Form4(CSharpCode);
			ff.Show();
		}
	}
}
