using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution {
    static void Main(string[] args) {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        var boardSize = Convert.ToInt32(Console.ReadLine());
        var board = new List<string>();
        
        for(int i = 0; i < boardSize; i++){
            board.Add(Console.ReadLine());
        }
        
        Console.WriteLine(GetNextMove(board.ToArray()));
    }
    
    public static string GetNextMove(string[] board) {
        var cells = new List<Cell>();
        
        for (int i = 0; i < board.Count(); i++) {
            for (int j = 0; j < board[i].Length; j++) {
                cells.Add(new Cell {
                    x = j,
                    y = i,
                    Type = board[i][j],
                    LikelihoodOfAHit = board[i][j] == '-' ? 1 : 0
                });
            }
        }
        
        foreach(var cell in cells.Where(x => x.Type == 'h'))
        {
            // get nearby cells and bump up the likelihood of a hit
            var moreHittableCells = cells
                .Where(c => c.Type == '-' && 
                       ((Math.Abs(c.x - cell.x) == 1 && (c.y - cell.y == 0)) ||
                        (c.x - cell.x == 0) && Math.Abs(c.y - cell.y) == 1))
                .Select(y => y);
            
            foreach (var moreHittableCell in moreHittableCells)
            {
                moreHittableCell.LikelihoodOfAHit++;
            }
        }
        
        var nextMoves = cells.Where(x => x.Type == '-').OrderByDescending(x => x.LikelihoodOfAHit).Select(x => x);
        Cell nextMove = null;
        
        if (nextMoves.Where(x => x.LikelihoodOfAHit > 1).Any())
        {
            nextMove = nextMoves.First();
        }
        else
        {
            var random = new Random();
            nextMove = nextMoves.ElementAt(random.Next(0, nextMoves.Count()));
        }
        
        return string.Format("{0} {1}", nextMove.y, nextMove.x);
    }
}

public sealed class Cell {
    public int x { get; set; }
    public int y { get; set; }
    public char Type { get; set; }
    public int LikelihoodOfAHit { get; set; }
}