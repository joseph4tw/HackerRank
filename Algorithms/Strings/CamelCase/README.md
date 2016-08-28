# CamelCase

> Alice wrote a sequence of words in CamelCase as a string of letters, `s`, having the following properties:

> It is a concatenation of one or more words consisting of English letters.

> All letters in the first word are lowercase.

> For each of the subsequent words, the first letter is uppercase and rest of the letters are lowercase.

> Given `s`, print the number of words in  on a new line.

You can find more about the problem [here](https://www.hackerrank.com/challenges/camelcase).

## My Solution

Very straightforward. Convert each character to its ASCII character code and see if it is within a specific range.