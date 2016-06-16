using System;

class Solution
{
    public static void Main(string[] args)
    {
        int[][] arr = new int[6][];
        
        for(int arr_i = 0; arr_i < 6; arr_i++){
           var arr_temp = Console.ReadLine().Split(' ');
           arr[arr_i] = Array.ConvertAll(arr_temp,Int32.Parse);
        }
        
        // set the max to the minimum value an hourglass could be
        int maxHourglass = -9 * 7;
        
        for(int row = 0; row < arr.Length - 2; ++row)
        {
            for (int column = 0; column < arr[row].Length - 2; ++column)
            {
                var temp = arr[row][column]     + arr[row][column + 1]     + arr[row][column + 2] +
                                                  arr[row + 1][column + 1] +
                           arr[row + 2][column] + arr[row + 2][column + 1] + arr[row + 2][column + 2];
                
                maxHourglass = Math.Max(temp, maxHourglass);
            }
        }
        
        Console.WriteLine(maxHourglass);
    }
}