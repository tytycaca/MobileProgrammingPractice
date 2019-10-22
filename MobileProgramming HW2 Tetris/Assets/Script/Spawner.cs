using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    private GameObject[] blockPrefabs = new GameObject[7];
    private float timer = 0.0f;

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
    }
	
	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime;
        if (timer > 1.0f)
        {
            spawnBlocks(blockPrefabs[Random.Range(0, 7)], new Vector3(0, 19, 0));
            timer -= 1.0f;
        }
    }
}
