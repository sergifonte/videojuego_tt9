using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float Speed;

    public Transform centralSphere;  // 1
    public float orbitRadius = 7f;   // 2
    public float orbitSpeed = 20f;   // 3
    private float angle = 0f;        // 4


    // Update is called once per frame
    void Update()
    {
        angle += orbitSpeed * Time.deltaTime;  // 5
        float rad = angle * Mathf.Deg2Rad;     // 6
        Vector3 offset = new Vector3(Mathf.Cos(rad) * orbitRadius, 0, Mathf.Sin(rad) * orbitRadius);  // 7
        transform.position = centralSphere.position + offset;  // 8

    }
}
