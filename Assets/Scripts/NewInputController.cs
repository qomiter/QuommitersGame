using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NewInputController : MonoBehaviour
{
    public Rigidbody2D player1;
    public float movementSpeed = 30f;

    // Start is called before the first frame update
    private void Awake()
    {
        player1 = GetComponent<Rigidbody2D>();
     
    }

    private void FixedUpdate()
    {
        float leftNRight = Input.GetAxis("Horizontal") * movementSpeed * Time.fixedDeltaTime;
        float upNDown = Input.GetAxis("Vertical") * movementSpeed * Time.fixedDeltaTime;
        player1.AddForce(new Vector2(leftNRight, upNDown), ForceMode2D.Impulse);
        player1.rotation = Mathf.Rad2Deg * Mathf.Atan2(Input.GetAxis("RVertical"), Input.GetAxis("RHorizontal"));


    }
}
