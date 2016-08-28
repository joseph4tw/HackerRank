using System;
using System.IO;

class Solution {
    private const int maxUpperCaseCharCode = 90;
    
    static void Main(string[] args) {
        var s = Console.ReadLine();
        var words = 1;
        
        for (var i = 0; i < s.Length; ++i)
        {
            if ((int)s[i] <= maxUpperCaseCharCode)
                words++;
        }
        
        Console.WriteLine(words);
    }
}
