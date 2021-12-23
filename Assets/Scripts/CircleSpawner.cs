using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSpawner : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject enemyShip;
    public GameObject enemySpawner;
    public float circumference = 94.25f;
    public float radius = 15f;
    public float angle = 0;
    public float xPos = 0;
    public float yPos = 0;
    public bool stopper = false;

    public void SpawnObject()
    {
        circumference = 2 * Mathf.PI * radius;
        angle = Random.Range(-360, 360);
        xPos = Mathf.Cos(angle) * radius;
        yPos = Mathf.Sin(angle) * radius;
        enemySpawner.transform.position = new Vector2(xPos, yPos);
        Instantiate(enemyShip, enemySpawner.transform.position, enemySpawner.transform.rotation);

        if (stopper)
        {
            CancelInvoke("SpawnObject");
            //do stuff
        }
    }

    void Start()
    {
        InvokeRepeating("SpawnObject", 0f, 0.5f);
    }

}








