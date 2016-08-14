using System;
using System.Collections.Generic;
using System.Linq;

class Solution {
    static void Main(string[] args)
    {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        var testCases = int.Parse(Console.ReadLine());
        
        for (int i = 0; i < testCases; ++i)
        {
            var input = Console.ReadLine();
            var pairCount = GetAnagrammaticPairCount(input);
            
            Console.WriteLine(pairCount);
        }
    }
    
    private static int GetAnagrammaticPairCount(string s)
    {
        var totalAnagrammaticPairs = 0;

        for (int buffer = 1; buffer < s.Length; ++buffer)
        {
            for (int index = 0; index < s.Length - (buffer - 1); ++index)
            {
                var subset = s.Substring(index, buffer).ToCharArray();
                Array.Sort(subset);

                for (int subIndex = index + 1; subIndex + (buffer - 1) < s.Length; ++subIndex)
                {
                    var current = s.Substring(subIndex, buffer).ToCharArray();
                    Array.Sort(current);

                    if (subset.SequenceEqual(current))
                    {
                        totalAnagrammaticPairs++;
                    }
                }
            }
        }

        return totalAnagrammaticPairs;
    }
}