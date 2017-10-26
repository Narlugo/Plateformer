using UnityEngine;
using System.Collections;

public class EnnemiWeapons : MonoBehaviour
{
    public Transform spawn;
    public GameObject bullet;
    public Transform player;

    public void Shoot()
    {
        GameObject go;
        go = Instantiate(bullet, spawn.position, spawn.rotation) as GameObject;
        go.transform.position = new Vector3(go.transform.position.x, go.transform.position.y, 0f);
        //Debug.Log("MOUI");
    }

    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = player.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    }
}
