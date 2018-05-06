using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultBullet : MonoBehaviour {
    public GameObject cannon;
    public GameObject bulletPrefab;
    
    public bool isCreated = false;

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
    void Update()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.up * -1);
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collision Detection");
        if (other.gameObject.CompareTag("HITABLE"))
        {
            Debug.Log("is HITABLE");
            GameObject.Destroy(gameObject, 2);
        }
        if (dead)
        {
            return;
        }
        GameObject go = other.gameObject;
        if (go != null && go.layer == LayerMask.NameToLayer("layer-2"))
        {
            Destroy(gameObject);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }


}
