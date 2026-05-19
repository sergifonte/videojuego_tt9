using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//AQUEST CODI CONTROLA LES INSTÀNCIES QUE DEIXA ANAR EL PERSONATGE I EL CANVI DE MIDA SEGONS LES BOLES DE CERA QUE LI QUEDEN//
//FUNCIONA; NO TOCAR A NO SER QUE SIGUI PER CANVIAR PARÀMETRES O ESTRICTAMENT NECESSARI (SI US PLAU, CAL ASSEGURAR-SE ABANS QUE SIGUI SÍ O SÍ NECESSARI)//
//Emma :)

public class Instance : MonoBehaviour
{
    //Aquestes variables s'assignen des de l'inspector de unity
    public GameObject WaxBall;
    public Transform InstancePoint;
    public GameObject Character; 

    //Mida inicial
    public int index = 1;

    //Altres variables
    private GameObject currentBall;
    public static Instance instance;
    bool isColliding = false; 

    private void Awake()
    {
        instance = this;
    }

    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            if(index < 2 && !isColliding)
            {
                Poop();
                index++;
                Debug.Log("Poop");
            }
            else { return; }
        }

        size();

    }

    private void Poop()
    {
        var waxBall = Instantiate(WaxBall, InstancePoint.position, InstancePoint.rotation);
    }

    public void size()
    {
        switch (index)
        {
            case 0:
                Character.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f); //Mida gran
                break;
            case 1: 
                Character.transform.localScale = new Vector3(1f, 1f, 1f); //Mida mitjana
                break;
            case 2:
                Character.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f); //Mida petita
                break; 
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("WaxBall"))
        {
            isColliding = true;
        }
        else
        {
            isColliding = false; 
        }
    }
}

