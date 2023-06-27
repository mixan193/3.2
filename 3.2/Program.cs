using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;    //сумма
            Console.WriteLine("Введите количество карт");
            int cardsCount = EnterNumber();
            int[] cards = new int[cardsCount];
            for(int i = 0; i < cardsCount; i++)
            {
                Console.WriteLine($"Введите карту {i + 1}");
                cards[i] = EnterCard();
            }
            Sort(ref cards);
            foreach(int card in cards)
            {
                if(sum > 10)    // Проверяет если после добавления туза будет больше 21, то вместо 11 добавляет 1
                {
                    if(card == 11)
                    {
                        sum += 1;
                    }
                    else
                    {
                        sum += card;
                    }
                }
                else
                {
                    sum += card;
                }
            }
            Console.Write("Вы набрали ");
            if(sum < 21) 
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(sum);
                Console.ResetColor();
            }
            if(sum > 21)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(sum);
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(sum);
                Console.ResetColor();
            }
            Console.WriteLine(" баллов");
            Console.ReadKey();
        }
        //Функция ввода количества карт
        private static int EnterNumber()
        {
            bool isAccepted = false;
            int num = 0;
            while (!isAccepted)
            {
                try
                {
                    num = int.Parse(Console.ReadLine());
                    isAccepted = true;
                }
                catch
                {
                    Console.WriteLine("Введены неверные данные");
                }
            }
            return num;
        }

        //Функция ввода карт. Диапазон значений от 6 до 10 либо J, Q, K, A
        private static int EnterCard() 
        {
            int card = 0;
            bool isAccepted = false;
            string temp;
            while (!isAccepted)
            {
                temp = Console.ReadLine();
                try
                {
                    card = int.Parse(temp);
                    isAccepted = true;
                    if (card < 6 || card > 10)
                    {
                        isAccepted = false;
                        Console.WriteLine("Введены неверные данные");
                    }
                }
                catch
                {
                    isAccepted = true;
                    switch (temp)
                    {
                        case "A":
                            card = 11;
                            break;
                        case "J":
                            card = 2; 
                            break;
                        case "Q":
                            card = 3;
                            break;
                        case "K":
                            card = 4;
                            break;
                        default: 
                            isAccepted = false;
                            Console.WriteLine("Введены неверные данные");
                            break;
                    }
                }
            }
            return card;
        }

        //Сортирока пузырьком
        private static void Sort(ref int[] arr)
        {
            int temp;
            for(int i = 0; i < arr.Length; i++)
            {
                for(int j = i; j < arr.Length - i; j++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }
    }
}
