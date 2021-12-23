using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityScaler : MonoBehaviour
{   
    public Rigidbody2D faller;
    public float dropSpeed = 0f;
    // Start is called before the first frame update
    void Start()
    {
        faller.GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {

        dropSpeed = dodah.gameScore / 1000;
       
        faller.gravityScale = dropSpeed + 0.5f;
       
    }
}
