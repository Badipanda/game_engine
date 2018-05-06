using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBehaviour : MonoBehaviour {

    public bool dead = false;
    public int explosionRadius = 40; // unity units * 100

    // Use this for initialization
    void Start () {
        Vector2 explosionPos = new Vector2(transform.position.x, transform.position.y);
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, (float)explosionRadius / 100);

        for (int i = 0; i < colliders.Length; i++)
        {
            // TODO: two calls for getcomponent is bad
            if (colliders[i].GetComponent<destrutible_terrain>())
                colliders[i].GetComponent<destrutible_terrain>().ApplyDamage(explosionPos, explosionRadius);
        }
    }
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody2D>().AddForce(transform.up * -1);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (dead)
        {
            return;
        }

        GameObject go = other.gameObject;
        if (go != null && go.layer == LayerMask.NameToLayer("Level"))
        {
            Destroy(gameObject);
        }
    }
}
