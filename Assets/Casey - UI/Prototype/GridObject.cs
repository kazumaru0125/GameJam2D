using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridObject : MonoBehaviour
{
    public enum GridDirection
    { UP, DOWN, RIGHT, LEFT };    

    public int xCoord;
    public int yCoord;
    public GridManager gmCallback;

    // Start is called before the first frame update
    void Start()
    {
        gmCallback.SetObjectAtCoordinate(xCoord, yCoord, this);   
    }

    public virtual bool Push(GridDirection direction) { return false; }

}
