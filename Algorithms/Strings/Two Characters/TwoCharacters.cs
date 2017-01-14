using System;
using System.Text;

class Solution {

    static void Main(string[] args)
    {
        int len = Convert.ToInt32(Console.ReadLine());
        string s = Console.ReadLine();
        
        int max = 0;
        var distinctLetters = new int[26];
        
        for (var i = 0; i < len; ++i)
        {
            distinctLetters[s[i] - 'a'] = 1;
        }
        
        for (var i = 0; i < distinctLetters.Length; ++i)
        {
            if (distinctLetters[i] == 0) continue;
            
            for (var j = i + 1; j < distinctLetters.Length; ++j)
            {
                if (distinctLetters[j] == 0) continue;
                
                var substring = GetSubstring(s, len, (char)(i + 'a'), (char)(j + 'a'));
                
                if (IsSubstringValid(substring))
                {
                    max = Math.Max(substring.Length, max);
                }
            }
        }
        
        Console.WriteLine(max);
    }
    
    private static bool IsSubstringValid(string substring)
    {
        if (substring.Length == 1)
            return false;
        
        for (var i = 1; i < substring.Length; ++i)
        {
            if (substring[i] == substring[i - 1])
                return false;
        }
        
        return true;
    }
    
    private static string GetSubstring(string s, int len, char c1, char c2)
    {
        var substring = new StringBuilder();
        
        for(var i = 0; i < len; ++i)
        {
            if (s[i] == c1 || s[i] == c2)
            {
                substring.Append(s[i]);
            }
        }
        
        return substring.ToString();
    }
}
