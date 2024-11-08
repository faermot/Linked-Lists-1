using System;

class LinkedList
{
    private static int[] data = new int[100];
    private static int[] next = new int[100];
    private static int head = -1;
    private static int head2 = -1;
    private static int freeIndex = 0;

    public static void Add(int value)
    {
        if (freeIndex >= data.Length)
        {
            Console.WriteLine("Список переполнен!");
            return;
        }

        data[freeIndex] = value;
        next[freeIndex] = -1;

        if (head == -1)
        {
            head = freeIndex;
        }
        else
        {
            int current = head;
            while (next[current] != -1)
            {
                current = next[current];
            }
            next[current] = freeIndex;
        }

        freeIndex++;
    }

    public static void AddToSecondList(int value)
    {
        if (freeIndex >= data.Length)
        {
            Console.WriteLine("Список переполнен!");
            return;
        }

        data[freeIndex] = value;
        next[freeIndex] = -1;

        if (head2 == -1)
        {
            head2 = freeIndex;
        }
        else
        {
            int current = head2;
            while (next[current] != -1)
            {
                current = next[current];
            }
            next[current] = freeIndex;
        }

        freeIndex++;
    }

    public static void AddFirst(int value)
    {
        if (freeIndex >= data.Length)
        {
            Console.WriteLine("Список переполнен!");
            return;
        }

        data[freeIndex] = value;
        next[freeIndex] = head;
        head = freeIndex;

        freeIndex++;
    }

    public static void Display(int listHead)
    {
        int current = listHead;
        while (current != -1)
        {
            Console.Write(data[current] + " -> ");
            current = next[current];
        }
        Console.WriteLine("null");
    }

    public static void Display()
    {
        Display(head);
    }

    public static void Remove(int value)
    {
        if (head == -1) return;

        if (data[head] == value)
        {
            head = next[head];
            return;
        }

        int current = head;
        int previous = -1;

        while (current != -1 && data[current] != value)
        {
            previous = current;
            current = next[current];
        }

        if (current != -1)
        {
            next[previous] = next[current];
        }
    }

    public static void Reverse()
    {
        int prev = -1;
        int current = head;
        int nextNode;

        while (current != -1)
        {
            nextNode = next[current];
            next[current] = prev;
            prev = current;
            current = nextNode;
        }

        head = prev;
    }

    public static void DelDuplicates()
    {
        int current = head;
        while (current != -1)
        {
            int nextNode = next[current];
            int previous = current;

            while (nextNode != -1)
            {
                if (data[current] == data[nextNode]) next[previous] = next[nextNode];
                else previous = nextNode;

                nextNode = next[previous];
            }

            current = next[current];
        }
    }

    public static void Unification()
    {
        if (head == -1)
        {
            head = head2;
        }
        else
        {
            int current = head;
            while (next[current] != -1)
            {
                current = next[current];
            }
            next[current] = head2;
        }
        head2 = -1;
    }

    static void Main(string[] args)
    {
        Add(10);
        Add(20);
        Add(30);
        Add(10);
        Add(40);

        Console.WriteLine("Содержимое первого списка:");
        Display();

        AddToSecondList(50);
        AddToSecondList(60);
        AddToSecondList(70);

        Console.WriteLine("Содержимое второго списка:");
        Display(head2);

        Unification();
        Console.WriteLine("Содержимое объединённого списка:");
        Display();
    }
}
