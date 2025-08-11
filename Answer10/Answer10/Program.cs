namespace Answer10
{
    class Node
    {
        public int Data;
        public Node next;
        public Node(int data)
        {
            Data = data;
            next = null;
        }
    }

    class Stack
    {
        Node top = null;
        public void Push(int data)
        {
            Node newNode = new Node(data);
            newNode.next = top;
            top = newNode;
        }
        public void Pop()
        {
            if (top == null)
            {
                Console.WriteLine("Stack is empty");
                return;
            }
            Console.WriteLine("Popped: " + top.Data);
            top = top.next;
        }
        public void Display()
        {
            Node t = top;
            while (t != null)
            {
                Console.Write(t.Data + " ");
                t = t.next;
            }
            Console.WriteLine();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Stack stack = new Stack();
            string ch;
            do
            {
                Console.WriteLine("1.Push into Stack");
                Console.WriteLine("2.Pop out from Stack");
                Console.WriteLine("3.Display Stack");
                Console.WriteLine("Enter choice: ");
                ch = Console.ReadLine();
                switch (ch)
                {
                    case "1":
                        Console.WriteLine("Enter number: ");
                        int n = int.Parse(Console.ReadLine());
                        stack.Push(n);
                        break;
                    case "2":
                        stack.Pop();
                        break;
                    case "3":
                        stack.Display();
                        break;
                    default:
                        Console.WriteLine("Invalid");
                        break;
                }

            } while (ch != "4");
        }
    }

}


