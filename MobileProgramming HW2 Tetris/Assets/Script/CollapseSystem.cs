using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollapseSystem : MonoBehaviour
{
    private GridSystem m_GridSystem = new GridSystem();
    private GameObject StopContainer;
    private int length;

    // Use this for initialization
    void Start ()
    {
        m_GridSystem = GameObject.FindGameObjectWithTag("GridSystem").GetComponent<GridSystem>();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void collapseSequence()
    {
        doCollapse(getCollapseGridY());
    }

    private bool[] getCollapseGridY()
    {
        bool[] collapseGridY = new bool[22];

        for (int i = 0; i < 22; i++)
            collapseGridY[i] = false;

        int internalCnt = 0;

        for(int i = 1; i < 21; i++)
        {
            internalCnt = 0;

            for (int j = 1; j < 11; j++)
            {
                if (m_GridSystem.getGrid(j, i))
                    internalCnt++;
            }
            if (internalCnt == 10)
                collapseGridY[i] = true;
        }

        return collapseGridY;
    }

    private void doCollapse(bool[] collapseGridY)
    {
        StopContainer = GameObject.FindGameObjectWithTag("StopContainer");
        length = StopContainer.transform.childCount;
        for (int i = 1; i < 21; i++)
            Debug.Log(collapseGridY[i]);
        for (int i = 1; i < 21; i++)
        {
            if(collapseGridY[i])
            {
                Debug.Log(i);
                for (int j = 0; j < length; j++)
                {
                    if(StopContainer.transform.GetChild(j).position.y == i)
                    {
                        Destroy(StopContainer.transform.GetChild(j).gameObject);
                    }
                }

                for(int j = 1; j < 11; j++)
                {
                    m_GridSystem.setGrid(j, i, false);
                }

                for (int j = 1; j < length; j++)
                {
                    if (StopContainer.transform.GetChild(j).position.y > i)
                    {
                        StopContainer.transform.GetChild(j).position += Vector3.down;
                    }
                }

                for (int j = i + 1; j < 21; j++)
                {
                    for(int k = 1; k < 11; k++)
                    {
                        m_GridSystem.setGrid(k, j, m_GridSystem.getGrid(k, j + 1));
                    }
                }
            }
        }
    }
}
