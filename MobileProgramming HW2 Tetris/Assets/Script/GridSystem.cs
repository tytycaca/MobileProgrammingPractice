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

    public bool checkMoveGrid(int moveType, GameObject movingPrefab)
    {
        int i;

        // moveDown
        if (moveType == 0)
        {
            for (i = 0; i < 4; i++)
            {
                if (getGrid((int)(movingPrefab.transform.GetChild(i).position.x), (int)(movingPrefab.transform.GetChild(i).position.y - 1)))
                    return false;
            }
        }

        // moveLeft
        else if (moveType == 1)
        {
            for (i = 0; i < 4; i++)
            {
                if (getGrid((int)movingPrefab.transform.GetChild(i).position.x - 1, (int)movingPrefab.transform.GetChild(i).position.y))
                    return false;
            }
        }

        // moveRight
        else if (moveType == 2)
        {
            for (i = 0; i < 4; i++)
            {
                if (getGrid((int)movingPrefab.transform.GetChild(i).position.x + 1, (int)movingPrefab.transform.GetChild(i).position.y))
                    return false;
            }
        }

        return true;
    }
}
