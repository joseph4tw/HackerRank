# Bear and Steady Gene

> A gene is represented as a string of length `N` (where `N` is divisible by 4), composed of the letters `A`, `C`, `G`, and `T`. It is considered to be steady if each of the four letters occurs exactly `N / 4` times. For example, `GACT` and `AAGTGCCT` are both steady genes.

> Bear Limak is a famous biotechnology scientist who specializes in modifying bear DNA to make it steady. Right now, he is examining a gene represented as a string `s`. It is not necessarily steady. Fortunately, Limak can choose one (maybe empty) substring of `s` and replace it with any substring of the same length.

> Modifying a large substring of bear genes can be dangerous. Given a string `s`, can you help Limak find the length of the smallest possible substring that he can replace to make `s` a steady gene?

> Note: A substring of a string `S` is a subsequence made up of zero or more _consecutive_ characters of `S`.

You can find more about the problem [here](https://www.hackerrank.com/challenges/bear-and-steady-gene).

## My Solution

The idea here is to start at one end of the string and work my way backwards collecting the characters within the string. I do this to keep track of how many of each character I have.

I do this until I have found a gene character that has surpassed the max amount allowed for balancing the whole string. I then hold on to the index of the string just before we hit the character that caused the genes to be unbalanced.

I then move forward from the beginning of the string and perform the same process. Once I have found another point of unbalance, I note the amount of characters required to replace a substring of the genes.

Then, I start moving the whole subset forward little by little to see if there is a smaller substring that can be applied.