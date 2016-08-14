# Sherlock and Anagrams

> Given a string `S`, find the number of "[unordered anagrammatic pairs](http://en.wikipedia.org/wiki/Unordered_pair)" of substrings.

You can find more about the problem [here](https://www.hackerrank.com/challenges/sherlock-and-anagrams).

## My Solution

In this solution, I walk through the string's substrings with an increasing buffer size in each iteration. While I have a set `buffer` size, I grab the first substring starting at index 0 with a length of `buffer`. I then go through each subsequent substring of the same size and see if there is a match. If so, I count it towards the pair count.

I realize that this is not the most efficient way to do this, but this is how I came up with the solution with doing no research on string algorithms I wasn't familiar with. I was hoping to use Suffix Trees for this to make it more efficient, but couldn't find a way to do so.