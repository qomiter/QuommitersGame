using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAdvance : MonoBehaviour
{
    public GameObject player1;  
    
    public float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.Find("Player");
    }

    /*
    private void Move(Vector3 target, float movementSpeed)
    {
        transform.position += (target - transform.position).normalized * movementSpeed * Time.deltaTime;
    }
    */
    // Update is called once per frame
    void Update()
    {
        if(player1 != null)
        transform.position =  Vector2.MoveTowards(transform.position, player1.transform.position, speed * Time.deltaTime);
    }
}
