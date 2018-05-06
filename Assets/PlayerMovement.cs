using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody2D Char; 
    public float speed = 100;
    
    
    public bool is_movable = false;
    private SpriteRenderer facing_right;

    private float h;

    void Start()
    {
        Char = GetComponent<Rigidbody2D>();
        facing_right = GetComponent<SpriteRenderer>();
    }

    

    public void FixedUpdate()
    {
        if(is_movable == true)
        {
            h = Input.GetAxis("Horizontal");
            //Check to flip;
            Flip();

            float v = Input.GetAxis("Vertical");

            
            Vector3 my_v = Char.velocity;

            my_v.x = h * speed * Time.deltaTime;
            if(v > 0)
            {
                my_v.y = v * speed * Time.deltaTime;
            }
            Char.velocity = my_v;

            //--Andere Herangehensweise mit Addforce--->>
            //-- Use the two store floats to create a new Vector2 variable movement.
            //Vector2 movement = new Vector2(h, v);
            //movement = movement * speed;
            

            //--Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
            //Char.AddForce(movement);
        }
        else
        {
           Debug.Log("not active");
        }
       
    }

    

    void Flip()
    {
        if (h < 0)
        {
            facing_right.flipX = true;

        }
        else if ((h > 0))
        {
            facing_right.flipX = false;
        }

    }
   
    void OnMouseDown()
    {
        GameObject[] objs;
        objs = GameObject.FindGameObjectsWithTag("Tank");
        foreach (GameObject tank in objs)
        {
            var script = tank.GetComponent<PlayerMovement>();
            script.is_movable = false;
            Debug.Log("Tanks deactivated");
            Debug.Log(this.is_movable + "für" + this);
        }
               this.is_movable = true;
            }
}

