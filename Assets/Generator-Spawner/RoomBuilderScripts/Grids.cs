using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grids
{

    // I got this class from --------> https://www.youtube.com/watch?v=waEsGu--9P8&t=407s&ab_channel=CodeMonkey 


    // from this awesome guy --------> https://www.youtube.com/channel/UCFK6NCbuCIVzA6Yj1G_ZqCg
    private int width;
    private int height;
    private float cellSize;
    private Vector3 originPosition;
    private int[,] gridArray;

    public Grids(int width, int height, float cellSize, Vector3 originPosition)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.originPosition = originPosition;
        gridArray = new int[width, height];

        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.black,9999999f);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.black,9999999f);
            }
        }
        
        Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.black , 9999999f);
        Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.black,9999999f);
    }
    public Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * cellSize + originPosition;
    }
    public void GetXY(Vector3 worldPosition, out int x, out int y)
    {
        x = Mathf.FloorToInt((worldPosition - originPosition).x / cellSize);
        y = Mathf.FloorToInt((worldPosition - originPosition).y / cellSize);

    }
    public void SetValue(int x, int y, int value)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {

            gridArray[x, y] = value;
        }
    }
    public void SetValue(Vector3 worldPosition, int value)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        SetValue(x, y, value);
    }
    public Vector3 GridPos(float x,float y)
    {
        float gridXPos;
        float gridYPos;
        gridXPos = (x * 2 * (cellSize / 2) + cellSize / 2);
        gridYPos = (y * 2 * (cellSize / 2) + cellSize / 2);
        return new Vector3(gridXPos, gridYPos);
    }
    

}