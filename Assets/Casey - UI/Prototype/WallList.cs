using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



public class WallList : MonoBehaviour
{
    [Serializable]
    public struct Coordinates
    {
        [SerializeField] public int x;
        [SerializeField] public int y;
    }

    public UnityEngine.Object wallPrefab;
    [SerializeField] GridManager gmCallback;
    [SerializeField] private Coordinates[] positions;

    void Awake()
    {
       // wallPrefab = Resources.Load("Assets/Casey - UI/Prototype/Wall Internal.prefab");
    }
    // Start is called before the first frame update
    void Start()
    {
      for(int i = 0; i < positions.Length; i++)
        {
            int xPos = (positions[i]).x;
            int yPos = (positions[i]).y;

            GameObject newWall = Instantiate(wallPrefab) as GameObject;
            Wall wallComponent = newWall.GetComponent<Wall>();

            wallComponent.xCoord = xPos;
            wallComponent.yCoord = yPos;
            wallComponent.gmCallback = this.gmCallback;

            gmCallback.SetObjectAtCoordinate(xPos, yPos, wallComponent);


        }
    }

}
