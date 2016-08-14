using System;

class Solution {
    static void Main(string[] args) {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        var testCases = Convert.ToInt16(Console.ReadLine());
        
        while (testCases-- > 0)
        {
            var testCase = Console.ReadLine();
            Console.WriteLine(getIndexToRemove(testCase.ToCharArray()));
        }
    }
    
    private static int getIndexToRemove(char[] s)
    {
        var begin = 0;
        var end = s.Length - 1;
        
        while (begin < end)
        {
            if (s[begin] != s[end])
            {
                if (isPalindrome(s, begin + 1, end))
                    return begin;
                
                if (isPalindrome(s, begin, end - 1))
                    return end;
        		
        		return -1;
            }
            
            begin++;
            end--;
        }
        
        return -1;
    }
    
    private static bool isPalindrome(char[] s, int startIndex, int endIndex)
    {
        var begin = startIndex;
        var end = endIndex;
        
        while (begin < end)
            if (s[begin++] != s[end--]) return false;
        
        return true;
    }
}