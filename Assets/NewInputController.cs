using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewInputController : MonoBehaviour
{
    public TwinSticks2D playerActionsAsset;
    public GameObject bullet1;
    public float movementSpeed = 30f;
    public Rigidbody2D player1;
    public bool spawned = false;
    public Rigidbody2D shooter;
    public float bulletSpeed = 100f;
    private InputAction move;
    private InputAction look;

    Vector2 movementInput;
    Vector2 lookPosition;
    public Camera mainCamera;
    public Vector2 shootAngle;
    public float angleDeg = 0f;
    public float fireRate = 0.5f;
    public float lastShot = 0f;
    public bool canShoot = false;

    // Start is called before the first frame update
    private void Awake()
    {
        player1 = this.GetComponent<Rigidbody2D>();
        playerActionsAsset = new TwinSticks2D();
        playerActionsAsset.Player.Move.performed += ctx => movementInput = ctx.ReadValue<Vector2>();
        playerActionsAsset.Player.Look.performed += ctx => lookPosition = ctx.ReadValue<Vector2>();
    }

    void Start()
    {

    }

    private void OnEnable()
    {


        playerActionsAsset.Player.Fire.performed += DoFire;

        playerActionsAsset.Player.Fire.Enable();

        look = playerActionsAsset.Player.Look;
        playerActionsAsset.Player.Look.Enable();

        move = playerActionsAsset.Player.Move;
        playerActionsAsset.Player.Move.Enable();

        playerActionsAsset.Player.Enable();
    }

    private void OnDisable()
    {
        playerActionsAsset.Player.Fire.Disable();

        playerActionsAsset.Player.Look.Disable();

        playerActionsAsset.Player.Move.Disable();

        playerActionsAsset.Player.Disable();
    }

    public void Move(InputAction.CallbackContext obj)
    {
        player1 = gameObject.GetComponent<Rigidbody2D>();
        float leftNRight = movementInput.x * movementSpeed * Time.fixedDeltaTime;
        float upNDown = movementInput.y * movementSpeed * Time.fixedDeltaTime;
        player1.AddForce(new Vector2(leftNRight, upNDown), ForceMode2D.Impulse);
    }

    public void DoLook(InputAction.CallbackContext obj)
    {
        shootAngle = new Vector2(lookPosition.x, lookPosition.y);
        if (shootAngle.x < 0)
        {
            angleDeg = 360 - (Mathf.Atan2(shootAngle.x, shootAngle.y) * Mathf.Rad2Deg * -1);
        }
        else
        {
            angleDeg = Mathf.Atan2(shootAngle.x, shootAngle.y) * Mathf.Rad2Deg;
        }
        Vector3 rot = new Vector3(0, 0, angleDeg);
        transform.rotation = Quaternion.Euler(-rot);

    }

    public void DoFire(InputAction.CallbackContext obj)
    {
        if (obj.performed == true)
        {
            if (Time.time > fireRate + lastShot)
            {
                GameObject clone = Instantiate(bullet1, this.transform.position + new Vector3(lookPosition.x, lookPosition.y, 0) * 0.5f, this.transform.rotation * Quaternion.Euler(0, 0, 90f));
                Physics2D.IgnoreCollision(clone.GetComponent<Collider2D>(), GetComponent<Collider2D>());
                shooter = clone.GetComponent<Rigidbody2D>();
                shooter.AddForce(new Vector3(lookPosition.x, lookPosition.y, 0) * bulletSpeed, ForceMode2D.Impulse);
                Destroy(clone.gameObject, 1f);
                lastShot = Time.time;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
