namespace Answer6
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
    class Queue
    {
        Node f = null, r = null;
        public void Insert(int data)
        {
            Node newNode = new Node(data);
            if (r == null)
            {
                f = r = newNode;

            }
            else
            {
                r.next = newNode;
                r = newNode;
            }
        }
        public void Delete()
        {
            if (f == null)
            {
                Console.WriteLine("Queue is empty");
                return;
            }
            Console.WriteLine("Deleted: " + f.Data);
            f = f.next;
            if (f == null)
            {
                r = null;
            }
        }
        public void Display()
        {
            Node t = f;
            while (t != null)
            {
                Console.WriteLine(t.Data);
                t = t.next;
                Console.WriteLine();
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Queue queue = new Queue();
            string ch;
            do
            {
                Console.WriteLine("1. Insert into Queue");
                Console.WriteLine("2.Delete from queue");
                Console.WriteLine("3.Display Queue");
                Console.WriteLine("Enter choice: ");
                ch = Console.ReadLine();
                switch (ch)
                {
                    case "1":
                        Console.WriteLine("Enter number: ");
                        int n = int.Parse(Console.ReadLine());
                        queue.Insert(n);
                        break;
                    case "2":
                        queue.Delete();
                        break;
                    case "3":
                        queue.Display();
                        break;
                    default:
                        Console.WriteLine("Invalid");
                        break;
                }

            } while (ch != "4");
        }
    }

}

