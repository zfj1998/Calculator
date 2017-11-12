using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Stack
    {
        public Node first;
        public int length;

        public Stack()
        {
            this.length = 0;
            Node firstNode = new Node('!', 0);
            this.first = firstNode;
        }

        public bool IsEmpty()
        {
            if(length == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Top(ref char ch, ref double op)
        {
            if(IsEmpty())
            {
                return false;
            }
            else
            {
                ch = this.first.link.ch;
                op = this.first.link.op;
                return true;
            }
        }

        public void Push(char ch, double op)
        {
            Node newNode = new Node(ch, op);
            newNode.link = this.first.link;
            this.first.link = newNode;
            this.length += 1;
        }

        public bool Pop()
        {
            Node p;
            if(IsEmpty())
            {
                return false;
            }
            else
            {
                p = this.first.link;
                this.first.link = p.link;
                this.length = this.length - 1;
                return true;
            }
        }
    }
}
