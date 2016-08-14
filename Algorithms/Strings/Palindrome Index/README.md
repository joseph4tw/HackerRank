# Palindrome Index

> Given a string, `S`, of lowercase letters, determine the index of the character whose removal will make `S` a palindrome. If `S` is already a palindrome or no such character exists, then print `-1`. There will always be a valid solution, and any correct answer is acceptable. For example, if `S = "bcbc"`, we can either remove 'b' at index `0` or 'c' at index `3`.

You can find more about the problem [here](https://www.hackerrank.com/challenges/palindrome-index).

## My Solution

The solution I used was to move forward and backward through the character array and check the characters at each end. I keep moving inward if the characters are the same at the two opposing indexes. If I find a mismatch, I check if removing the character on the left will result in the remaining characters between `begin` and `end` (inclusive) will result in a palindrome. If so, then the index at `begin` is what we need to remove. If not, I check the other way around by removing the `end` index and checking the characters in between is a palindrome. If so, then the index at `end` is what we need to remove. Otherwise, there is no solution to remove a single character to get a palindrome and so we'll return `-1`.