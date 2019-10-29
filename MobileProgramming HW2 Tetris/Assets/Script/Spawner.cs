using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    private GameObject[] blockPrefabs = new GameObject[7];
    private GameObject currentModel;
    private bool insCheck = true;
    private int modelNum;

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
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (insCheck)
        {
            modelNum = Random.Range(0, 7);

            switch (modelNum)
            {
                //if prefab is 'IBlock'
                case (0):
                    spawnBlocks(blockPrefabs[modelNum], new Vector3(6, 20, 0));
                    break;

                //if prefab is 'LeftLblock'
                case (1):
                    spawnBlocks(blockPrefabs[modelNum], new Vector3(5, 19, 0));
                    break;

                //if prefab is 'RightLBlock'
                case (2):
                    spawnBlocks(blockPrefabs[modelNum], new Vector3(7, 19, 0));
                    break;

                //if prefab is 'SBlock'
                case (3):
                    spawnBlocks(blockPrefabs[modelNum], new Vector3(6, 19, 0));
                    break;

                //if prefab is 'ZBlock'
                case (4):
                    spawnBlocks(blockPrefabs[modelNum], new Vector3(6, 19, 0));
                    break;

                //if prefab is 'TBlock'
                case (5):
                    spawnBlocks(blockPrefabs[modelNum], new Vector3(6, 19, 0));
                    break;

                //if prefab is 'SquareBlock'
                case (6):
                    spawnBlocks(blockPrefabs[modelNum], new Vector3(6, 19, 0));
                    break;

                default:
                    break;
            }

            insCheck = false;
        }
    }

    public void setInsCheck(bool tf)
    {
        insCheck = tf;
    }

    private void spawnBlocks(GameObject prefab, Vector3 pos)
    {
        Instantiate(prefab, pos, Quaternion.identity);
    }
}
