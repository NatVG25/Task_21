using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Task_21
{
    class Program
    {
        const int a = 5; 
        const int b = 5;
        static int[,] area = new int[a, b] //создание двумерного массива
        {
            { 11, 5, 8, 4, 3 }, //инициализация массива
            { 6, 12, 8, 3, 5 },
            { 10, 5, 7, 4, 2 },
            { 1, 7, 8, 5, 3 },
            { 13, 9, 7, 4, 6 },
        };
       
         static void Main(string[] args)
        {
            ThreadStart threadStart = new ThreadStart(Gardener1); //создание делегата
            Thread gardener1 = new Thread(threadStart); //создание потока

            gardener1.Start(); //запуск потока (запуск метода Gardener1)

            Gardener2(); //запуск параллельно метода  Gardener2

            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    Console.Write(area[i, j] + " "); //вывод результата работы садовников
                }
                
                Console.WriteLine();
             }
            Console.ReadKey();
        }
        static void Gardener1() //метод садовника1
        {
            for (int i = 0; i < a; i++)  //перебираем массив
            {
                for (int j = 0; j < b; j++)
                {
                    if (area[i, j] > 0) //провряем условие, если значение в очередной ячейке >0, значит Садовника2 здесь не было
                    {
                        int delay = area[i, j]; //считывам значение ячейки
                        area[i, j] = -1; //записываем метку Садовника1 в ячейку
                        Thread.Sleep(delay); //делаем задержку на величину списанного значения
                    }
                    
                }
            }
        }
        static void Gardener2() //метод садовника 2
        {
            for (int i = b - 1; i > 0; i--) //перебираем массив
            {
                for (int j = a - 1; j > 0; j--)
                {
                    if (area[j, i] > 0) //провряем условие, если значение в очередной ячейке >0, значит Садовника1 здесь не было
                    {
                        int delay = area[j, i]; //считывам значение ячейки
                        area[j, i] = -2; //записываем метку Садовника1 в ячейку
                        Thread.Sleep(delay); //делаем задержку на величину списанного значения

                    }
                    
                }

            }

        }
    }
}




