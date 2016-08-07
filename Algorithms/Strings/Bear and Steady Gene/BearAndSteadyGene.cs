using System;
using System.Collections.Generic;
using System.Linq;

class Solution {
    static void Main(string[] args) {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        var lengthInput = Console.ReadLine();

        int length;
        if (int.TryParse(lengthInput, out length) == false)
        {
            throw new FormatException("Length input is not an integer.");
        }

        var genes = Console.ReadLine().Substring(0, length);

        var geneSubstringLength = GetSteadyGeneSubstringLength(length, genes);

        Console.WriteLine(geneSubstringLength);
    }
    
    private static int GetSteadyGeneSubstringLength(int length, string genes)
    {
        var maxHead = length - 1;
        var minTail = 0;
        var maxGeneCount = length / 4;
        var smallestSubstring = int.MaxValue;
        
        var genePool = new Dictionary<char, int>
        {
            { 'A', 0 },
            { 'C', 0 },
            { 'G', 0 },
            { 'T', 0 },
        };
        
        while (maxHead >= 0)
        {
            genePool[genes[maxHead]]++;
            if (!IsValid(genePool, maxGeneCount))
            {
                genePool[genes[maxHead]]--;
                maxHead++;
                break;
            }
            maxHead--;
        }
        
        while (minTail < maxHead && maxHead < length)
        {
            genePool[genes[minTail]]++;
            if (IsValid(genePool, maxGeneCount))
            {
                smallestSubstring = Math.Min(smallestSubstring, maxHead - minTail - 1);
            }
            else
            {
                genePool[genes[minTail]]--;
                minTail--;
                
                genePool[genes[maxHead]]--;
                maxHead++;
            }
            minTail++;
        }
        
        return smallestSubstring == int.MaxValue ? 0 : smallestSubstring;
    }
    
    private static bool IsValid(IDictionary<char, int> genePool, int maxGeneCountAllowed)
    {
        if (genePool.Any(x => x.Value > maxGeneCountAllowed))
        {
            return false;
        }
        
        return true;
    }
}