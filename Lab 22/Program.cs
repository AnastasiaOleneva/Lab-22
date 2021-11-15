using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Lab_22
{
    class Program
    {
        static int ArraySum () 
        {
            Console.WriteLine("Введите количество элеменов масссива");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] array = new int[n];
            Random rnd = new Random();
            int Sum = 0;
            for (int i = 0; i < n; i++)
            {
                array[i] = rnd.Next(100);
                Console.WriteLine(array[i]);
                Sum += array[i];
            }
           
            Console.WriteLine($"Сумма элементов массива равна {Sum} ");
            return Sum;
        }


        static void ArrayMax(Task task)
        {
            Console.WriteLine("Введите количество элеменов масссива");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] array = new int[n];
            Random rnd = new Random();
        
            for (int i = 0; i < n; i++)
            {
                array[i] = rnd.Next(100);
                Console.WriteLine(array[i]);
             
            }
            int maxValue = array[0];
            for (int i = 1; i < n; i++)
            {
                if (array[i]>maxValue)
                {
                    maxValue=array[i]  ;
                    
                }
            }
            Console.WriteLine($"Максимальное число в массиве {maxValue}");
            

        }
        static void Main(string[] args)
        {
            Func<int> func = new Func<int>(ArraySum);
            Task<int> task = new Task<int>(func);
            Action<Task> action = new Action<Task>(ArrayMax);
            Task task2 = task.ContinueWith(action);
            task.Start();
            task2.Wait();
            Console.WriteLine("Main окончил работу");
            Console.ReadKey();
        }
    }
}
