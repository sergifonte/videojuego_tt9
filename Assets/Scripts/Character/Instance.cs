using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instance : MonoBehaviour
{
    public GameObject WaxBall;
    public Transform InstancePoint;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Poop();
        }
    }

    private void Poop()
    {
        var waxBall = Instantiate(WaxBall, InstancePoint.position, InstancePoint.rotation);
    }
}
