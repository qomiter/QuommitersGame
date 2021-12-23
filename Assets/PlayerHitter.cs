using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitter : MonoBehaviour
{
    

    void Start()
    {
     
    }


    public void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
        Destroy(other.gameObject);

    }
}