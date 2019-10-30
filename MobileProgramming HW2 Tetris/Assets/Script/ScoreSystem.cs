﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField]
    private int score;
    [SerializeField]
    private int finalScore;
    [SerializeField]
    private int combo;

    private float timer;

	// Use this for initialization
	void Start ()
    {
        score = 0;
        finalScore = 0;
        combo = 0;
        timer = 0.0f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //timer += Time.deltaTime;
        //if (timer > 0.5f)
        //{
        //    Debug.Log(finalScore);
        //    timer = 0.0f;
        //}
    }

    public void increaseScore()
    {
        finalScore += 100;
    }

    public void increaseCombo(int times)
    {
        combo = times;
    }

    public void resetCombo()
    {
        combo = 0;
    }

    public void calculateCombo()
    {
        finalScore += 100 * combo;
    }
}
