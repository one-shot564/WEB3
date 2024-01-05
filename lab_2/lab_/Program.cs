using System;

namespace lab_
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создание экземпляра кольцевого списка
            CircularLinkedList<int> myList = new CircularLinkedList<int>();

            // Подписка на события
            myList.ItemAdded += (sender, e) => Console.WriteLine("Элемент добавлен.");
            myList.ItemRemoved += (sender, e) => Console.WriteLine("Элемент удален.");
            myList.ListCleared += (sender, e) => Console.WriteLine("Список очищен.");

            // Добавление элементов
            Console.WriteLine("Добавление элементов:");
            myList.Add(1);
            myList.Add(2);
            myList.Add(3);

            // Вывод элементов списка
            Console.WriteLine("Содержимое списка:");
            foreach (var item in myList)
            {
                Console.WriteLine(item);
            }

            // Проверка наличия элемента
            Console.WriteLine("Содержит ли список элемент 2? " + myList.Contains(2));

            // Удаление элемента
            Console.WriteLine("Удаление элемента:");
            myList.Remove(2);

            // Вывод элементов после удаления
            Console.WriteLine("Содержимое списка после удаления:");
            foreach (var item in myList)
            {
                Console.WriteLine(item);
            }

            // Очистка списка
            Console.WriteLine("Очистка списка:");
            myList.Clear();

            // Проверка списка после очистки
            Console.WriteLine("Содержимое списка после очистки:");
            foreach (var item in myList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
