using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public Rigidbody2D thisEnemy;
    public Rigidbody2D shooter2;
    public GameObject enemyLaser;
    public GameObject enemyShip;
    public float bulletSpeed2;
    private IEnumerator coroutine;
    private bool spawned = false;
    private bool running = false; 

    private void Start()
    {
        thisEnemy = this.GetComponent<Rigidbody2D>();
        bulletSpeed2 = 10f;
    }

    private IEnumerator Shooter()
    {
        while (true)
        {
            GameObject clone2 = Instantiate(enemyLaser, this.transform.position + new Vector3(0, -1, 0) * 1.5f, this.transform.rotation);
            shooter2 = clone2.GetComponent<Rigidbody2D>();
            shooter2.AddForce(new Vector2(0, -1) * bulletSpeed2);
            Destroy(clone2.gameObject, 1.125f);
            yield return new WaitForSeconds(1.5f);
            spawned = false;
            running = true;
        }
    }

    void Update()
    {
        if (!spawned && !running) 
        { 
            coroutine = Shooter();
            StartCoroutine(coroutine);
            spawned = true;
            running = true; 
        }
    }
}


