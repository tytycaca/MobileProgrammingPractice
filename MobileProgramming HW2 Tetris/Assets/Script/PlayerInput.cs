using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private float timer = 0.0f;
    private float leftBoundary = 0.0f;
    private float rightBoundary = 0.0f;

    public void moveDown()
    {
        transform.position += Vector3.down / 2;
    }

    private void moveUp()
    {
        transform.position += Vector3.up / 2;
    }

    private void moveLeft ()
    {
        transform.position += Vector3.left / 2;
    }

    private void moveRight ()
    {
        transform.position += Vector3.right / 2;
    }

    // Use this for initialization
    void Start ()
    {
        Debug.Log(gameObject.name);

        if (gameObject.name == "IBlock(Clone)")
        {
            leftBoundary = -3.0f;
            rightBoundary = 3.0f;
            
        }

        else if (gameObject.name == "LeftLBlock(Clone)")
        {
            leftBoundary = -5.0f;
            rightBoundary = 2.0f;
        }

        else if (gameObject.name == "RightLBlock(Clone)")
        {
            leftBoundary = -3.0f;
            rightBoundary = 4.0f;
        }

        else if (gameObject.name == "SBlock(Clone)")
        {
            leftBoundary = -4.0f;
            rightBoundary = 3.0f;
        }

        else if (gameObject.name == "ZBlock(Clone)")
        {
            leftBoundary = -3.0f;
            rightBoundary = 4.0f;
        }

        else if (gameObject.name == "TBlock(Clone)")
        {
            leftBoundary = -4.0f;
            rightBoundary = 3.0f;
        }

        else if (gameObject.name == "SquareBlock(Clone)")
        {
            leftBoundary = -4.0f;
            rightBoundary = 4.0f;
        } 
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            timer += Time.deltaTime;
            if (timer > 0.1f)
            {
                moveDown();
                if (transform.position.y < 1)
                    moveUp();
                timer = 0.0f;
            }
        }

        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            timer += Time.deltaTime;
            if (timer > 0.1f)
            {
                moveLeft();
                if (transform.position.x < leftBoundary || transform.position.x > rightBoundary)
                    moveRight();
                timer = 0.0f;
            }
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            timer += Time.deltaTime;
            if (timer > 0.1f)
            {
                moveRight();
                if (transform.position.x < leftBoundary || transform.position.x > rightBoundary)
                    moveLeft();
                timer = 0.0f;
            }
        }
    }
}
