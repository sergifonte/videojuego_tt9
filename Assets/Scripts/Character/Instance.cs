using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instance : MonoBehaviour
{
    public GameObject WaxBall;
    public Transform InstancePoint;

    private int index = 1; 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            if(index < 2)
            {
                Poop();
                index++;
            }
            else { return; }
        }
    }

    private void Poop()
    {
        var waxBall = Instantiate(WaxBall, InstancePoint.position, InstancePoint.rotation);
    }
}
