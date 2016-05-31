using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution {
    public static void next_move(int posr, int posc, string[] board)
    {
        //add logic here
        if (board[posr][posc] == 'd')
        {
            Console.WriteLine(new Move());
            return;
        }

        var dirtyCells = new List<DirtyCell>();

        for (int row = 0; row < board.Length; ++row)
        {
            int i = 0;
            while ((i = board[row].IndexOf('d', i)) != -1)
            {
                var column = board[row].IndexOf('d');
                var distanceFromBot = Math.Abs(posr - row) + Math.Abs(posc - column);

                var dirtyCell = new DirtyCell();
                dirtyCell.Row = row;
                dirtyCell.Column = column;
                dirtyCell.DistanceFromBot = distanceFromBot;

                dirtyCells.Add(dirtyCell);
                
                i++;
            }
        }

        var closestDirtyCell = dirtyCells.OrderBy(x => x.DistanceFromBot).First();
        Move m;
        
        if (posr == closestDirtyCell.Row)
        {
            if (posc < closestDirtyCell.Column)
            {
                m = new Move(0, 1);
            }
            else
            {
                m = new Move(0, -1);
            }
        }
        else if (posr < closestDirtyCell.Row)
        {
            m = new Move(1, 0);
        }
        else
        {
            m = new Move(-1, 0);
        }

        Console.WriteLine(m);
        return;
    }

    public static void Main(string[] args)
    {
        string temp = Console.ReadLine();
        string[] position = temp.Split(' ');
        int[] pos = new int[2];
        string[] board = new string[5];
        for(int i=0;i<5;i++)
        {
            board[i] = Console.ReadLine();
        }
        for(int i=0;i<2;i++) pos[i] = Convert.ToInt32(position[i]);
        next_move(pos[0], pos[1], board);
    }
}

public sealed class DirtyCell
{
    public int Row { get; set; }
    public int Column { get; set; }
    public int DistanceFromBot { get; set; }
}

public sealed class Move
{
    public int MoveVertical { get; set; }
    public int MoveHorizontal { get; set; }
    
    public Move()
    {
        MoveVertical = 0;
        MoveHorizontal = 0;
    }
    
    public Move(int row, int column)
    {
        MoveVertical = row;
        MoveHorizontal = column;
    }
    
    public override string ToString()
    {
        if (MoveVertical < 0)
        {
            return "UP";
        }
        else if (MoveVertical > 0)
        {
            return "DOWN";
        }
        else if (MoveHorizontal > 0)
        {
            return "RIGHT";
        }
        else if (MoveHorizontal < 0)
        {
            return "LEFT";
        }
        else
        {
            return "CLEAN";
        }
    }
}