using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    private GameObject[] blockPrefabs = new GameObject[7];
    private float timer = 0.0f;
    //private PlayerInput PlayerInput = new PlayerInput();
    private bool insCheck = true;

    public void setInsCheck(bool tf)
    {
        insCheck = tf;
    }

    private void spawnBlocks(GameObject prefab, Vector3 pos)
    {
        Instantiate(prefab, pos, Quaternion.identity);
    }

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

        //spawnBlocks(blockPrefabs[Random.Range(0, 7)], new Vector3(0, 19, 0));

        //PlayerInput = GameObject.FindGameObjectWithTag("BlockPrefabs").GetComponent<PlayerInput>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (insCheck)
        {
            spawnBlocks(blockPrefabs[Random.Range(0, 7)], new Vector3(0, 19, 0)); ;
            insCheck = false;
        }
    }
}
