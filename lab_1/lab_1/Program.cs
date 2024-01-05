using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RingBuffer<int> buffer = new RingBuffer<int>();
            buffer.ItemAdded += ItemAddedHandler;
            buffer.ItemRemoved += ItemRemovedHandler;

            bool running = true;
            while (running)
            {
                Console.WriteLine("\nВыберите действие:");
                Console.WriteLine("1: Добавить элемент");
                Console.WriteLine("2: Удалить элемент");
                Console.WriteLine("3: Показать буфер");
                Console.WriteLine("4: Выход");
                string action = Console.ReadLine();

                switch (action)
                {
                    case "1":
                        Console.WriteLine("Введите целочисленное значение для добавления:");
                        if (int.TryParse(Console.ReadLine(), out int numberToAdd))
                        {
                            buffer.Append(numberToAdd);
                        }
                        else
                        {
                            Console.WriteLine("Некорректный ввод!");
                        }
                        break;
                    case "2":
                        Console.WriteLine("Введите целочисленное значение для удаления:");
                        if (int.TryParse(Console.ReadLine(), out int numberToRemove))
                        {
                            try
                            {
                                if (!buffer.Detach(numberToRemove))
                                {
                                    Console.WriteLine("Элемент не найден.");
                                }
                            }
                            catch (InvalidOperationException ex)
                            {
                                Console.WriteLine($"Ошибка: {ex.Message}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Некорректный ввод!");
                        }
                        break;
                    case "3":
                        Console.WriteLine("Текущее содержимое буфера:");
                        Console.WriteLine(buffer.ToString());
                        break;
                    case "4":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Неизвестное действие.");
                        break;
                }
            }
        }

        private static void ItemAddedHandler(object sender, int item)
        {
            Console.WriteLine($"Элемент {item} был добавлен.");
        }

        private static void ItemRemovedHandler(object sender, int item)
        {
            Console.WriteLine($"Элемент {item} был удален.");
        }
    }
}
