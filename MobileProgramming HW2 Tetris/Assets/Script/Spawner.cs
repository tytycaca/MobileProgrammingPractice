using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    private GameObject[] blockPrefabs = new GameObject[7];
    private GameObject[] samplePrefabs = new GameObject[7];

    private bool insCheck = true;
    private int modelNum;
    private int nextModelNum;

    // Use this for initialization
    void Start ()
    {
        blockPrefabs[0] = Resources.Load("Prefab/IBlock") as GameObject;
        blockPrefabs[1] = Resources.Load("Prefab/LeftLBlock") as GameObject;
        blockPrefabs[2] = Resources.Load("Prefab/RightLBlock") as GameObject;
        blockPrefabs[3] = Resources.Load("Prefab/SBlock") as GameObject;
        blockPrefabs[4] = Resources.Load("Prefab/ZBlock") as GameObject;
        blockPrefabs[5] = Resources.Load("Prefab/TBlock") as GameObject;
        blockPrefabs[6] = Resources.Load("Prefab/SquareBlock") as GameObject;

        samplePrefabs[0] = Resources.Load("Sample/IBlock") as GameObject;
        samplePrefabs[1] = Resources.Load("Sample/LeftLBlock") as GameObject;
        samplePrefabs[2] = Resources.Load("Sample/RightLBlock") as GameObject;
        samplePrefabs[3] = Resources.Load("Sample/SBlock") as GameObject;
        samplePrefabs[4] = Resources.Load("Sample/ZBlock") as GameObject;
        samplePrefabs[5] = Resources.Load("Sample/TBlock") as GameObject;
        samplePrefabs[6] = Resources.Load("Sample/SquareBlock") as GameObject;

        nextModelNum = -1;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (insCheck)
        {
            spawn();

            insCheck = false;
        }
    }

    public int getModelNum()
    {
        return modelNum;
    }

    public void setInsCheck(bool tf)
    {
        insCheck = tf;
    }

    private void spawnBlocks(GameObject prefab, Vector3 pos)
    {
        GameObject newObj = Instantiate(prefab);
        newObj.transform.position = pos;
    }

    private void spawn()
    {
        if (nextModelNum == -1)
            modelNum = Random.Range(0, 7);
        else
        {
            modelNum = nextModelNum;
            Destroy(GameObject.FindGameObjectWithTag("SamplePrefabs").gameObject);
        }

        switch (modelNum)
        {
            //if prefab is 'IBlock'
            case (0):
                spawnBlocks(blockPrefabs[modelNum], new Vector3(6, 20, 0));
                break;

            //if prefab is 'LeftLblock'
            case (1):
                spawnBlocks(blockPrefabs[modelNum], new Vector3(5, 20, 0));
                break;

            //if prefab is 'RightLBlock'
            case (2):
                spawnBlocks(blockPrefabs[modelNum], new Vector3(6, 20, 0));
                break;

            //if prefab is 'SBlock'
            case (3):
                spawnBlocks(blockPrefabs[modelNum], new Vector3(6, 20, 0));
                break;

            //if prefab is 'ZBlock'
            case (4):
                spawnBlocks(blockPrefabs[modelNum], new Vector3(6, 20, 0));
                break;

            //if prefab is 'TBlock'
            case (5):
                spawnBlocks(blockPrefabs[modelNum], new Vector3(6, 19, 0));
                break;

            //if prefab is 'SquareBlock'
            case (6):
                spawnBlocks(blockPrefabs[modelNum], new Vector3(5, 19, 0));
                break;

            default:
                break;
        }

        nextModelNum = Random.Range(0, 7);
        spawnBlocks(samplePrefabs[nextModelNum], new Vector3(15, 12, 0));
        samplePrefabs[nextModelNum].transform.tag = "SamplePrefabs";
    }
}
