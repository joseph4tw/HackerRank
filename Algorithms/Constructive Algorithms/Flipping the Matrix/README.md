# Flipping the Matrix

> Sean invented a game involving a `2n x 2n` matrix where each cell of the matrix contains an integer. He can reverse any of its rows or columns any number of times, and the goal of the game is to maximize the sum of the elements in the `n x n` submatrix located in the upper-left corner of the `2n x 2n` matrix (i.e., its upper-left quadrant).

> Given the initial configurations for `q` matrices, help Sean reverse the rows and columns of each matrix in the best possible way so that the sum of the elements in the matrix's upper-left quadrant is maximal. For each matrix, print the maximized sum on a new line.

You can find more about the problem [here](https://www.hackerrank.com/challenges/flipping-the-matrix).

## My Solution

If you think about the matrix being split up into 4 quadrants, you can see that each item in the matrix has 3 other corresponding "mirrored" values. In this problem, we only need to focus on getting the max values in the upper-left quadrant. The first thing to do here is to make an algorithm that can determine the maximum integer for each cell within the upper-left quadrant. After that, all you have to do is loop through each item within the upper-left quadrant and determine the max, summing up the value. Then just return that value.

It's important to realize that you don't actually have to flip any row / column in the array since a) the problem is only asking for a sum, and b) similar to a Rubik's cube, all possible max integers from different quadrants can ultimately be placed in the upper-left quadrant with enough rotations (flips). However, we don't *actually* have to rotate anything and we can assume that it's possible to get all possible max integers into the upper-left quadrant.