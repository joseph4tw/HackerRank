using System;

class Solution {
    static void Main(String[] args) {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        var queries = int.Parse(Console.ReadLine());

        for (var i = 0; i < queries; ++i)
        {
            var n = int.Parse(Console.ReadLine());
            var array = new int[n * 2, n * 2];

            for (var row = 0; row < n * 2; ++row)
            {
                var columnValues = Console.ReadLine().Split(' ');
                var columns = columnValues.Length;
                var column = 0;
                foreach (var val in columnValues)
                {
                    array[row, column++] = int.Parse(val);
                }
            }

            var answer = CalculateMaxSubArray(array, n);
            Console.WriteLine(answer);
        }
    }
    
    public static int CalculateMaxSubArray(int[,] array, int size)
    {
        var sum = 0;

        for (var row = 0; row < size; ++row)
        {
            for (var column = 0; column < size; ++column)
            {
                sum += CalculateMaxCell(array, row, column);
            }
        }

        return sum;
    }

    private static int CalculateMaxCell(int[,] array, int row, int column)
    {
        var value0 = array[row, column];
        var value1 = array[array.GetLength(0) - 1 - row, column];
        var value2 = array[row, array.GetLength(0) - 1 - column];
        var value3 = array[array.GetLength(0) - 1 - row, array.GetLength(0) - 1 - column];

        var max = Math.Max(Math.Max(value0, value1), Math.Max(value2, value3));
        return max;
    }
}