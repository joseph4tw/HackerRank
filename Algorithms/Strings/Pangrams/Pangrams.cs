using System;
using System.Collections.Generic;
using System.Text;

class Solution {
    static void Main(String[] args) {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        
        var input = Console.ReadLine().ToLower();
        
        const int minAscii = 97;
        const int maxAscii = 122;
        
        const int PangramCharacterLimit = 26;
        var pangramCharacterCount = 0;
        
        var dictionary = new Dictionary<int, int>();
        
        // setup the dictionary with the ASCII values we want to look for
        for (var i = minAscii; i <= maxAscii; ++i)
        {
            dictionary.Add(i, 0);
        }
        
        var asciiBytes = Encoding.ASCII.GetBytes(input);
        
        for (var i = 0; i < asciiBytes.Length; ++i)
        {
            if (dictionary.ContainsKey(asciiBytes[i]) && dictionary[asciiBytes[i]] == 0)
            {
                pangramCharacterCount++;
                dictionary[asciiBytes[i]] = 1;
            }
            
            if (pangramCharacterCount >= PangramCharacterLimit)
            {
                Console.WriteLine("pangram");
                return;
            }
        }
        
        Console.WriteLine("not pangram");
    }
}