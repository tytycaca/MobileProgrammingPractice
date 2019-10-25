using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultMovement : MonoBehaviour
{
    private float timer = 0.0f;
    private PlayerInput PlayerInput = new PlayerInput();

    // Use this for initialization
    void Start ()
    {
        PlayerInput = GameObject.FindGameObjectWithTag("BlockPrefabs").GetComponent<PlayerInput>();

    }
	
	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime;
        if (timer > 1.0f)
        {
            PlayerInput.moveDown();
            timer = 0.0f;
        }
    }
}
