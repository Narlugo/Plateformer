using UnityEngine;
using System.Collections;

public class BulletEnnemi : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(10f * Time.deltaTime, 0f, 0f));
        Destroy(this.gameObject, 3);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        LayerMask lay = collision.gameObject.layer;
        if (lay != LayerMask.NameToLayer("Ennemi"))
        {
            if (lay == LayerMask.NameToLayer("Player"))
            {
                Player colScript = collision.gameObject.GetComponent<Player>();
                colScript.TakeDamage();
            }
            Destroy(gameObject);
        }

    }
}
