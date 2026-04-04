using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instance : MonoBehaviour
{
    public GameObject WaxBall;
    public Transform InstancePoint;
    public GameObject Character; 

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

        size(); 
    }

    private void Poop()
    {
        var waxBall = Instantiate(WaxBall, InstancePoint.position, InstancePoint.rotation);
    }

    private void size()
    {
        switch (index)
        {
            case 0:
                Character.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                break;
            case 1: 
                Character.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
                break;
            case 2:
                Character.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                break; 
        }
    }
}
