using System;
using System.Collections.Generic;
namespace ShopQueueTask
{
    class Program
    {
        static void ServeClient(int cost, ref int balance)
        {
            Console.Clear();
            Console.WriteLine($"Следующий на очереди покупатель с суммой {cost}");
            balance += cost;
            Console.WriteLine($"Клиент обслужен! Текущий баланс: {balance}");
            Console.WriteLine("Нажмите любую клавишу, чтобы продолжить.");
            Console.ReadKey();     
        }

        static int ReadInt()
        {
            bool isCorrect = false;
            int value = 0;
            isCorrect = int.TryParse(Console.ReadLine(), out value);
            while (isCorrect == false)
            {
                Console.Write("Неккоректный ввод! Повторите ещё раз: ");
                isCorrect = int.TryParse(Console.ReadLine(), out value);                
            }
            return value;
        }

        static void Main(string[] args)
        {
            Queue<int> purchases = new Queue<int>();
            int balance = 0;
            Console.WriteLine("Введите количество покупателей: ");
            int quantityOfClients = ReadInt();
            int newPurchase = 0;
            for (int i = 0; i < quantityOfClients; i++)
            {                
                Console.Write($"Введите цену покупки {i + 1}-ого клиента: ");
                newPurchase = ReadInt();
                purchases.Enqueue(newPurchase);
            }
            while (purchases.Count != 0)
            {
                ServeClient(purchases.Dequeue(), ref balance);
            }
            Console.WriteLine("Очередь закончена!");
            Console.ReadKey();
        }
    }
}
