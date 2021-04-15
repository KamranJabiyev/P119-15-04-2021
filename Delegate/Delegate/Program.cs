using System;
using System.Collections.Generic;

namespace Delegate
{
    class Program
    {
        public delegate bool Check<T>(T n);
        public delegate R Check<in T,out R>(T n);
        //public delegate void Print(string s);
        //public delegate void Print<T>(T obj);
        static void Main(string[] args)
        {
            //Console.WriteLine(GetSum(new int[] { 1,2,3,4,5,6}));
            //Console.WriteLine(GetSumOdd(new int[] { 1,2,3,4,5,6}));
            //Console.WriteLine(GetSumElder(new int[] { 1,2,3,4,5,6}));
            //Console.WriteLine(GetSum(new int[] { 1, 2, 3, 4, 5, 6 },IsEven));
            //Console.WriteLine(GetSum(new int[] { 1, 2, 3, 4, 5, 6 },IsOdd));
            //Console.WriteLine(GetSum(new int[] { 1, 2, 3, 4, 5, 6 },IsElder));

            //ANONIMOUS FUNCTION
            //int result = GetSum(new int[] { 1, 2, 3, 4, 5, 6 }, delegate(int n) {
            //    return n % 3 == 0;
            //});
            //LAMBDA EXPRESSION
            //int result = GetSum(new int[] { 1, 2, 3, 4, 5, 6 }, n=>n % 3 == 0);
            //Console.WriteLine(result);

            //Print print = GetFirstLetter;
            //print += GetToUpper;
            //print += delegate (string str)
            //  {
            //      Console.WriteLine(str.ToLower());
            //  };
            //print += s => Console.WriteLine(s.Length);

            //print -= GetToUpper;
            //print -= s => Console.WriteLine(s.Length);
            //print("Cefer");
            //print.Invoke("Cefer");

            #region Action
            //Action<string> printStr = GetFirstLetter;
            //Action<int> printInt = PrintNumber;
            //Action<int, int> sum = (n1, n2) => Console.WriteLine(n1+n2);
            #endregion

            #region Func
            //Func<string, int> check = GetLength;
            //Func<int, bool> check1 = IsEven;
            #endregion

            #region Predicate
            //Predicate<int> predicate = IsOdd;
            //List<int> list = new List<int>();
            //list.Add(1);
            //list.Add(2);
            //list.Add(3);
            //list.Add(4);
            //Console.WriteLine(list.Find(n=>n>=3));
            #endregion

            #region Task
            MyList<int> myList = new MyList<int>();
            myList.Add(1);
            myList.Add(2);
            myList.Add(3);
            myList.Add(4);
            Console.WriteLine(myList.Find(n => n >= 3));
            #endregion
        }

        #region Task
        class MyList<T>
        {
            private T[] arr;

            public MyList()
            {
                arr = new T[0];
            }

            public void Add(T item)
            {
                Array.Resize(ref arr, arr.Length + 1);
                arr[arr.Length - 1] = item;
            }

            public T Find(Predicate<T> callback)
            {
                T result=default;
                foreach (T item in arr)
                {
                    if (callback(item))
                    {
                        result = item;
                        return result;
                    }
                }
                return result;
            }
        }
        #endregion

        #region Delegate
        public static int GetLength(string str)
        {
            return str.Length;
        }

        static void GetFirstLetter(string str)
        {
            Console.WriteLine(str[0]);
        }

        static void PrintNumber(int n)
        {
            Console.WriteLine(n);
        }

        static void GetToUpper(string str)
        {
            Console.WriteLine(str.ToUpper());
        }


        static int GetSum(int[] arr,Predicate<int> callback)
        {
            int result = 0;
            foreach (int item in arr)
            {
                if (callback(item))
                    result += item;
            }
            return result;
        }

        static bool IsEven(int item)
        {
            return item % 2 == 0;
        }

        static bool IsOdd(int item)
        {
            return item % 2 != 0;
        }

        static bool IsElder(int item)
        {
            return item>5;
        }

        #endregion
    }
}
