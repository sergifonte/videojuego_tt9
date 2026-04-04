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
    private bool isColliding = false;
    private GameObject currentBall;

    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            if(index < 2)
            {
                Poop();
                index++;
                Debug.Log("Poop");
            }
            else { return; }
        }

        size();

        if (Input.GetKeyDown(KeyCode.E) && isColliding)
        {
            if (index > 0)
            {
                Destroy(currentBall);
                Debug.Log("Col·lisió correcta");
                index--;
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
                Character.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f); //Mida gran
                break;
            case 1: 
                Character.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f); //Mida mitjana
                break;
            case 2:
                Character.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f); //Mida petita
                break; 
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("WaxBall"))
        {
            isColliding = true;
            currentBall = other.gameObject;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("WaxBall"))
        {
            isColliding = false;
            currentBall = null;
        }
    }
}
