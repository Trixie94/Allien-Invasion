﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private Vector3 startPos;
    public Transform target;
    public float speed;
    private bool moveUp;

    private void Start()
    {
        startPos = transform.position;
        moveUp = true;
    }

    private void Update()
    {
        float step = speed * Time.deltaTime;

        if (transform.position == target.position)
        {
            moveUp = false;
        }
        else if(transform.position == startPos)
        {
            moveUp = true;
        }
        if(moveUp == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, step);
        }
        else if (moveUp == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
    }
}
