using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FirePoint : MonoBehaviour
{
    public TwinSticks2D playerActionsAsset;
    public GameObject bullet1;
    public Rigidbody2D player1; 
    public float fireRate = 0.5f;
    public float lastShot = 0f;
    public bool canShoot = false;
    public Rigidbody2D shooter;
    public float bulletSpeed = 100f;
    NewInputController controller;
    Vector2 lookPosition;
    public GameObject playership;

    // Start is called before the first frame update
    void Awake()
    {
        player1 = GetComponent<Rigidbody2D>();
        controller = GetComponent<NewInputController>();
        playerActionsAsset = new TwinSticks2D();
        playerActionsAsset.Player.Look.performed += ctx => lookPosition = ctx.ReadValue<Vector2>();
    }
    private void OnEnable()
    {


        playerActionsAsset.Player.Fire.performed += DoFire;
        playerActionsAsset.Player.Enable();
    }

    private void OnDisable()
    {
        
        playerActionsAsset.Player.Disable();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void DoFire(InputAction.CallbackContext obj)
    {
        if (obj.performed == true)
        {
            if (Time.time > fireRate + lastShot)
            {
                GameObject clone = Instantiate(bullet1, this.transform.position, this.transform.rotation * Quaternion.Euler(0, 0, 90f));
                Physics2D.IgnoreCollision(clone.GetComponent<Collider2D>(), playership.GetComponent<Collider2D>());
                shooter = clone.GetComponent<Rigidbody2D>();
                shooter.AddForce(new Vector2(lookPosition.x,lookPosition.y) * bulletSpeed, ForceMode2D.Impulse);
                Destroy(clone.gameObject, 1f);
                lastShot = Time.time;
            }
        }
    }
}
