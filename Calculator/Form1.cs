using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        bool biOpe, sinOpe, operand, deci, leBrac, riBrac, beginning, haveDot; //见文档
        char deletedCh;        //若deletedStr为小数点时，则令(haveDot=false)
        List<String> lastStr;   //输入的字符串数组(含有分隔符',')

        public Form1()
        {
            InitializeComponent();
            SetBool();
            haveDot = false;
            beginning = true;
            lastStr = new List<String>();
        }

        private void Form1_Load(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }

        private void SetBool ()
        {
            biOpe = false;
            sinOpe = false;
            operand = false;
            deci = false;
            leBrac = false;
            riBrac = false;
            beginning = false;
        }

        private void newOrNot() //判断是否要输入新的表达式，以确定是否清空TextBox
        {
            if (beginning==true)
            {
                textBox2.Text = textBox1.Text;
                textBox1.Text = "";
                lastStr.Clear();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {//1
            newOrNot();
            if (sinOpe==false && riBrac==false)
            {
                textBox1.Text += "1";
                lastStr.Add("1");
                SetBool();
                operand = true;
            }
        }
        private void button12_Click(object sender, EventArgs e)
        {//2
            newOrNot();
            if (sinOpe == false && riBrac == false)
            {
                textBox1.Text += "2";
                lastStr.Add("2");
                SetBool();
                operand = true;
            }
        }
        private void button13_Click(object sender, EventArgs e)
        {//3
            newOrNot();
            if (sinOpe == false && riBrac == false)
            {
                textBox1.Text += "3";
                lastStr.Add("3");
                SetBool();
                operand = true;
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {//4
            newOrNot();
            if (sinOpe == false && riBrac == false)
            {
                textBox1.Text += "4";
                lastStr.Add("4");
                SetBool();
                operand = true;
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {//5
            newOrNot();
            if (sinOpe == false && riBrac == false)
            {
                textBox1.Text += "5";
                lastStr.Add("5");
                SetBool();
                operand = true;
            }
        }
        private void button8_Click(object sender, EventArgs e)
        {//6
            newOrNot();
            if (sinOpe == false && riBrac == false)
            {
                textBox1.Text += "6";
                lastStr.Add("6");
                SetBool();
                operand = true;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {//7
            newOrNot();
            if (sinOpe == false && riBrac == false)
            {
                textBox1.Text += "7";
                lastStr.Add("7");
                SetBool();
                operand = true;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {//8
            newOrNot();
            if (sinOpe == false && riBrac == false)
            {
                textBox1.Text += "8";
                lastStr.Add("8");
                SetBool();
                operand = true;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {//9
            newOrNot();
            if (sinOpe == false && riBrac == false)
            {
                textBox1.Text += "9";
                lastStr.Add("9");
                SetBool();
                operand = true;
            }
        }
        private void button16_Click(object sender, EventArgs e)
        {//0
            newOrNot();
            if (sinOpe == false && riBrac == false)
            {
                textBox1.Text += "0";
                lastStr.Add("0");
                SetBool();
                operand = true;
            }
        }
        private void button17_Click(object sender, EventArgs e)
        {//.
            if (operand==true)
            {
                if(haveDot==false)
                {
                    textBox1.Text += ".";
                    lastStr.Add(".");
                    SetBool();
                    deci = true;
                    haveDot = true;
                }
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {//'='
            if(leBrac==true || biOpe==true || lastStr.Count==0) { }
            else
            {
                int n_left = 0, n_right = 0;    //已经输入的左右括号个数
                foreach (String i in lastStr)
                {
                    if (i == ",(,")
                    {
                        n_left++;
                    }
                    if (i == ",),")
                    {
                        n_right++;
                    }
                }
                if (n_left != n_right) { }  //左右括号数不配对则不能开始计算
                else
                {
                    Calculate calculate = new Calculate();
                    Pair answer = calculate.Run(lastStr);
                    if (answer.flag == false)
                    {
                        textBox1.Text = "Error";
                    }
                    else
                    {
                        textBox2.Text = textBox1.Text;
                        textBox1.Text = Convert.ToString(answer.answer);
                    }
                    SetBool();
                    lastStr.Clear();
                    haveDot = false;
                    beginning = true;
                }
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {//'C'
            textBox1.Text = "";
            SetBool();
            lastStr.Clear();
            haveDot = false;
            beginning = true;
        }

        private void button26_Click(object sender, EventArgs e)
        {//←
            if (lastStr.Count != 0)
            {
                String tempSt = lastStr[lastStr.Count - 1]; //退格前最后一个字符
                String[] strList = tempSt.Split(new char[] { ',' });
                tempSt = strList[strList.Length / 2];
                deletedCh = Convert.ToChar(tempSt);

                if (deletedCh == 'a' || deletedCh == 'b' || deletedCh == 'c')
                {
                    textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 2);   //从textBox中删除
                }
                else
                {
                    textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);   //从textBox中删除
                }

                lastStr.RemoveAt(lastStr.Count - 1);    //从lastStr中删除
                if (lastStr.Count != 0)
                {
                    //以下用于判断newOperand是否需要重置，以此判断下一个输入的字符能否是数字或左括号
                    String tempSt2 = lastStr[lastStr.Count - 1];    //退格后最后一个字符
                    String[] strList_2 = tempSt2.Split(new char[] { ',' });
                    Char tempCh = Convert.ToChar(strList_2[strList_2.Length / 2]);
                    if (tempCh == '+' || tempCh == '-' || tempCh == '*' || tempCh == '/' || tempCh == '%' || tempCh == '^')
                    {
                        SetBool();
                        biOpe = true;
                    }
                    else if (tempCh == 'a' || tempCh == 'b' || tempCh == 'c' || tempCh == '!')
                    {
                        SetBool();
                        sinOpe = true;
                    }
                    else if (tempCh >= 48 && tempCh <= 57)
                    {
                        SetBool();
                        operand = true;
                    }
                    else if (tempCh == '.')
                    {
                        SetBool();
                        deci = true;
                    }
                    else if (tempCh == '(')
                    {
                        SetBool();
                        leBrac = true;
                    }
                    else if (tempCh == ')')
                    {
                        SetBool();
                        riBrac = true;
                    }

                    if (deletedCh == '.') //退格掉的是小数点
                    {
                        haveDot = false;
                    }
                }
                else //lastStr退格一次后已经为空了
                {
                    SetBool();
                    haveDot = false;
                    beginning = true;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {//'+'
            if (biOpe == false && leBrac == false && beginning == false)
            {
                textBox1.Text += "+";
                lastStr.Add(",+,");
                haveDot = false;
                SetBool();
                biOpe = true;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {//'-'
            if (biOpe == false && leBrac == false && beginning == false)
            {
                textBox1.Text += "-";
                lastStr.Add(",-,");
                haveDot = false;
                SetBool();
                biOpe = true;
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {//'*'
            if (biOpe == false && leBrac == false && beginning == false)
            {
                textBox1.Text += "*";
                lastStr.Add(",*,");
                haveDot = false;
                SetBool();
                biOpe = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {//'/'
            if (biOpe == false && leBrac == false && beginning == false)
            {
                textBox1.Text += "/";
                lastStr.Add(",/,");
                haveDot = false;
                SetBool();
                biOpe = true;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {//'%'
            if (biOpe == false && leBrac == false && beginning == false)
            {
                textBox1.Text += "%";
                lastStr.Add(",%,");
                haveDot = false;
                SetBool();
                biOpe = true;
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {//'^n ^'
            if (biOpe == false && leBrac == false && beginning == false)
            {
                textBox1.Text += "^";
                lastStr.Add(",^,");
                haveDot = false;
                SetBool();
                biOpe = true;
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {//'('
            if (biOpe==true || leBrac==true || beginning==true)
            {
                newOrNot();
                textBox1.Text += "(";
                lastStr.Add(",(,");
                SetBool();
                leBrac = true;
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {//')'
            if (biOpe == false && leBrac == false && beginning == false)
            {
                int n_left = 0, n_right = 0;    //已经输入的左右括号个数
                foreach (String i in lastStr)
                {
                    if (i == ",(,")
                    {
                        n_left++;
                    }
                    if (i == ",),")
                    {
                        n_right++;
                    }
                }
                if (n_right < n_left)
                {
                    textBox1.Text += ")";
                    lastStr.Add(",),");
                    SetBool();
                    riBrac = true;
                }
            }
        }

        

        private void button15_Click(object sender, EventArgs e)
        {//'^2 a'
            if(biOpe == false && leBrac == false && beginning == false)
            {
                textBox1.Text += "^2";
                lastStr.Add(",a,");
                SetBool();
                sinOpe = true;
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {//'^3 b'
            if (biOpe == false && leBrac == false && beginning == false)
            {
                textBox1.Text += "^3";
                lastStr.Add(",b,");
                SetBool();
                sinOpe = true;
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {//'根号 c'
            if (biOpe == false && leBrac == false && beginning == false)
            {
                textBox1.Text += "^(1/2)";
                lastStr.Add(",c,");
                SetBool();
                sinOpe = true;
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {//'n!'
            if (biOpe == false && leBrac == false && beginning == false)
            {
                textBox1.Text += "!";
                lastStr.Add(",!,");
                SetBool();
                sinOpe = true;
            }
        }

    }
}
