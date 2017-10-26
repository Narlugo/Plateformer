using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    // Use this for initialization

    public int health = 5;
    public float speed = 7.5f;
    public float jumpForce= 20f;
    public float dashForce = 20f;
    private Rigidbody2D rb;
    private Collider2D col;
    public bool grounded;
    private Bounds b;
    private Vector2 min;
    private Vector2 max;
    private LayerMask groundMask = 1 << 8;

    public Weapon gun;
    [Range (0, 2)]
    public float timeBtwShoot = 2f;
    private float timeLeftBtwShoot = 0f;


    void Start () {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update () {

        if ((gun.isRapideFire ? Input.GetButton("Fire1") : Input.GetButtonDown("Fire1")) && timeLeftBtwShoot < Time.time)
        {
            timeLeftBtwShoot = timeBtwShoot + Time.time;
            gun.Shoot();
        }

        b = col.bounds;
        min = new Vector2(b.min.x, b.min.y);
        max = new Vector2(b.max.x,b.min.y);
        
        if (Input.GetButtonDown("Jump") && grounded == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            grounded = false;
        }

    }

    void FixedUpdate()
    {
        grounded = false;
        rb.velocity = new Vector2(speed * Input.GetAxis("Horizontal"), rb.velocity.y);

        if (Physics2D.Raycast(new Vector2(min.x, min.y), Vector2.down, 0.1f, groundMask) || Physics2D.Raycast(new Vector2(max.x, max.y), Vector2.down, 0.1f, groundMask))
        {
            grounded = true;
        }

        if (Input.GetKeyDown("left shift"))
        {
            Debug.Log("Héhé");
            rb.velocity = new Vector2(speed * Input.GetAxis("Horizontal") * dashForce, rb.velocity.y);
        }



    }
    public void TakeDamage()
    {
        health -= 1;

        if (health <= 0) Destroy(gameObject);
    }



}
