using UnityEngine;
using System.Collections;

public class Ennemies : MonoBehaviour
{
    protected int health;
    protected float rangeDetection;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage()
    {
        health -= 1;

        if (health <= 0) Destroy(gameObject);
    }

}
