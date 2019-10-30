using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem : MonoBehaviour
{
    private bool[,] grid = new bool[12, 22];

    // Use this for initialization
    void Start ()
    {
        initializeGrid();

        for (int i = 0; i < 12; i++)
        {
            grid[i, 0] = true;
            grid[i, 21] = true;
        }

        for (int i = 0; i < 22; i++)
        {
            grid[0, i] = true;
            grid[11, i] = true;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public bool getGrid(int i, int j)
    {
        return grid[i, j];
    }

    public void setGrid(int i, int j, bool tf)
    {
        grid[i, j] = tf;
    }

    public void initializeGrid()
    {
        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 22; j++)
            {
                grid[i, j] = false;
            }
        }
    }

    public bool checkMoveGrid(int moveType, Transform pTransform)
    {
        int i;
        int cnt = 0;

        // moveDown
        if (moveType == 0)
        {
            cnt = 0;

            for (i = 0; i < 4; i++)
            {
                //Debug.Log(pTransform.GetChild(i).position.y);
                if (getGrid((int)(pTransform.GetChild(i).position.x), (int)(pTransform.GetChild(i).position.y - 1)))
                    cnt++;
            }

            if (cnt > 0)
                return false;
            else
                return true;
        }

        // moveLeft
        else if (moveType == 1)
        {
            cnt = 0;

            for (i = 0; i < 4; i++)
            {
                if (getGrid((int)pTransform.GetChild(i).position.x - 1, (int)pTransform.GetChild(i).position.y))
                {
                    cnt++;
                    Debug.Log(i);
                }
            }

            Debug.Log(cnt);

            if (cnt > 0)
                return false;
            else
                return true;
        }

        // moveRight
        else if (moveType == 2)
        {
            cnt = 0;

            for (i = 0; i < 4; i++)
            {
                if (getGrid((int)pTransform.GetChild(i).position.x + 1, (int)pTransform.GetChild(i).position.y))
                    cnt++;
            }

            if (cnt > 0)
                return false;
            else
                return true;
        }

        return true;
    }
}
