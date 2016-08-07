using System;
using System.Text;

class Solution {
    static void Main(string[] args) {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        var input = Console.ReadLine();
        
        var output = new StringBuilder();

        for (var i = 0; i < input.Length; ++i)
        {
            if (output.Length > 0 && input[i] == output[output.Length - 1])
            {
                output.Remove(output.Length - 1, 1);
            }
            else
            {
                output.Append(input[i]);
            }
        }

        if (output.Length == 0)
        {
            output.Append("Empty String");
        }
        
        Console.WriteLine(output.ToString());
    }
}