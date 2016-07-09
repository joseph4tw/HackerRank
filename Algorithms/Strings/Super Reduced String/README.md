# Super Reduced String

> Shil has a string, S, consisting of N lowercase English letters. In one operation, he can delete any pair of adjacent letters with same value. For example, string "aabcc" would become either "aab" or "bdd" after 1 operation.

> Shil wants to reduce S as much as possible. To do this, he will repeat the above operation as many times as it can be performed. Help Shil out by finding and printing S's non-reducible form!

Note: If the final string is empty, print Empty String.

You can find more about the problem [here](https://www.hackerrank.com/challenges/reduced-string).

## My Solution

I used a StringBuilder as I looped through the chars of the input and build the final string.