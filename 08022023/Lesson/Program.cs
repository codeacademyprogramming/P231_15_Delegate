using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Lesson
{
    internal class Program
    {
        public delegate bool Check(int num);
        public delegate int Calc(int x, int y);
        static void Main(string[] args)
        {
            Console.WriteLine(IsEven(4));

            int[] numbers = { 1, 2, 3, 54, 23, 54, 6, 1, 5, 7, 34, 22, 21 };

            Console.WriteLine(SumOfEven(numbers));
            Console.WriteLine(SumOfOdd(numbers));
            Console.WriteLine(SumOfDividedBy3(numbers));

            Console.WriteLine(Sum(numbers,IsEven));
            Console.WriteLine(Sum(numbers, IsOdd));
            Console.WriteLine(Sum(numbers,delegate(int x) { return x % 7 == 0; }));
            Console.WriteLine(Sum(numbers,x=>x>=20 && x<=50));

            Console.WriteLine(Sum(numbers,x=>x%10==0));

            Check check1 = IsEven;
            Check check2 = delegate (int num) { return num % 5 == 0; };
            Check check3 = x => x % 5 == 0;

            Calc calc1 = Sum;
            Calc calc2 = delegate (int x, int y)
            {
                return x * y;
            };
            Calc calc3 = (x,y)=>x - y;

            var result = calc3(10, 20);
            result = calc3.Invoke(30, 100);

            Console.WriteLine(result);

            Func<int,int,int> funcDel = Sum;
            funcDel = delegate (int x, int y) { return x + y; };
            funcDel = (x, y) => x + y;

            Func<int, bool> checkFunc = IsEven;

            Action<int, int, int> actionDel = ShowSum;

            Predicate<int> predicateDel = IsDividedBy3;


            List<string> names = new List<string>{ "Hikmet", "Abbas", "Hesen", "Narmin" };

            var filteredList = Filter(names, x => x.Contains('a'));
            filteredList = Filter(names, x => x[0] == 'H');


            foreach (var item in filteredList)
            {
                Console.WriteLine(item);
            }
        }


        static int Sum(int num1,int num2)
        {
            return num1 + num2;
        }
        static void ShowSum(int num1, int num2, int num3)
        {
            Console.WriteLine(num1+num2+num3);
        }
        static bool IsEven(int num)
        {
            return num % 2 == 0;
        }

        static bool IsOdd(int num)
        {
            return num % 2 == 1;
        }

        static bool IsDividedBy3(int num)
        {
            return num % 3 == 0;
        }

        static int Sum(int[] numbers,Check method)
        {
            int sum = 0;
            foreach (var item in numbers)
            {
                if (method(item))
                {
                    sum += item;
                }
            }

            return sum;
        }

        static int SumOfEven(int[] numbers)
        {
            int sum = 0;

            foreach (var item in numbers)
            {
                if (IsEven(item))
                    sum += item;
            }
            return sum;
        }

        static int SumOfOdd(int[] numbers)
        {
            int sum = 0;

            foreach (var item in numbers)
            {
                if (IsOdd(item))
                    sum += item;
            }
            return sum;
        }

        static int SumOfDividedBy3(int[] numbers)
        {
            int sum = 0;

            foreach (var item in numbers)
            {
                if (IsDividedBy3(item))
                    sum += item;
            }
            return sum;
        }

        static List<string> Filter(List<string> names,Predicate<string> predicate)
        {
            var list = new List<string>();

            foreach (var item in names)
            {
                if (predicate(item))
                {
                    list.Add(item); 
                }
            }

            return list;
        } 



    }
}
