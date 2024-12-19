using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\nВыберите задание (1-10) или введите 0 для выхода:");
            Console.WriteLine("1. Реализовать очередь (Enqueue, Dequeue, Peek)");
            Console.WriteLine("2. Очередь с фиксированным размером");
            Console.WriteLine("3. Реверс очереди");
            Console.WriteLine("4. Очередь с приоритетом");
            Console.WriteLine("5. Круговая очередь");
            Console.WriteLine("6. Слияние двух очередей");
            Console.WriteLine("7. Очередь с двумя стеками");
            Console.WriteLine("8. Удаление элемента из очереди по значению");
            Console.WriteLine("9. Проверка на пустую очередь");
            Console.WriteLine("10. Максимальный элемент в очереди");

            if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 0 && choice <= 10)
            {
                switch (choice)
                {
                    case 0:
                        exit = true;
                        Console.WriteLine("Выход из программы.");
                        break;
                    case 1:
                        Task1();
                        break;
                    case 2:
                        Task2();
                        break;
                    case 3:
                        Task3();
                        break;
                    case 4:
                        Task4();
                        break;
                    case 5:
                        Task5();
                        break;
                    case 6:
                        Task6();
                        break;
                    case 7:
                        Task7();
                        break;
                    case 8:
                        Task8();
                        break;
                    case 9:
                        Task9();
                        break;
                    case 10:
                        Task10();
                        break;
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Введите корректное число от 0 до 10.");
            }
        }
    }

    static void Task1()
    {
        Console.WriteLine("Задание 1: Реализовать очередь.");
        var queue = new Queue<int>();
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        Console.WriteLine($"Элемент в начале очереди: {queue.Peek()}");
        Console.WriteLine($"Извлечён элемент: {queue.Dequeue()}");
        Console.WriteLine($"Оставшиеся элементы: {string.Join(", ", queue)}");
    }

    static void Task2()
    {
        Console.WriteLine("Задание 2: Очередь с фиксированным размером.");
        var fixedQueue = new FixedQueue<int>(3);
        fixedQueue.Enqueue(1);
        fixedQueue.Enqueue(2);
        fixedQueue.Enqueue(3);
        fixedQueue.Enqueue(4); 
        Console.WriteLine($"Очередь: {string.Join(", ", fixedQueue)}");
    }

    static void Task3()
    {
        Console.WriteLine("Задание 3: Реверс очереди.");
        var queue = new Queue<int>(new[] { 1, 2, 3 });
        Console.WriteLine($"Исходная очередь: {string.Join(", ", queue)}");
        var reversedQueue = new Queue<int>(queue.Reverse());
        Console.WriteLine($"Реверс очереди: {string.Join(", ", reversedQueue)}");
    }

    static void Task4()
    {
        Console.WriteLine("Задание 4: Очередь с приоритетом.");
        var priorityQueue = new SortedDictionary<int, Queue<string>>();
        void Enqueue(string item, int priority)
        {
            if (!priorityQueue.ContainsKey(priority))
                priorityQueue[priority] = new Queue<string>();
            priorityQueue[priority].Enqueue(item);
        }

        Enqueue("Low priority", 2);
        Enqueue("High priority", 1);
        Enqueue("Medium priority", 2);

        Console.WriteLine("Очередь с приоритетом:");
        foreach (var queue in priorityQueue.OrderBy(q => q.Key))
            while (queue.Value.Any())
                Console.WriteLine(queue.Value.Dequeue());
    }

    static void Task5()
    {
        Console.WriteLine("Задание 5: Круговая очередь.");
        var circularQueue = new CircularQueue<int>(3);
        circularQueue.Enqueue(1);
        circularQueue.Enqueue(2);
        circularQueue.Enqueue(3);
        circularQueue.Enqueue(4); 
        Console.WriteLine($"Круговая очередь: {string.Join(", ", circularQueue)}");
    }

    static void Task6()
    {
        Console.WriteLine("Задание 6: Слияние двух очередей.");
        var queue1 = new Queue<int>(new[] { 1, 2, 3 });
        var queue2 = new Queue<int>(new[] { 4, 5, 6 });
        var mergedQueue = new Queue<int>(queue1.Concat(queue2));
        Console.WriteLine($"Объединённая очередь: {string.Join(", ", mergedQueue)}");
    }

    static void Task7()
    {
        Console.WriteLine("Задание 7: Очередь с двумя стеками.");
        var queue = new QueueWithTwoStacks<int>();
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        Console.WriteLine($"Извлечён элемент: {queue.Dequeue()}");
        Console.WriteLine($"Оставшиеся элементы: {queue}");
    }

    static void Task8()
    {
        Console.WriteLine("Задание 8: Удаление элемента из очереди по значению.");
        var queue = new Queue<int>(new[] { 1, 2, 3, 4 });
        int valueToRemove = 3;
        var newQueue = new Queue<int>(queue.Where(x => x != valueToRemove));
        Console.WriteLine($"Очередь после удаления {valueToRemove}: {string.Join(", ", newQueue)}");
    }

    static void Task9()
    {
        Console.WriteLine("Задание 9: Проверка на пустую очередь.");
        var queue = new Queue<int>();
        Console.WriteLine(queue.Any() ? "Очередь не пуста" : "Очередь пуста");
    }

    static void Task10()
    {
        Console.WriteLine("Задание 10: Максимальный элемент в очереди.");
        var queue = new Queue<int>(new[] { 1, 5, 3 });
        Console.WriteLine($"Максимальный элемент: {queue.Max()}");
    }
}

class FixedQueue<T> : Queue<T>
{
    private int _capacity;

    public FixedQueue(int capacity) => _capacity = capacity;

    public new void Enqueue(T item)
    {
        if (Count == _capacity)
            Dequeue();
        base.Enqueue(item);
    }
}

class CircularQueue<T> : Queue<T>
{
    private int _capacity;

    public CircularQueue(int capacity) => _capacity = capacity;

    public new void Enqueue(T item)
    {
        if (Count == _capacity)
            Dequeue();
        base.Enqueue(item);
    }
}

class QueueWithTwoStacks<T>
{
    private Stack<T> stack1 = new Stack<T>();
    private Stack<T> stack2 = new Stack<T>();

    public void Enqueue(T item) => stack1.Push(item);

    public T Dequeue()
    {
        if (!stack2.Any())
            while (stack1.Any())
                stack2.Push(stack1.Pop());
        return stack2.Any() ? stack2.Pop() : throw new InvalidOperationException("Очередь пуста.");
    }

    public override string ToString() => string.Join(", ", stack2.Concat(stack1.Reverse()));
}

