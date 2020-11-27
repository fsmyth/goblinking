using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeRenderer : MonoBehaviour
{
    //Width and height of maze (In number of cells)
    public int width = 10;

    public int height = 10;

    private float size = 1f;

    public Transform wallPrefab = null;
    void Start()
    {
        var maze = MazeGenerator.Generate(width, height);
        MakeMaze(maze);
    }

    //Instantiate the wall prefabs
    private void MakeMaze(MazeWall[,] maze)
    {
        //For each row, count through each cell of the column and instantiate the walls where necessary
        for (int i = 0; i < width; ++i)
        {
            for (int j = 0; j < height; ++j)
            {
                var cell = maze[i, j];
                var position = new Vector3(-width / 2 + i, 0, -height / 2 + j);

                if (cell.HasFlag(MazeWall.UP))  //If the "up" wall is flagged, instantiate the wall to reflect this.
                {
                    var topWall = Instantiate(wallPrefab, transform) as Transform;
                    topWall.position = position + new Vector3(0, 0, size / 2);
                    topWall.localScale = new Vector3(size, topWall.localScale.y, topWall.localScale.z);
                }

                if (cell.HasFlag(MazeWall.LEFT))  //If the "left" wall is flagged, instantiate the wall to reflect this.
                {
                    var leftWall = Instantiate(wallPrefab, transform) as Transform;
                    leftWall.position = position + new Vector3(-size / 2, 0, 0);
                    leftWall.localScale = new Vector3(size, leftWall.localScale.y, leftWall.localScale.z);
                    leftWall.eulerAngles = new Vector3(0, 90, 0);
                }

                if (i == width - 1) //If it is the last cell on the right, give it a right wall. 
                                    // Right walls are only instantiated on the last cells to prevent doubling up on left walls with their neighbouring cells.
                {
                    if (cell.HasFlag(MazeWall.RIGHT))  //If the "right" wall is flagged, instantiate the wall to reflect this.
                    {
                        var rightWall = Instantiate(wallPrefab, transform) as Transform;
                        rightWall.position = position + new Vector3(+size / 2, 0, 0);
                        rightWall.localScale = new Vector3(size, rightWall.localScale.y, rightWall.localScale.z);
                        rightWall.eulerAngles = new Vector3(0, 90, 0);
                    }
                }

                if (j == 0) //If it is the last cell on the bottom, give it a bottom wall. 
                                    // These walls are also only instantiated on the last cells to prevent doubling up on top walls with their neighbouring cells.
                {
                    if (cell.HasFlag(MazeWall.DOWN))  //If the "down" wall is flagged, instantiate the wall to reflect this.
                    {
                        var bottomWall = Instantiate(wallPrefab, transform) as Transform;
                        bottomWall.position = position + new Vector3(0, 0, -size / 2);
                        bottomWall.localScale = new Vector3(size, bottomWall.localScale.y, bottomWall.localScale.z);
                    }
                }
            }

        }

    }
}
