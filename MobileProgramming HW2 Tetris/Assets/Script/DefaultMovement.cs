using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultMovement : MonoBehaviour
{
    private float timer = 0.0f;
    private bool stopCheck = false;

    public void moveDown()
    {
        transform.position += Vector3.down;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "StopBlock")
            stopCheck = true;
    }

    // Use this for initialization
    void Start ()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime;
        if (timer > 1.0 && !stopCheck)
        {
            moveDown();
            timer = 0.0f;
        }
    }
}
