using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Node
    {
        public char ch;
        public double op;
        public Node link;

        public Node(char ch, double op)
        {
            this.ch = ch;
            this.op = op;
        }

        public Node(char ch, double op, Node link)
        {
            this.ch = ch;
            this.op = op;
            this.link = link;
        }

        public Node InsertAfter(char ch, double op)
        {
            Node newNode = new Node(ch, op, this.link);
            this.link = newNode;
            return newNode;
        }
    }
}
