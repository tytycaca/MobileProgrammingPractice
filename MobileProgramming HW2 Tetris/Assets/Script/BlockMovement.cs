using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMovement : MonoBehaviour
{
    private float timer = 0.0f;
    private float z = 0.0f;
    private float defaultMovementTimer = 0.0f;

    private Spawner m_Spawner = new Spawner();
    private GridSystem m_GridSystem = new GridSystem();
    private GameObject movingPrefab;

    public void moveDown()
    {
        if(m_GridSystem.checkMoveGrid(0, movingPrefab))
        {
            transform.position += Vector3.down;
        }

        else
        {
            transform.tag = "StopBlock";
            
            for (int i = 0; i < 4; i++)
            {
                transform.GetChild(i).tag = "StopBlock";
                m_GridSystem.setGrid((int)transform.GetChild(i).position.x, (int)transform.GetChild(i).position.y, true);
                m_Spawner.setInsCheck(true);
                GetComponent<BlockMovement>().enabled = false;
            }
        }
    }

    private void moveLeft ()
    {
        if (m_GridSystem.checkMoveGrid(1, movingPrefab))
            transform.position += Vector3.left;
    }

    private void moveRight ()
    {
        if (m_GridSystem.checkMoveGrid(2, movingPrefab))
            transform.position += Vector3.right;
    }

    private void turnCCW()
    {
        z += 90.0f;
        if (z == 360.0f)
            z = 0.0f;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, z);
    }

    // Use this for initialization
    void Start ()
    {
        m_Spawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>();
        m_GridSystem = GameObject.FindGameObjectWithTag("GridSystem").GetComponent<GridSystem>();
        movingPrefab = GameObject.FindGameObjectWithTag("BlockPrefabs");
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            timer += Time.deltaTime;
            if (timer > 0.1f && transform.tag != "StopBlock")
            {
                moveDown();
                timer = 0.0f;
            }
        }

        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            timer += Time.deltaTime;
            if (timer > 0.1f)
            {
                moveLeft();
                timer = 0.0f;
            }
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            timer += Time.deltaTime;
            if (timer > 0.1f)
            {
                moveRight();
                timer = 0.0f;
            }
        }

        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            turnCCW();
        }

        defaultMovementTimer += Time.deltaTime;
        if (defaultMovementTimer > 1.0)
        {
            moveDown();
            defaultMovementTimer = 0.0f;
        }
    }
}
