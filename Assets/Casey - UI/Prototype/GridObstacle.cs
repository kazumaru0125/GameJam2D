using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GridObstacle : GridObject
{
    // Start is called before the first frame update
    public override bool Push(GridDirection direction)
    {
        switch (direction)
        {
            case GridDirection.UP:
                if (gmCallback.AttemptPush(xCoord, yCoord - 1, GridDirection.UP))
                {
                    gmCallback.SetObjectAtCoordinate(xCoord, yCoord, null);
                    yCoord--;
                    gmCallback.SetObjectAtCoordinate(xCoord, yCoord, this);

                    MoveObject(new Vector3(0, 1, 0));
                    return true;
                }
                else
                    return false;
            case GridDirection.DOWN:
                if (gmCallback.AttemptPush(xCoord, yCoord + 1, GridDirection.UP))
                {
                    gmCallback.SetObjectAtCoordinate(xCoord, yCoord, null);
                    yCoord++;
                    gmCallback.SetObjectAtCoordinate(xCoord, yCoord, this);

                    MoveObject(new Vector3(0, -1, 0));
                    return true;
                }
                else
                    return false;
            case GridDirection.LEFT:
                if (gmCallback.AttemptPush(xCoord - 1, yCoord, GridDirection.UP))
                {
                    gmCallback.SetObjectAtCoordinate(xCoord, yCoord, null);
                    xCoord--;
                    gmCallback.SetObjectAtCoordinate(xCoord, yCoord, this);

                    MoveObject(new Vector3(-1, 0, 0));
                    return true;
                }
                else
                    return false;
            case GridDirection.RIGHT:
                if (gmCallback.AttemptPush(xCoord + 1, yCoord, GridDirection.UP))
                {
                    gmCallback.SetObjectAtCoordinate(xCoord, yCoord, null);
                    xCoord++;
                    gmCallback.SetObjectAtCoordinate(xCoord, yCoord, this);

                    MoveObject(new Vector3(1, 0, 0));
                    return true;
                }
                else
                    return false;
        }
        return false;

        void MoveObject(Vector3 moveVector)
        {
            // DOTweenを使ってオブジェクトをスムーズに移動させる
            transform.DOMove(transform.position + moveVector, .5f);
        }
    }
}
