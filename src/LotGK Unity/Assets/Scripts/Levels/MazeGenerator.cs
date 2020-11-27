using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Flags]
public enum MazeWall
{
    //This binary number stores a value to determine the layout of each cell of the maze
    //1 means that there is a wall, while 0 means there is an empty space.
    // 0000 -> NO WALLS
    // 1111 -> LEFT,RIGHT,UP,DOWN
    LEFT = 1, // 0001
    RIGHT = 2, // 0010
    UP = 4, // 0100
    DOWN = 8, // 1000

    VISITED = 128, // 1000 0000
}

public struct Position
{
    public int X;
    public int Y;
}

public struct NextCell
{
    public Position Position;
    public MazeWall CommonWall;
}

public static class MazeGenerator
{

    private static MazeWall GetOppositeWall(MazeWall wall)
    {
        switch (wall)
        {
            case MazeWall.RIGHT: return MazeWall.LEFT;
            case MazeWall.LEFT: return MazeWall.RIGHT;
            case MazeWall.UP: return MazeWall.DOWN;
            case MazeWall.DOWN: return MazeWall.UP;
            default: return MazeWall.LEFT;
        }
    }

    private static MazeWall[,] ApplyRecursiveBacktracker(MazeWall[,] maze, int width, int height)
    {
        var rng = new System.Random();
        var positionStack = new Stack<Position>();
        var position = new Position { X = rng.Next(0, width), Y = rng.Next(0, height) };

        maze[position.X, position.Y] |= MazeWall.VISITED;
        positionStack.Push(position);

        //Run through each of the 10 cells & set the walls
        while (positionStack.Count > 0)
        {
            var current = positionStack.Pop();
            var neighbours = UnvisitedCells(current, maze, width, height);

            if (neighbours.Count > 0)
            {
                positionStack.Push(current);

                var randIndex = rng.Next(0, neighbours.Count);
                var randomNextCell = neighbours[randIndex];

                var nPosition = randomNextCell.Position;
                maze[current.X, current.Y] &= ~randomNextCell.CommonWall;
                maze[nPosition.X, nPosition.Y] &= ~GetOppositeWall(randomNextCell.CommonWall);
                maze[nPosition.X, nPosition.Y] |= MazeWall.VISITED;

                positionStack.Push(nPosition);
            }
        }

        return maze;
    }

    //Check the neighbouring cells, if the cell is unvisited, get rid of the wall between them to ensure the maze can access every cell.
    private static List<NextCell> UnvisitedCells(Position p, MazeWall[,] maze, int width, int height)
    {
        var list = new List<NextCell>();

        if (p.X > 0) {
            if (!maze[p.X - 1, p.Y].HasFlag(MazeWall.VISITED)) //If the left cell is unvisited, make it a neighbour of this cell
            {
                list.Add(new NextCell {
                    Position = new Position
                    {
                        X = p.X - 1,
                        Y = p.Y
                    },
                    CommonWall = MazeWall.LEFT
                });
            }
        }

        if (p.Y > 0) {
            if (!maze[p.X, p.Y - 1].HasFlag(MazeWall.VISITED)) //If the lower cell is unvisited, make it a neighbour of this cell
            {
                list.Add(new NextCell {
                    Position = new Position
                    {
                        X = p.X,
                        Y = p.Y - 1
                    },
                    CommonWall = MazeWall.DOWN
                });
            }
        }

        if (p.Y < height - 1) {
            if (!maze[p.X, p.Y + 1].HasFlag(MazeWall.VISITED)) //If the upper cell is unvisited, make it a neighbour of this cell
            {
                list.Add(new NextCell {
                    Position = new Position
                    {
                        X = p.X,
                        Y = p.Y + 1
                    },
                    CommonWall = MazeWall.UP
                });
            }
        }

        if (p.X < width - 1) {
            if (!maze[p.X + 1, p.Y].HasFlag(MazeWall.VISITED)) //If the right cell is unvisited, make it a neighbour of this cell
            {
                list.Add(new NextCell { 
                    Position = new Position {
                        X = p.X + 1,
                        Y = p.Y
                    },
                    CommonWall = MazeWall.RIGHT
                });
            }
        }

        return list;
    }

    //Initialize each cell with all four walls, then return to apply the algorithm, returning the maze and its x/y size.
    public static MazeWall[,] Generate(int width, int height)
    {
        MazeWall[,] maze = new MazeWall[width, height];
        MazeWall initial = MazeWall.RIGHT | MazeWall.LEFT | MazeWall.UP | MazeWall.DOWN;
        for (int i = 0; i < width; ++i)
        {
            for (int j = 0; j < height; ++j)
            {
                maze[i, j] = initial;  // 1111
            }
        }
        
        return ApplyRecursiveBacktracker(maze, width, height);
    }
}
