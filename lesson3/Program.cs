using System;

namespace lesson3
{
    class Program
    {
        static void Main()
        {
            ShowArrayDiagonal();
            ShowPhoneBook();
            ShowReverse("Hello");
            ShowSeaBattleField();
            ShowMaxStringCoincidence("aabbbdddss", "ssbbbaa");
        }

        static void ShowArrayDiagonal()
        {
            var array = GetDoubleArray(size: 4, new int[] { 0, 1 });
            RenderArray(array);
            RenderArrayDiagonal(array);
        }

        static T[,] GetDoubleArray<T>(int size, T[] defaultValues)
        {
            Random random = new Random();

            T[,] result = new T[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    result[i, j] = defaultValues[random.Next(0, defaultValues.Length)];
                }
            }
            return result;
        }

        static void RenderArray<T>(T[,] array)
        {
            (int sizeX, int sizeY) = GetRenderDimensions(array);

            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    Console.Write($"{array[i, j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void RenderArrayDiagonal(int [,] array)
        {
            (int sizeX, int sizeY) = GetRenderDimensions(array);
            if (sizeX == sizeY)
            {
                for (int i = 0; i < sizeX; i++)
                {
                    Console.Write($"{array[i, i]} ");
                }
                Console.WriteLine();
            }
        }

        static void ShowPhoneBook()
        {
            string[,] book =
            {
                {"Вася", "123-45" },
                {"Петя", "234-56" },
                {"Юра",  "345-67" },
                {"Маша", "abc@abc.abc" },
                {"Таня", "xyz@xyz.xyz" }
            };

            (int sizeX, _) = GetRenderDimensions(book);
            for (int i = 0; i < sizeX; i++)
            {
                Console.WriteLine($"имя {book[i, 0], 7} тел/email {book[i, 1], -20}");
            }
        }

        static void ShowReverse(string str) {
            var arr = str.ToCharArray();
            Array.Reverse(arr);
            Console.WriteLine(arr);
        }

        static void ShowSeaBattleField()
        {
            var field = GetDoubleArray(size: 10, new char[] { 'X', 'O' });
            RenderArray(field);
        }

        static void ShowMaxStringCoincidence(string a, string b)
        {
            Console.WriteLine(GetMaxStringCoincidence(a, b));
        }

        static string GetMaxStringCoincidence(string a, string b)
        {
            string source = a;
            string sample = b;

            if(a.Length < b.Length)
            {
                source = b;
                sample = a;
            }

            int delta = source.Length - b.Length;
            
            int maxEqualCounter = 0;
            int index = 0;

            for (int i = 0; i < delta + 1; i++)
            {
                string sourcePart = source[i..];
                
                int equalCounter = 0;
                for(int j = 0; j < b.Length; j++)
                {
                    if(sourcePart[j] == sample[j])
                    {
                        equalCounter++;
                    }
                    else
                    {
                        if(equalCounter > maxEqualCounter)
                        {
                            maxEqualCounter = equalCounter;
                            index = j + i - equalCounter;

                            equalCounter = 0;
                        }
                    }
                }
            }

            return source.Substring(index, maxEqualCounter);
        }

        static (int x, int y) GetRenderDimensions<T>(T [,] array) => (x: array.GetUpperBound(0), y: array.GetUpperBound(1)); 
    }   
}
