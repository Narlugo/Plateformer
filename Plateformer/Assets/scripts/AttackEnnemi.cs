using UnityEngine;
using System.Collections;

public class AttackEnnemi : Ennemies
{

    public Transform player;

    private new Rigidbody2D rigidbody;
    
    
    public EnnemiWeapons gun;
    [Range(0, 2)]
    public float delay = 5f;

    // Use this for initialization
    void Start()
    {
        health = 5;
        rangeDetection = 5f;
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        delay -= Time.deltaTime;


        if (Vector2.Distance(player.position, transform.position) <= rangeDetection && delay <= 0f)
        {
            Debug.Log("SHOOT");

                gun.Shoot();
                delay = 5f;

        }

    }



}
