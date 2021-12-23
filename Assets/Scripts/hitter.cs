using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitter : MonoBehaviour
{
   

    void Start()
    {

    }


    public void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(this.gameObject);
        Destroy(other.gameObject);
        dodah.gameScore += 20;
    }
}