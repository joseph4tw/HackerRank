using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution {
    static void Main(String[] args) {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        var testCases = Convert.ToInt32(Console.ReadLine());
        
        for (int i = 0; i < testCases; ++i)
        {
            var arraySize = Convert.ToInt32(Console.ReadLine());
            var array = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
            
            var maxContiguousSubarray = Subarray.GetMaxSubarray(array, true);
            var maxNonContiguousSubarray = Subarray.GetMaxSubarray(array, false);
            
            Console.WriteLine(string.Format("{0} {1}", maxContiguousSubarray, maxNonContiguousSubarray));
        }
    }
}

public static class Subarray
{
    public static int GetMaxSubarray(int[] array, bool contiguous)
    {
        if (contiguous)
        {
            return GetMaxContiguousSubarray(array);
        }
        
        return GetMaxNonContiguousSubarray(array);
    }
    
    private static int GetMaxContiguousSubarray(int[] array)
    {
        var largestMaxSoFar = array[0];
        if (array.Any(x => x > 0))
        {
            var sum = array.Aggregate((currentSum, next) =>
                {
                    largestMaxSoFar = Math.Max(next, largestMaxSoFar + next);
                    currentSum = Math.Max(currentSum, largestMaxSoFar);
                    return currentSum;
                });

            return sum;
        }
        else
        {
            return array.Max();
        }
    }
    
    private static int GetMaxNonContiguousSubarray(int[] array)
    {
        var positiveInts = array.Where(x => x > 0);
        
        if (positiveInts.Any())
        {
            return positiveInts.Sum();
        }
        
        return array.Max();
    }
}