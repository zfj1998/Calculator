using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Expression
    {
        public Node first;
        public int length;

        public Expression()
        {
            this.length = 0;
            Node firstNode = new Node('!', 0);
            this.first = firstNode;
        }

        public int Modify(List<String> list)
        {
            char ch;
            double op;
            String str = "";
            foreach(String i in list)
            {
                str += i;
            }
            String[] tempList = str.Split(new char[] { ',' });
            List<String> strList = new List<string>();  //排除切片后存在空字符串的情况
            foreach(String i in tempList)
            {
                if(!(i==""))
                {
                    strList.Add(i);
                }
            }
            Node p = this.first;
            int length = strList.Count;
            for(int i=0; i<length;i++)
            {
                String str_2 = strList[i];
                if (strList[i].Length == 1 && (Convert.ToChar(strList[i]) < 48 || Convert.ToChar(strList[i]) > 57))  //不是数字
                {
                    ch = Convert.ToChar(strList[i]);
                    switch (ch)
                    {
                        case '+':
                        case '-':
                        case '*':
                        case '/':
                        case '%':
                        case '^':
                        case '(':
                        case ')':
                            p = p.InsertAfter(ch, 0);
                            break;
                        case 'a':
                            p = p.InsertAfter('^', 0);
                            p = p.InsertAfter('\0',2.0);
                            this.length++;
                            break;
                        case 'b':
                            p = p.InsertAfter('^', 0);
                            p = p.InsertAfter('\0',3.0);
                            this.length++;
                            break;
                        case 'c':
                            p = p.InsertAfter('^', 0);
                            p = p.InsertAfter('\0',0.5);
                            this.length++;
                            break;
                        case '!':
                            p = p.InsertAfter('!', 0);
                            p = p.InsertAfter('\0',0);
                            this.length++;
                            break;
                    }
                }
                else
                {
                    op = Convert.ToDouble(strList[i]);
                    p = p.InsertAfter('\0', op);
                }
                this.length++;
            }
            return this.length;
        }

        public void LinkNode(char ch, double op)
        {
            Node p = this.first;
            for (int i=1; i <= this.length; i++)
            {
                p = p.link;
            }
            p = p.InsertAfter(ch, op);
            this.length += 1;
        }

        public Node GetNode(int n)
        {
            Node p = this.first;
            for(int i=0; i<n; i++)
            {
                p = p.link;
            }
            return p;
        }
    }
}
