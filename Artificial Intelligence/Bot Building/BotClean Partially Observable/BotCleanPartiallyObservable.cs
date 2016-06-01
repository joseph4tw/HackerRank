using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

class Solution {
    public const string BoardFileName = "board.txt";
    
    public static void Main(string[] args)
    {
        var temp = Console.ReadLine();
        var position = temp.Split(' ');
        var pos = new int[2];
        var inputBoard = new string[5];
        
        for(int i = 0; i < 5; i++)
        {
            inputBoard[i] = Console.ReadLine();
        }
        
        for(int i = 0; i < 2; i++)
        {
            pos[i] = Convert.ToInt32(position[i]);
        }
        
        var fileBoard = Board.GetBoard(BoardFileName);
        var bot = new Bot(pos[0], pos[1]);
        
        if (fileBoard == null)
        {
            fileBoard = inputBoard;
        }
        else
        {
            fileBoard = Board.GetMergedBoard(fileBoard, inputBoard, bot);
        }
        
        PrintNextMove(bot, fileBoard);
        
        Board.SaveBoard(BoardFileName, fileBoard);
    }
    
    public static void PrintNextMove(Bot bot, string[] board)
    {
        //add logic here
        if (board[bot.Position.Row][bot.Position.Column] == 'd')
        {
            var m = new Move();
            Console.WriteLine(m);
            return;
        }
        
        var dirtyCells = new List<Cell>();
        
        for (int row = 0; row < board.Length; ++row)
        {
            int i = 0;
            while ((i = board[row].IndexOf(CellTypes.Dirty, i)) != -1)
            {
                var column = board[row].IndexOf(CellTypes.Dirty);
                var distanceFromBot = Math.Abs(bot.Position.Row - row) + Math.Abs(bot.Position.Column - column);
                
                dirtyCells.Add(new Cell(row, column, CellTypes.Dirty, distanceFromBot));
                i++;
            }
        }
        
        var closestDirtyCell = dirtyCells.OrderBy(x => x.DistanceFromBot).FirstOrDefault();
        
        if (closestDirtyCell != null)
        {
            Move m;
            
            if (bot.Position.Row == closestDirtyCell.Row)
            {
                if (bot.Position.Column < closestDirtyCell.Column)
                {
                    m = new Move(Direction.Right);
                }
                else
                {
                    m = new Move(Direction.Left);
                }
            }
            else if (bot.Position.Row < closestDirtyCell.Row)
            {
                m = new Move(Direction.Down);
            }
            else
            {
                m = new Move(Direction.Up);
            }

            Console.WriteLine(m);
            return;
        }
        
        // no dirty cell found, so make a guess toward the nearest unkown area
        Console.WriteLine(bot.GetNextBestGuess(board));
    }
}

public static class Board
{
    public static string[] GetBoard(string fileName)
    {
        if (!File.Exists(fileName))
        {
            return null;
        }
        
        return File.ReadAllLines(fileName);
    }
    
    public static string[] GetMergedBoard(string[] fileBoard, string[] inputBoard, Bot bot)
    {
        var surroundingCells = bot.GetSurroundingCells(inputBoard)
                                  .ToList()
                                  .OrderBy(x => x.Row)
                                  .ThenBy(x => x.Column);
        
        foreach (var cell in surroundingCells)
        {
            var sb = new StringBuilder(fileBoard[cell.Row]);
            sb[cell.Column] = cell.Type;
            fileBoard[cell.Row] = sb.ToString();
        }
        
        return fileBoard;
    }
    
    public static void SaveBoard(string fileName, string[] board)
    {
        File.WriteAllLines(fileName, board);
    }
}

public sealed class Cell
{
    public int Row { get; set; }
    public int Column { get; set; }
    public char Type { get; set; }
    public int DistanceFromBot { get; set; }
    
    public Cell(int row, int column, char type, int distanceFromBot)
    {
        Row = row;
        Column = column;
        Type = type;
        DistanceFromBot = distanceFromBot;
    }
}

public static class CellTypes
{
    public const char Clean = '-';
    public const char Dirty = 'd';
    public const char Unknown = 'o';
}

public sealed class Bot
{
    public BotPosition Position { get; set; }
    
    public Bot(int row, int column)
    {
        Position = new BotPosition();
        Position.Row = row;
        Position.Column = column;
    }
    
    public IEnumerable<Cell> GetSurroundingCells(string[] board)
    {
        if (Position == null)
        {
            throw new Exception("The Bot needs a position to get the surrounding cells.");
        }
        
        yield return new Cell(Position.Row, Position.Column, board[Position.Row][Position.Column], 0);
        
        if (Position.Row > 0 && Position.Row <= board.Length)
        {
            // up
            yield return new Cell(Position.Row - 1, Position.Column, board[Position.Row - 1][Position.Column], 1);
            
            if (Position.Column > 0 && Position.Column <= board[0].Length - 1)
            {
                // up-left
                yield return new Cell(Position.Row - 1, Position.Column - 1, board[Position.Row - 1][Position.Column - 1], 2);
            }
            
            if (Position.Column >= 0 && Position.Column < board[0].Length - 1)
            {
                // up-right
                yield return new Cell(Position.Row - 1, Position.Column + 1, board[Position.Row - 1][Position.Column + 1], 2);
            }
        }
        
        if (Position.Row >= 0 && Position.Row < board.Length - 1)
        {
            // down
            yield return new Cell(Position.Row + 1, Position.Column, board[Position.Row + 1][Position.Column], 1);
            
            if (Position.Column > 0 && Position.Column <= board[0].Length - 1)
            {
                // down-left
                yield return new Cell(Position.Row + 1, Position.Column - 1, board[Position.Row + 1][Position.Column - 1], 2);
            }
            
            if (Position.Column >= 0 && Position.Column < board[0].Length - 1)
            {
                // down-right
                yield return new Cell(Position.Row + 1, Position.Column + 1, board[Position.Row + 1][Position.Column + 1], 2);
            }
        }
        
        if (Position.Column > 0 && Position.Column <= board[0].Length - 1)
        {
            // left
            yield return new Cell(Position.Row, Position.Column - 1, board[Position.Row][Position.Column - 1], 1);
        }
        
        if (Position.Column >= 0 && Position.Column < board[0].Length - 1)
        {
            // right
            yield return new Cell(Position.Row, Position.Column + 1, board[Position.Row][Position.Column + 1], 1);
        }
    }
    
    public Move GetNextBestGuess(string[] board)
    {
        if (Position == null)
        {
            throw new Exception("The Bot needs a position to get the next best guess.");
        }
        
        var cells = new List<Cell>();
        
        for (int row = 0; row < board.Length; ++row)
        {
            for (int column = 0; column < board[row].Length; ++column)
            {
                if (board[row][column] == CellTypes.Unknown)
                {
                    var cell = new Cell(row, 
                                        column, 
                                        CellTypes.Unknown, 
                                        (Math.Abs(Position.Row - row) + Math.Abs(Position.Column - column)));
                    
                    cells.Add(cell);
                }
            }
        }
        
        // find the closest unknown area
        var nextCell = cells.OrderBy(x => x.DistanceFromBot).First();
        
        if (nextCell.Row != Position.Row &&
            nextCell.Column != Position.Column)
        {
            if (Math.Abs(nextCell.Row - Position.Row) < Math.Abs(nextCell.Column - Position.Column))
            {
                return new Move(nextCell.Row - Position.Row, 0);
            }
            else
            {
                return new Move(0, nextCell.Column - Position.Column);
            }
        }
        else if (nextCell.Row == Position.Row)
        {
            return new Move(0, nextCell.Column - Position.Column);
        }
        else
        {
            return new Move(nextCell.Row - Position.Row, 0);
        }
    }
}

public sealed class BotPosition
{
    public int Row { get; set; }
    public int Column { get; set; }
}

public sealed class Move
{
    private int MoveVertical { get; set; }
    private int MoveHorizontal { get; set; }
    
    public Move()
    {
        MoveVertical = 0;
        MoveHorizontal = 0;
    }
    
    public Move(int moveVertical, int moveHorizontal)
    {
        MoveVertical = moveVertical;
        MoveHorizontal = moveHorizontal;
    }
    
    public Move(Direction direction)
    {
        switch (direction)
        {
            case Direction.Up:
                MoveVertical = -1;
                MoveHorizontal = 0;
                break;
            
            case Direction.Down:
                MoveVertical = 1;
                MoveHorizontal = 0;
                break;
            
            case Direction.Left:
                MoveVertical = 0;
                MoveHorizontal = -1;
                break;
            
            case Direction.Right:
                MoveVertical = 0;
                MoveHorizontal = 1;
                break;
        }
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

public enum Direction
{
    Up,
    Down,
    Left,
    Right
}