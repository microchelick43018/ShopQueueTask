using System;
using System.Collections.Generic;
namespace ShopQueueTask
{
    class Program
    {
        static void ServeClients(int cost, ref int balance)
        {
            Console.Clear();
            Console.WriteLine($"Следующий на очереди покупатель с суммой {cost}");
            balance += cost;
            Console.WriteLine($"Клиент обслужен! Текущий баланс: {balance}");
            Console.WriteLine("Нажмите любую клавишу, чтобы продолжить.");
            Console.ReadKey();     
        }

        static void InputIntChecker(ref int value)
        {
            bool isCorrect = false;
            while (true)
            {
                isCorrect = int.TryParse(Console.ReadLine(), out value);
                if (!isCorrect)
                {
                    Console.WriteLine("Значение введено некорректно! Повторите ввод:");
                }
                else
                {
                    return;// точка выхода из цикла цикла
                }
            }
        }

        static void Main(string[] args)
        {
            Queue<int> values = new Queue<int>();
            int balance = 0;
            Console.WriteLine("Введите количество покупателей: ");
            int quantityOfClients = Convert.ToInt32(Console.ReadLine());
            int newValue = 0;
            for (int i = 0; i < quantityOfClients; i++)
            {                
                Console.WriteLine($"Введие цену {i + 1}-ого покупателя");
                InputIntChecker(ref newValue);
                values.Enqueue(newValue);
            }
            while (values.Count != 0)
            {
                ServeClients(values.Dequeue(), ref balance);
            }
            Console.WriteLine("Очередь закончена!");
            Console.ReadKey();
        }
    }
}
