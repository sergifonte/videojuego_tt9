using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//CODI DE LES PLATAFORMES MÒBILS//
/*Per poder fer que la plataforma sempre es mogui en l'eix z, s'ha de girar el guizmo segons com estigui col·locada la plataforma.*/
public class Move : MonoBehaviour
{
    public float speed = 3;
    public float position_x;
    public float position_z;
    public float limit_1;
    public float limit_2;
    private int direction = 1; 

    void Start()
    {
        transform.position = new Vector3(position_x, 0, position_z);
    }
    void Update()
    {
        // Mou la plataforma en l'eix X
        transform.Translate(Vector3.forward * speed * direction * Time.deltaTime);

        // Comprova límits i canvia direcció
        if (transform.position.z >= limit_2)
            direction = -1;

        if (transform.position.z <= limit_1)
            direction = 1;
    }
}
