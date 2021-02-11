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
            for(int i = 0; i < quantityOfClients; i++)
            {
                Console.WriteLine($"Введие цену {i + 1}-ого покупателя");              
                costs.Enqueue(Convert.ToInt32(Console.ReadLine()));
            }
        }

        static void ServeClients(int cost, ref int balance)
        {
            Console.Clear();
            Console.WriteLine($"Следующий на очереди покупатель с суммой {cost}");
            balance += cost;
            Console.WriteLine($"Клиент обслужен! Текущий баланс: {balance}");
            Console.WriteLine("Нажмите любую клавишу, чтобы продолжить.");
            Console.ReadKey();     
        }

        static void Main(string[] args)
        {
            Queue<int> costs = new Queue<int>();
            int balance = 0;
            InitQueue(ref costs);
            while(costs.Count != 0)
            {
                ServeClients(costs.Dequeue(), ref balance);
            }
            Console.WriteLine("Очередь закончена!");
            Console.ReadKey();
        }
    }
}
