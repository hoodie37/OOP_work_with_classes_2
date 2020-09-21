using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_lab
{
    public class Animals
    {
        public virtual void Sound() { }
        public virtual void action() { }
    }

    public class Cat : Animals
    {
        string c;
        public Cat()
        {
            c = "I am cat";
        }

        override public void Sound()
        {
            Console.WriteLine("Meow");
        }

        override public void action()
        {
            Console.WriteLine("I am chilling");
        }
    }

    public class Dog : Animals
    {

        public Dog()
        {
            string d = "I am dog";
        }
        override public void Sound()
        {
            Console.WriteLine("wouw");
        }

        override public void action()
        {
            Console.WriteLine("I am ready to do smth");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            int c = 10;

            Console.WriteLine("");
            MyList<Animals> l = new MyList<Animals>();

            Random rnd = new Random();
            for (int i = 0; i < c; i++)
            {
                if (rnd.Next(0, 2) == 0)
                    l.add(new Dog());
                else
                    l.add(new Cat());
            }
            Console.WriteLine("");
            Console.WriteLine("List methods");

            for (l.First(); l.Eol(); l.Next())
            {
                if (rnd.Next(0, 2) == 0)
                    l.getObject().action();
                else
                    l.getObject().Sound();
            }
            Console.WriteLine("");
            Console.WriteLine("Delete");
            l.First();
            for (int i = 0; i < c; i++)
            {
                if (rnd.Next(0, 5) == 0)
                    l.delete(l.getObject());
                l.Next();
            }
            Console.WriteLine("");
            Console.WriteLine("List");

            for (l.First(); l.Eol(); l.Next())
            {
                if (rnd.Next(0, 2) == 0)
                    l.getObject().action();
                else
                    l.getObject().Sound();
            }
        }
    }

    public class Node<Tip>
    {
        public Tip data;
        public Node<Tip> next;

        public Node(Tip value)
        {
            data = value;
        }
    }

    public class MyList<Tip>
    {
        public Node<Tip> Head;
        public Node<Tip> Tail;
        public int count;
        public Node<Tip> current;
        public MyList()
        {
            Head = null;
            Tail = null;
            current = Head;
            count = 0;
        }

        public MyList(Tip value)
        {
            var node = new Node<Tip>(value);
            Head = node;
            current = Head;
            Tail = node;
            count++;
        }

        public MyList(Node<Tip> node)
        {
            Head = node;
            Tail = node;
            current = Head;
            count++;
        }

        public bool Eol()
        {
            if (current.next == null)
                return false;
            return true;
        }

        public void First()
        {
            current = Head;
        }

        public void Next()
        {
            if (current.next == null)
                return;
            current = current.next;

        }

        public Tip getObject()
        {
            return current.data;
        }

        public void add(Tip value)
        {
            var node = new Node<Tip>(value);
            if (Head == null)
            {
                Head = node;
            }
            else
            {
                Tail.next = node;
            }
            Tail = node;
            count++;
        }

        public void delete(Tip value)
        {

            if (Head != null)
            {
                if (Head.data.Equals(value))
                {
                    Head = Head.next;
                    count--;
                    Console.WriteLine("Deleted {0}", Head.data);
                    return;
                }

                current = Head.next;
                var pred = Head;

                while (current != null)
                {
                    if (current.data.Equals(value))
                    {
                        if (current.next == null)
                        {
                            Tail = pred;
                            count--;
                            Console.WriteLine("Deleted {0}", current.data);
                            current = Tail;
                            return;
                        }
                        else
                        {
                            pred.next = current.next;
                            count--;
                            Console.WriteLine("Deleted {0}", current.data);
                            current = current.next;
                            return;
                        }
                    }
                    pred = current;
                    current = current.next;
                }
            }
            return;
        }

        public void nalichie(Tip value)
        {
            for (First(); current != null; Next())
            {
                if (current.data.Equals(value))
                {
                    Console.WriteLine("Deleted {0}", current.data);
                    return;
                }
            }

            Console.WriteLine("Not detected");

        }

    }
}
