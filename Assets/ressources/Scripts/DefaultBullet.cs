using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultBullet : MonoBehaviour {
    public GameObject cannon;
    public GameObject bulletPrefab;
    
    public bool isCreated = false;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
       

    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collision Detection");
        if (other.gameObject.CompareTag("HITABLE"))
        {
            Debug.Log("is HITABLE");
            GameObject.Destroy(gameObject, 2);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }


}
