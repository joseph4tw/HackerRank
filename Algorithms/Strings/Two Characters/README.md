# Two Characters

> String t always consists of two distinct alternating characters. For example, if string t's two distinct characters are x and y, then t could be xyxyx or yxyxy but not xxyy or xyyx.

> You can convert some string s to string t by deleting characters from s. When you delete a character from s, you must delete all occurrences of it in s. For example, if s = abaacdabd and you delete the character a, then the string becomes bcdbd.

> Given s, convert it to the longest possible string t. Then print the length of string t on a new line; if no string t can be formed from , print 0 instead.

You can find more about the problem [here](https://www.hackerrank.com/challenges/two-characters).

## My Solution

I'm sure there's a better solution out there, but what I did for this was I created a distinct set of letters to pair up. Then I would take a pair of characters and build a substring with it. After that, I would validate it, and then take the length of that substring. If the length was greater than the current max, I overwrite the max with the new value.