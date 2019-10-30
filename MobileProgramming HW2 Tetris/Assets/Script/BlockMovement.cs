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
    private int modelNum;

    private int currentTurnState;

    // Use this for initialization
    void Start()
    {
        m_Spawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>();
        m_GridSystem = GameObject.FindGameObjectWithTag("GridSystem").GetComponent<GridSystem>();
        modelNum = -1;

        currentTurnState = 0;
    }

    // Update is called once per frame
    void Update()
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
            turn(m_Spawner.getModelNum());
        }

        defaultMovementTimer += Time.deltaTime;
        if (defaultMovementTimer > 1.0)
        {
            moveDown();
            defaultMovementTimer = 0.0f;
        }
    }

    public void moveDown()
    {
        //Debug.Log(transform.GetChild(2).position);

        if (m_GridSystem.checkMoveGrid(0, transform))
        {
            transform.position += Vector3.down;
            //Debug.Log("transform pos : " + transform.position);
            //Debug.Log(transform.GetChild(2).position);

        }

        else
        {
            Debug.Log("stop pos : " + transform.position);

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

    private void moveLeft()
    {
        int j = 1;
        //for (int i = 1; i < 21; i++)
        //{
        //    Debug.Log(m_GridSystem.getGrid(j, i));
        //}

        if (m_GridSystem.checkMoveGrid(1, transform))
            transform.position += Vector3.left;
    }

    private void moveRight()
    {
        if (m_GridSystem.checkMoveGrid(2, transform))
            transform.position += Vector3.right;
    }

    private void turn(int modelNum)
    {
        switch (modelNum)
        {
            //if prefab is 'IBlock'
            case (0):
                turnIBlock();
                break;

            //if prefab is 'LeftLblock'
            case (1):
                turnLeftLBlock();
                break;

            //if prefab is 'RightLBlock'
            case (2):
                turnRightLBlock();
                break;

            //if prefab is 'SBlock'
            case (3):
                turnSBlock();
                break;

            //if prefab is 'ZBlock'
            case (4):
                turnZBlock();
                break;

            //if prefab is 'TBlock'
            case (5):
                turnTBlock();
                break;

            //if prefab is 'SquareBlock'
            case (6):
                turnSquareBlock();
                break;

            default:
                break;
        }
    }

    private void turnIBlock()
    {
        if (currentTurnState == 0)
        {
            if (
                !m_GridSystem.getGrid((int)transform.position.x, (int)transform.position.y + 1) &&
                !m_GridSystem.getGrid((int)transform.position.x, (int)transform.position.y) &&
                !m_GridSystem.getGrid((int)transform.position.x, (int)transform.position.y - 1) &&
                !m_GridSystem.getGrid((int)transform.position.x, (int)transform.position.y - 2)
                )
            {
                transform.GetChild(0).position += Vector3.right;
                transform.GetChild(0).position += Vector3.right;
                transform.GetChild(0).position += Vector3.down;
                transform.GetChild(0).position += Vector3.down;
                transform.GetChild(1).position += Vector3.right;
                transform.GetChild(1).position += Vector3.down;
                transform.GetChild(3).position += Vector3.left;
                transform.GetChild(3).position += Vector3.up;

                currentTurnState = 1;
            }
        }

        else if (currentTurnState == 1)
        {
            if (
                !m_GridSystem.getGrid((int)transform.position.x - 1, (int)transform.position.y) &&
                !m_GridSystem.getGrid((int)transform.position.x, (int)transform.position.y) &&
                !m_GridSystem.getGrid((int)transform.position.x + 1, (int)transform.position.y) &&
                !m_GridSystem.getGrid((int)transform.position.x + 2, (int)transform.position.y)
                )
            {
                transform.GetChild(0).position += Vector3.right;
                transform.GetChild(0).position += Vector3.right;
                transform.GetChild(0).position += Vector3.up;
                transform.GetChild(0).position += Vector3.up;
                transform.GetChild(1).position += Vector3.right;
                transform.GetChild(1).position += Vector3.up;
                transform.GetChild(3).position += Vector3.left;
                transform.GetChild(3).position += Vector3.down;

                currentTurnState = 2;
            }
        }

        else if (currentTurnState == 2)
        {
            if (
                !m_GridSystem.getGrid((int)transform.position.x, (int)transform.position.y + 2) &&
                !m_GridSystem.getGrid((int)transform.position.x, (int)transform.position.y + 1) &&
                !m_GridSystem.getGrid((int)transform.position.x, (int)transform.position.y) &&
                !m_GridSystem.getGrid((int)transform.position.x, (int)transform.position.y - 1)
                )
            {
                transform.GetChild(0).position += Vector3.left;
                transform.GetChild(0).position += Vector3.left;
                transform.GetChild(0).position += Vector3.up;
                transform.GetChild(0).position += Vector3.up;
                transform.GetChild(1).position += Vector3.left;
                transform.GetChild(1).position += Vector3.up;
                transform.GetChild(3).position += Vector3.right;
                transform.GetChild(3).position += Vector3.down;

                currentTurnState = 3;
            }
        }

        else if (currentTurnState == 3)
        {
            if (
                !m_GridSystem.getGrid((int)transform.position.x - 2, (int)transform.position.y) &&
                !m_GridSystem.getGrid((int)transform.position.x - 1, (int)transform.position.y) &&
                !m_GridSystem.getGrid((int)transform.position.x, (int)transform.position.y) &&
                !m_GridSystem.getGrid((int)transform.position.x + 1, (int)transform.position.y)
                )
            {
                transform.GetChild(0).position += Vector3.left;
                transform.GetChild(0).position += Vector3.left;
                transform.GetChild(0).position += Vector3.down;
                transform.GetChild(0).position += Vector3.down;
                transform.GetChild(1).position += Vector3.left;
                transform.GetChild(1).position += Vector3.down;
                transform.GetChild(3).position += Vector3.right;
                transform.GetChild(3).position += Vector3.up;

                currentTurnState = 0;
            }
        }
    }

    private void turnLeftLBlock()
    {
        if (currentTurnState == 0)
        {
            if (
                !m_GridSystem.getGrid((int)transform.position.x, (int)transform.position.y - 1) &&
                !m_GridSystem.getGrid((int)transform.position.x + 1, (int)transform.position.y - 1) &&
                !m_GridSystem.getGrid((int)transform.position.x + 1, (int)transform.position.y) &&
                !m_GridSystem.getGrid((int)transform.position.x + 1, (int)transform.position.y + 1)
                )
            {
                transform.GetChild(0).position += Vector3.right;
                transform.GetChild(0).position += Vector3.down;
                transform.GetChild(1).position += Vector3.right;
                transform.GetChild(1).position += Vector3.right;
                transform.GetChild(2).position += Vector3.right;
                transform.GetChild(2).position += Vector3.up;
                transform.GetChild(3).position += Vector3.up;
                transform.GetChild(3).position += Vector3.up;

                currentTurnState = 1;
            }
        }

        else if (currentTurnState == 1)
        {
            if (
                !m_GridSystem.getGrid((int)transform.position.x + 1, (int)transform.position.y) &&
                !m_GridSystem.getGrid((int)transform.position.x + 1, (int)transform.position.y + 1) &&
                !m_GridSystem.getGrid((int)transform.position.x, (int)transform.position.y + 1) &&
                !m_GridSystem.getGrid((int)transform.position.x - 1, (int)transform.position.y - 1)
                )
            {
                transform.GetChild(0).position += Vector3.right;
                transform.GetChild(0).position += Vector3.up;
                transform.GetChild(1).position += Vector3.up;
                transform.GetChild(1).position += Vector3.up;
                transform.GetChild(2).position += Vector3.left;
                transform.GetChild(2).position += Vector3.up;
                transform.GetChild(3).position += Vector3.left;
                transform.GetChild(3).position += Vector3.left;

                currentTurnState = 2;
            }
        }

        else if (currentTurnState == 2)
        {
            if (
                !m_GridSystem.getGrid((int)transform.position.x, (int)transform.position.y + 1) &&
                !m_GridSystem.getGrid((int)transform.position.x - 1, (int)transform.position.y + 1) &&
                !m_GridSystem.getGrid((int)transform.position.x - 1, (int)transform.position.y) &&
                !m_GridSystem.getGrid((int)transform.position.x - 1, (int)transform.position.y - 1)
                )
            {
                transform.GetChild(0).position += Vector3.left;
                transform.GetChild(0).position += Vector3.up;
                transform.GetChild(1).position += Vector3.left;
                transform.GetChild(1).position += Vector3.left;
                transform.GetChild(2).position += Vector3.left;
                transform.GetChild(2).position += Vector3.down;
                transform.GetChild(3).position += Vector3.down;
                transform.GetChild(3).position += Vector3.down;

                currentTurnState = 3;
            }
        }

        else if (currentTurnState == 3)
        {
            if (
                !m_GridSystem.getGrid((int)transform.position.x - 1, (int)transform.position.y) &&
                !m_GridSystem.getGrid((int)transform.position.x - 1, (int)transform.position.y - 1) &&
                !m_GridSystem.getGrid((int)transform.position.x, (int)transform.position.y - 1) &&
                !m_GridSystem.getGrid((int)transform.position.x + 1, (int)transform.position.y - 1)
                )
            {
                transform.GetChild(0).position += Vector3.left;
                transform.GetChild(0).position += Vector3.down;
                transform.GetChild(1).position += Vector3.down;
                transform.GetChild(1).position += Vector3.down;
                transform.GetChild(2).position += Vector3.right;
                transform.GetChild(2).position += Vector3.down;
                transform.GetChild(3).position += Vector3.right;
                transform.GetChild(3).position += Vector3.right;

                currentTurnState = 0;
            }
        }
    }

    private void turnRightLBlock()
    {
        if (currentTurnState == 0)
        {
            if (
                !m_GridSystem.getGrid((int)transform.position.x, (int)transform.position.y + 1) &&
                !m_GridSystem.getGrid((int)transform.position.x + 1, (int)transform.position.y + 1) &&
                !m_GridSystem.getGrid((int)transform.position.x + 1, (int)transform.position.y) &&
                !m_GridSystem.getGrid((int)transform.position.x + 1, (int)transform.position.y - 1)
                )
            {
                transform.GetChild(0).position += Vector3.left;
                transform.GetChild(0).position += Vector3.up;
                transform.GetChild(1).position += Vector3.up;
                transform.GetChild(1).position += Vector3.up;
                transform.GetChild(2).position += Vector3.right;
                transform.GetChild(2).position += Vector3.up;
                transform.GetChild(3).position += Vector3.right;
                transform.GetChild(3).position += Vector3.right;

                currentTurnState = 1;
            }
        }

        else if (currentTurnState == 1)
        {
            if (
                !m_GridSystem.getGrid((int)transform.position.x - 1, (int)transform.position.y) &&
                !m_GridSystem.getGrid((int)transform.position.x - 1, (int)transform.position.y + 1) &&
                !m_GridSystem.getGrid((int)transform.position.x, (int)transform.position.y + 1) &&
                !m_GridSystem.getGrid((int)transform.position.x + 1, (int)transform.position.y + 1)
                )
            {
                transform.GetChild(0).position += Vector3.left;
                transform.GetChild(0).position += Vector3.down;
                transform.GetChild(1).position += Vector3.left;
                transform.GetChild(1).position += Vector3.left;
                transform.GetChild(2).position += Vector3.left;
                transform.GetChild(2).position += Vector3.up;
                transform.GetChild(3).position += Vector3.up;
                transform.GetChild(3).position += Vector3.up;

                currentTurnState = 2;
            }
        }

        else if (currentTurnState == 2)
        {
            if (
                !m_GridSystem.getGrid((int)transform.position.x, (int)transform.position.y - 1) &&
                !m_GridSystem.getGrid((int)transform.position.x - 1, (int)transform.position.y - 1) &&
                !m_GridSystem.getGrid((int)transform.position.x - 1, (int)transform.position.y) &&
                !m_GridSystem.getGrid((int)transform.position.x - 1, (int)transform.position.y + 1)
                )
            {
                transform.GetChild(0).position += Vector3.right;
                transform.GetChild(0).position += Vector3.down;
                transform.GetChild(1).position += Vector3.down;
                transform.GetChild(1).position += Vector3.down;
                transform.GetChild(2).position += Vector3.left;
                transform.GetChild(2).position += Vector3.down;
                transform.GetChild(3).position += Vector3.left;
                transform.GetChild(3).position += Vector3.left;

                currentTurnState = 3;
            }
        }

        else if (currentTurnState == 3)
        {
            if (
                !m_GridSystem.getGrid((int)transform.position.x + 1, (int)transform.position.y) &&
                !m_GridSystem.getGrid((int)transform.position.x + 1, (int)transform.position.y - 1) &&
                !m_GridSystem.getGrid((int)transform.position.x, (int)transform.position.y - 1) &&
                !m_GridSystem.getGrid((int)transform.position.x - 1, (int)transform.position.y - 1)
                )
            {
                transform.GetChild(0).position += Vector3.right;
                transform.GetChild(0).position += Vector3.up;
                transform.GetChild(1).position += Vector3.right;
                transform.GetChild(1).position += Vector3.right;
                transform.GetChild(2).position += Vector3.right;
                transform.GetChild(2).position += Vector3.down;
                transform.GetChild(3).position += Vector3.down;
                transform.GetChild(3).position += Vector3.down;

                currentTurnState = 0;
            }
        }
    }

    private void turnSBlock()
    {
        if (currentTurnState == 0)
        {
            if (
                !m_GridSystem.getGrid((int)transform.position.x, (int)transform.position.y + 1) &&
                !m_GridSystem.getGrid((int)transform.position.x, (int)transform.position.y) &&
                !m_GridSystem.getGrid((int)transform.position.x + 1, (int)transform.position.y) &&
                !m_GridSystem.getGrid((int)transform.position.x + 1, (int)transform.position.y - 1)
                )
            {
                transform.GetChild(0).position += Vector3.right;
                transform.GetChild(0).position += Vector3.right;
                transform.GetChild(1).position += Vector3.right;
                transform.GetChild(1).position += Vector3.up;
                transform.GetChild(3).position += Vector3.left;
                transform.GetChild(3).position += Vector3.up;

                currentTurnState = 1;
            }
        }

        else if (currentTurnState == 1)
        {
            if (
                !m_GridSystem.getGrid((int)transform.position.x - 1, (int)transform.position.y) &&
                !m_GridSystem.getGrid((int)transform.position.x, (int)transform.position.y) &&
                !m_GridSystem.getGrid((int)transform.position.x, (int)transform.position.y + 1) &&
                !m_GridSystem.getGrid((int)transform.position.x + 1, (int)transform.position.y + 1)
                )
            {
                transform.GetChild(0).position += Vector3.up;
                transform.GetChild(0).position += Vector3.up;
                transform.GetChild(1).position += Vector3.left;
                transform.GetChild(1).position += Vector3.up;
                transform.GetChild(3).position += Vector3.left;
                transform.GetChild(3).position += Vector3.down;

                currentTurnState = 2;
            }
        }

        else if (currentTurnState == 2)
        {
            if (
                !m_GridSystem.getGrid((int)transform.position.x - 1, (int)transform.position.y + 1) &&
                !m_GridSystem.getGrid((int)transform.position.x - 1, (int)transform.position.y) &&
                !m_GridSystem.getGrid((int)transform.position.x , (int)transform.position.y) &&
                !m_GridSystem.getGrid((int)transform.position.x, (int)transform.position.y - 1)
                )
            {
                transform.GetChild(0).position += Vector3.left;
                transform.GetChild(0).position += Vector3.left;
                transform.GetChild(1).position += Vector3.left;
                transform.GetChild(1).position += Vector3.down;
                transform.GetChild(3).position += Vector3.right;
                transform.GetChild(3).position += Vector3.down;

                currentTurnState = 3;
            }
        }

        else if (currentTurnState == 3)
        {
            if (
                !m_GridSystem.getGrid((int)transform.position.x + 1, (int)transform.position.y) &&
                !m_GridSystem.getGrid((int)transform.position.x, (int)transform.position.y) &&
                !m_GridSystem.getGrid((int)transform.position.x, (int)transform.position.y - 1) &&
                !m_GridSystem.getGrid((int)transform.position.x - 1, (int)transform.position.y - 1)
                )
            {
                transform.GetChild(0).position += Vector3.down;
                transform.GetChild(0).position += Vector3.down;
                transform.GetChild(1).position += Vector3.right;
                transform.GetChild(1).position += Vector3.down;
                transform.GetChild(3).position += Vector3.right;
                transform.GetChild(3).position += Vector3.up;

                currentTurnState = 0;
            }
        }
    }

    private void turnZBlock()
    {
        if(currentTurnState == 0)
        {
            if (
                !m_GridSystem.getGrid((int)transform.position.x + 1, (int)transform.position.y + 1) &&
                !m_GridSystem.getGrid((int)transform.position.x + 1, (int)transform.position.y) &&
                !m_GridSystem.getGrid((int)transform.position.x, (int)transform.position.y) &&
                !m_GridSystem.getGrid((int)transform.position.x, (int)transform.position.y - 1)
                )
            {
                transform.GetChild(0).position += Vector3.up;
                transform.GetChild(0).position += Vector3.up;
                transform.GetChild(1).position += Vector3.right;
                transform.GetChild(1).position += Vector3.up;
                transform.GetChild(3).position += Vector3.right;
                transform.GetChild(3).position += Vector3.down;

                currentTurnState = 1;
            }
        }

        else if (currentTurnState == 1)
        {
            if (
                !m_GridSystem.getGrid((int)transform.position.x - 1, (int)transform.position.y + 1) &&
                !m_GridSystem.getGrid((int)transform.position.x, (int)transform.position.y + 1) &&
                !m_GridSystem.getGrid((int)transform.position.x, (int)transform.position.y) &&
                !m_GridSystem.getGrid((int)transform.position.x + 1, (int)transform.position.y)
                )
            {
                transform.GetChild(0).position += Vector3.left;
                transform.GetChild(0).position += Vector3.left;
                transform.GetChild(1).position += Vector3.left;
                transform.GetChild(1).position += Vector3.up;
                transform.GetChild(3).position += Vector3.right;
                transform.GetChild(3).position += Vector3.up;

                currentTurnState = 2;
            }
        }

        else if (currentTurnState == 2)
        {
            if (
                !m_GridSystem.getGrid((int)transform.position.x - 1, (int)transform.position.y - 1) &&
                !m_GridSystem.getGrid((int)transform.position.x - 1, (int)transform.position.y) &&
                !m_GridSystem.getGrid((int)transform.position.x, (int)transform.position.y) &&
                !m_GridSystem.getGrid((int)transform.position.x, (int)transform.position.y + 1)
                )
            {
                transform.GetChild(0).position += Vector3.down;
                transform.GetChild(0).position += Vector3.down;
                transform.GetChild(1).position += Vector3.left;
                transform.GetChild(1).position += Vector3.down;
                transform.GetChild(3).position += Vector3.left;
                transform.GetChild(3).position += Vector3.up;

                currentTurnState = 3;
            }
        }

        else if (currentTurnState == 3)
        {
            if (
                !m_GridSystem.getGrid((int)transform.position.x - 1, (int)transform.position.y) &&
                !m_GridSystem.getGrid((int)transform.position.x, (int)transform.position.y) &&
                !m_GridSystem.getGrid((int)transform.position.x, (int)transform.position.y - 1) &&
                !m_GridSystem.getGrid((int)transform.position.x + 1, (int)transform.position.y - 1)
                )
            {
                transform.GetChild(0).position += Vector3.right;
                transform.GetChild(0).position += Vector3.right;
                transform.GetChild(1).position += Vector3.right;
                transform.GetChild(1).position += Vector3.down;
                transform.GetChild(3).position += Vector3.left;
                transform.GetChild(3).position += Vector3.down;

                currentTurnState = 0;
            }
        }
    }

    private void turnTBlock()
    {
        if (currentTurnState == 0)
        {
            if (
                !m_GridSystem.getGrid((int)transform.position.x - 1, (int)transform.position.y) &&
                !m_GridSystem.getGrid((int)transform.position.x, (int)transform.position.y - 1) &&
                !m_GridSystem.getGrid((int)transform.position.x, (int)transform.position.y) &&
                !m_GridSystem.getGrid((int)transform.position.x, (int)transform.position.y + 1)
                )
            {
                transform.GetChild(0).position += Vector3.left;
                transform.GetChild(0).position += Vector3.down;
                transform.GetChild(1).position += Vector3.right;
                transform.GetChild(1).position += Vector3.down;
                transform.GetChild(3).position += Vector3.left;
                transform.GetChild(3).position += Vector3.up;

                currentTurnState = 1;
            }
        }

        else if (currentTurnState == 1)
        {
            if (
                !m_GridSystem.getGrid((int)transform.position.x, (int)transform.position.y - 1) &&
                !m_GridSystem.getGrid((int)transform.position.x - 1, (int)transform.position.y) &&
                !m_GridSystem.getGrid((int)transform.position.x, (int)transform.position.y) &&
                !m_GridSystem.getGrid((int)transform.position.x + 1, (int)transform.position.y)
                )
            {
                transform.GetChild(0).position += Vector3.right;
                transform.GetChild(0).position += Vector3.down;
                transform.GetChild(1).position += Vector3.right;
                transform.GetChild(1).position += Vector3.up;
                transform.GetChild(3).position += Vector3.left;
                transform.GetChild(3).position += Vector3.down;

                currentTurnState = 2;
            }
        }

        else if (currentTurnState == 2)
        {
            if (
                !m_GridSystem.getGrid((int)transform.position.x + 1, (int)transform.position.y) &&
                !m_GridSystem.getGrid((int)transform.position.x, (int)transform.position.y - 1) &&
                !m_GridSystem.getGrid((int)transform.position.x, (int)transform.position.y) &&
                !m_GridSystem.getGrid((int)transform.position.x, (int)transform.position.y + 1)
                )
            {
                transform.GetChild(0).position += Vector3.right;
                transform.GetChild(0).position += Vector3.up;
                transform.GetChild(1).position += Vector3.left;
                transform.GetChild(1).position += Vector3.up;
                transform.GetChild(3).position += Vector3.right;
                transform.GetChild(3).position += Vector3.down;

                currentTurnState = 3;
            }
        }

        else if (currentTurnState == 3)
        {
            if (
                !m_GridSystem.getGrid((int)transform.position.x, (int)transform.position.y + 1) &&
                !m_GridSystem.getGrid((int)transform.position.x - 1, (int)transform.position.y) &&
                !m_GridSystem.getGrid((int)transform.position.x, (int)transform.position.y) &&
                !m_GridSystem.getGrid((int)transform.position.x + 1, (int)transform.position.y)
                )
            {
                transform.GetChild(0).position += Vector3.left;
                transform.GetChild(0).position += Vector3.up;
                transform.GetChild(1).position += Vector3.left;
                transform.GetChild(1).position += Vector3.down;
                transform.GetChild(3).position += Vector3.right;
                transform.GetChild(3).position += Vector3.up;

                currentTurnState = 0;
            }
        }
    }

    private void turnSquareBlock()
    {
        if (currentTurnState == 0)
        {
            if (
                !m_GridSystem.getGrid((int)transform.position.x, (int)transform.position.y) &&
                !m_GridSystem.getGrid((int)transform.position.x, (int)transform.position.y + 1) &&
                !m_GridSystem.getGrid((int)transform.position.x + 1, (int)transform.position.y + 1) &&
                !m_GridSystem.getGrid((int)transform.position.x + 1, (int)transform.position.y)
                )
            {
                transform.GetChild(0).position += Vector3.right;
                transform.GetChild(1).position += Vector3.down;
                transform.GetChild(2).position += Vector3.left;
                transform.GetChild(3).position += Vector3.up;

                currentTurnState = 1;
            }
        }

        else if (currentTurnState == 1)
        {
            if (
                !m_GridSystem.getGrid((int)transform.position.x, (int)transform.position.y) &&
                !m_GridSystem.getGrid((int)transform.position.x, (int)transform.position.y + 1) &&
                !m_GridSystem.getGrid((int)transform.position.x + 1, (int)transform.position.y + 1) &&
                !m_GridSystem.getGrid((int)transform.position.x + 1, (int)transform.position.y)
                )
            {
                transform.GetChild(0).position += Vector3.up;
                transform.GetChild(1).position += Vector3.right;
                transform.GetChild(2).position += Vector3.down;
                transform.GetChild(3).position += Vector3.left;

                currentTurnState = 2;
            }
        }

        else if (currentTurnState == 2)
        {
            if (
                !m_GridSystem.getGrid((int)transform.position.x, (int)transform.position.y) &&
                !m_GridSystem.getGrid((int)transform.position.x, (int)transform.position.y + 1) &&
                !m_GridSystem.getGrid((int)transform.position.x + 1, (int)transform.position.y + 1) &&
                !m_GridSystem.getGrid((int)transform.position.x + 1, (int)transform.position.y)
                )
            {
                transform.GetChild(0).position += Vector3.left;
                transform.GetChild(1).position += Vector3.up;
                transform.GetChild(2).position += Vector3.right;
                transform.GetChild(3).position += Vector3.down;

                currentTurnState = 3;
            }
        }

        else if (currentTurnState == 3)
        {
            if (
                !m_GridSystem.getGrid((int)transform.position.x, (int)transform.position.y) &&
                !m_GridSystem.getGrid((int)transform.position.x, (int)transform.position.y + 1) &&
                !m_GridSystem.getGrid((int)transform.position.x + 1, (int)transform.position.y + 1) &&
                !m_GridSystem.getGrid((int)transform.position.x + 1, (int)transform.position.y)
                )
            {
                transform.GetChild(0).position += Vector3.down;
                transform.GetChild(1).position += Vector3.left;
                transform.GetChild(2).position += Vector3.up;
                transform.GetChild(3).position += Vector3.right;

                currentTurnState = 0;
            }
        }
    }

    //private void turnCCW()
    //{
    //    transform.Rotate(new Vector3(0.0f, 0.0f, -90.0f));

    //    for (int i = 0; i < 4; i++)
    //        transform.GetChild(i).Rotate(new Vector3(0.0f, 0.0f, 90.0f));
    //}

    //private void turnCW()
    //{
    //    transform.Rotate(new Vector3(0.0f, 0.0f, 90.0f));

    //    for (int i = 0; i < 4; i++)
    //        transform.GetChild(i).Rotate(new Vector3(0.0f, 0.0f, -90.0f));
    //}

    //private void turn()
    //{
    //    int j = 1;
    //    //for(int i = 1; i < 21; i++)
    //    //{
    //    //    Debug.Log(m_GridSystem.getGrid(j, i));
    //    //}

    //    turnCCW();

    //    for (int i = 0; i < 4; i++)
    //    {
    //        if (m_GridSystem.getGrid((int)transform.GetChild(i).position.x, (int)transform.GetChild(i).position.y))
    //        {
    //            turnCW();
    //            return;
    //        }
    //    }
    //}
}
