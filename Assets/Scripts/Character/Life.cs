using UnityEngine;

public class Life : MonoBehaviour
{
    /*SCRIPT PER LES BOLES DE FOC QUE LI BAIXEN LA VIDA AL JUGADOR (NO TOCAR, FUNCIONA) - Emma
     El personatge detecta la bola per el collider i el tag de fireBall. Totes les boles de foc han de tenir el tag, l'script el porta el personatge.*/
    
    public float life = 5f;
    public GameObject fireBall;
    public bool isColliding = false; 
    void Update()
    {
        //Això atura l'execució de tot, és temporal per mentre no tinguem menús i cinemàtiques:)
        if (life <= 0)
        {
            Time.timeScale = 0f; 
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("fireBall"))
        {
            isColliding = true;
            life -= 0.1f; 
        }
    }
}
