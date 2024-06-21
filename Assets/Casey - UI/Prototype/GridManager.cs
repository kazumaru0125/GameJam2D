using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    private GridObject[] grid;
    [SerializeField] private int height;
    [SerializeField] private int length;

    void Awake()
    {
        grid = new GridObject[height * length];

        for (int i = 0; i < height * length; i++)
            grid[i] = null;
    }

    public bool AttemptPush(int x, int y, GridObject.GridDirection direction)
    {
        Debug.Log("Try to push object at " + x.ToString() + ", " + y.ToString());
        if (x + (y * height) < height * length)
        {
            if (grid[x + (y * height)] == null)
                return true;
            else
                return grid[x + (y * height)].Push(direction);
        }
        else return false;
    }    
    public GridObject GetObjectAtCoordinate(int x, int y)
    {

        if (x + (y * height) < height * length)
            return grid[x + (y * height)];
        else
            return null;
    }

    public void SetObjectAtCoordinate(int x, int y, GridObject newObject)
    {
        Debug.Log("So coord = " + (x + (y * height)).ToString());
        if(x + (y*height) < height * length)
            grid[x + (y * height)] = newObject;
    }

}
