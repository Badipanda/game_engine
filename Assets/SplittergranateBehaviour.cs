﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplittergranateBehaviour : MonoBehaviour
{
    public int splitter_count = 10;
    public GameObject[] gos;

    public bool isCreated = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            fire();
        }

    }

    void fire()
    {
        //Clone of the bullet
        if (!isCreated)
        {
            float bla = 1f;
            //GameObject Clone;
            //Clone = (Instantiate(gameObject, transform.position, transform.rotation)) as GameObject;
            gos = new GameObject[splitter_count];
            for (int i = 0; i < gos.Length; i++)
            {
                bla = bla *(-1f);
                GameObject clone = (GameObject)Instantiate(gameObject, transform.position, transform.rotation);
                clone.GetComponent<Rigidbody2D>().AddForce(new Vector2((20*bla),(10 * bla))*10f);
                gos[i] = clone;
            }


            //Instantiate(gameObject, transform.position, transform.rotation);
            //Instantiate(gameObject, transform.position, transform.rotation);
            //Instantiate(gameObject, transform.position, transform.rotation);


            GameObject.Destroy(gameObject);
            isCreated = true;



        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collision Detection");
        if (other.gameObject.CompareTag("HITABLE") || other.gameObject.CompareTag("Tank"))
        {
            Debug.Log("is HITABLE");
            GameObject.Destroy(gameObject);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }


}
