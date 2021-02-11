using System;
using System.Collections.Generic;
namespace ShopQueueTask
{
    class Program
    {
        static void InitQueue(ref Queue<int> costs)
        {
            Console.WriteLine("Введите количество покупателей: ");
            int quantityOfClients = Convert.ToInt32(Console.ReadLine());
            int newCost;
            for(int i = 0; i < quantityOfClients; i++)
            {
                Console.WriteLine($"Введие цену {i + 1}-ого покупателя");
                newCost = Convert.ToInt32(Console.ReadLine());
                costs.Enqueue(newCost);
            }
        }
        
        static void ServeClients(Queue<int> costs)
        {
            int balance = 0;
            while(costs.Count != 0)
            {
                Console.Clear();
                Console.WriteLine($"Следующий на очереди покупатель с суммой {costs.Peek()}");
                balance += costs.Dequeue();
                Console.WriteLine($"Клиент обслужен! Текущий баланс: {balance}");
                Console.WriteLine("Нажмите любую клавишу, чтобы продолжить.");
                Console.ReadKey();
            }
            Console.WriteLine("Очередь закончена!");
        }

        static void Main(string[] args)
        {
            Queue<int> costs = new Queue<int>();
            InitQueue(ref costs);
            ServeClients(costs);
            Console.ReadKey();
        }
    }
}
