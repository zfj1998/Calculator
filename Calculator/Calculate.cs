using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Calculate
    {
        public Expression readInExp = new Expression();

        private Expression sharedExp = new Expression();
        private Stack chStack = new Stack();
        private Stack opStack = new Stack();
        private Pair answer = new Pair();

        public Pair Run(List<String> str)
        {
            Transfer(str);
            Node currentNode;
            char ch='\0';
            double op=0.0;
            int length, n = 1;
            length = sharedExp.length;
            while (n <= length)
            {
                currentNode = sharedExp.GetNode(n);
                ch = currentNode.ch;
                op = currentNode.op;
                if (ch == '\0')
                {
                    PushOperand(op);
                }
                else
                {
                    if(DoOperator(ch)){ }
                    else
                    {
                        answer.answer = 0;
                        answer.flag = false;
                        return answer;
                    }
                }
                n += 1;
            }
            if(opStack.Top(ref ch,ref op))
            {
                answer.answer = op;
                answer.flag = true;
                return answer;
            }
            answer.answer = 0;
            answer.flag = false;
            return answer;
        }//end of method

        public void PushOperand(double op)
        {
            opStack.Push('\0', op);
        }

        public bool DoOperator(char ch)
        {
            bool result;
            double op1=0, op2=0;
            result = GetOperands(ref op1, ref op2);
            if(result)
            {
                switch(ch)
                {
                    case '+':
                        op2 += op1;
                        opStack.Push('\0', op2);
                        return true;
                    case '-':
                        op2 -= op1;
                        opStack.Push('\0', op2);
                        return true;
                    case '*':
                        op2 *= op1;
                        opStack.Push('\0', op2);
                        return true;
                    case '/':
                        if (Math.Abs(op1) < 1E-6)
                        {
                            return false;
                        } else {
                            op2 /= op1;
                            opStack.Push('\0', op2);
                            return true;
                        }
                    case '%':
                        if (Math.Abs(op1) < 1E-6)
                        {
                            return false;
                        }
                        else
                        {
                            op2 = op2 % op1;
                            opStack.Push('\0', op2);
                            return true;
                        }
                    case '^':
                        if(op1<1 && op2<0)
                        {
                            return false;
                        }
                        else
                        {
                            op2 = Math.Pow(op2, op1);
                            opStack.Push('\0', op2);
                            return true;
                        }
                    case '!':
                        if(op2 < 0)
                        {
                            return false;
                        }
                        else
                        {
                            long temp = Convert.ToInt64(op2);
                            if(temp > 20)
                            {
                                return false;
                            }
                            else
                            {
                                temp = Factorial(temp);
                                op2 = Convert.ToDouble(temp);
                                opStack.Push('\0', op2);
                                return true;
                            }
                        }
                    default:
                        return false; 
                }
            }
            else
            {
                return false;
            }
        }
    
        public bool GetOperands(ref double op1, ref double op2)
        {
            char temp='\0';
            if(!opStack.Top(ref temp, ref op1))
            {
                return false;
            }
            opStack.Pop();
            if(!opStack.Top(ref temp, ref op2))
            {
                return false;
            }
            opStack.Pop();
            return true;
        }

        private int Icp(char ch)
        {
            switch(ch)
            {
                case '#':
                    return 0;
                case '+':
                    return 2;
                case '-':
                    return 2;
                case '*':
                    return 4;
                case '/':
                    return 4;
                case '%':
                    return 4;
                case '^':
                    return 7;
                case '(':
                    return 10;
                case ')':
                    return 1;
                case '!':
                    return 8;
                default:
                    return -1;
            }
        }

        private int Isp(char ch)
        {
            switch(ch)
            {
                case '#':
                    return 0;
                case '+':
                    return 3;
                case '-':
                    return 3;
                case '*':
                    return 5;
                case '/':
                    return 5;
                case '%':
                    return 5;
                case '^':
                    return 6;
                case '(':
                    return 1;
                case ')':
                    return 10;
                case '!':
                    return 9;
                default:
                    return -1;
            }
        }

        private void Transfer(List<String> str) //中缀转化为后缀，存在sharedExp中
        {
            Node currentNode;
            char ch, temp='\0';
            double op=0;
            int length, n = 1;
            length = readInExp.Modify(str);
            chStack.Push('#', 0);
            while(true)
            {
                currentNode = readInExp.GetNode(n);
                ch = currentNode.ch;
                op = currentNode.op;
                if(ch == '\0')
                {
                    sharedExp.LinkNode(ch, op);
                }
                else if (ch == ')')
                {
                    for (chStack.Top(ref temp, ref op), chStack.Pop(); temp != '('; chStack.Top(ref temp, ref op), chStack.Pop())
                    {
                        sharedExp.LinkNode(temp, 0);
                    }
                }//end else if
                else
                {
                    for(chStack.Top(ref temp, ref op), chStack.Pop(); Icp(ch) <= Isp(temp); chStack.Top(ref temp, ref op), chStack.Pop())
                    {
                        sharedExp.LinkNode(temp, 0);
                    }
                    chStack.Push(temp, 0);
                    chStack.Push(ch, 0);
                }
                if (n == length) break;
                n += 1;
            }//end while
            while(!chStack.IsEmpty())
            {
                chStack.Top(ref temp, ref op);
                chStack.Pop();
                if(temp != '#')
                {
                    sharedExp.LinkNode(temp, 0);
                }
            }
        }//end method

        private long Factorial(long n)
        {
            if(n > 0)
            {
                long temp = 1;
                for (int i = 1; i <= n; i++)
                {
                    temp *= i;
                }
                return temp;
            }
            else
            {
                return 0;
            }
        }

    }//end of class
}
