using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private float timer = 0.0f;
    private float z = 0.0f;
    private float defaultMovementTimer = 0.0f;
    private bool lCheck = false;
    private bool rCheck = false;
    private bool isMoving = false;

    private Spawner Spawner = new Spawner();

    [SerializeField]
    private bool stop = false;

    public void moveDown()
    {
        transform.position += Vector3.down / 2;
    }

    private void moveUp()
    {
        transform.position += Vector3.up;
    }

    private void moveLeft ()
    {
        transform.position += Vector3.left / 2;
    }

    private void moveRight ()
    {
        transform.position += Vector3.right / 2;
    }

    private void turnCCW()
    {
        z += 90.0f;
        if (z == 360.0f)
            z = 0.0f;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, z);
    }

    public bool getStopValue()
    {
        return stop;
    }

    public void setStopValue(bool tf)
    {
        stop = tf;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        

        if (other.transform.tag == "StopBlock")
        {
            //Vector3 tmpVec = new Vector3();

            //tmpVec = new Vector3((other.transform.position.x - transform.position.x), 0, 0);
            //Debug.Log(tmpVec.normalized);

            //if ((tmpVec).normalized == new Vector3(-1.0f, 0.0f, 0.0f)
            //    || (tmpVec).normalized == new Vector3(1.0f, 0.0f, 0.0f))
            //    return;

            transform.tag = "StopBlock";
            for (int i = 0; i < 4; i++)
            {
                transform.GetChild(i).tag = "StopBlock";
            }
            stop = true;
            Spawner.setInsCheck(true);
        }

        else if (other.transform.tag == "LWall")
        {
            lCheck = true;
            rCheck = false;
        }

        else if (other.transform.tag == "RWall")
        {
            rCheck = true;
            lCheck = false;
        }
    }

    // Use this for initialization
    void Start ()
    {
        Spawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            timer += Time.deltaTime;
            if (timer > 0.1f && !stop && transform.tag != "StopBlock")
            {
                moveDown();
                timer = 0.0f;
            }

            return;
        }

        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            timer += Time.deltaTime;
            if (timer > 0.1f && !lCheck && transform.tag != "StopBlock")
            {
                moveLeft();
                lCheck = false;
                rCheck = false;
                timer = 0.0f;
            }
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            timer += Time.deltaTime;
            if (timer > 0.1f && !rCheck && transform.tag != "StopBlock")
            {
                moveRight();
                lCheck = false;
                rCheck = false;
                timer = 0.0f;
            }
        }

        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (!lCheck && !rCheck &&transform.tag != "StopBlock")
            {
                turnCCW();
                lCheck = false;
                rCheck = false;
            }
        }

        defaultMovementTimer += Time.deltaTime;
        if (defaultMovementTimer > 1.0 && transform.tag != "StopBlock")
        {
            moveDown();
            defaultMovementTimer = 0.0f;
        }
    }
}
