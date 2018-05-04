using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private Rigidbody2D Char; 
    public float speed = 100;
    public float gravity = -0.5f;
    public Rigidbody2D rb;
    private Animator an;


    public bool is_movable = false;
    private SpriteRenderer m_FacingRight;

    public Transform bodyTransform;
    public float velocity;


    void Start()
    {
        Char = GetComponent<Rigidbody2D>();
        m_FacingRight = GetComponent<SpriteRenderer>();
    }

    

    public void Update()
    {
        if(is_movable == true)
        {
            float h = Input.GetAxis("Horizontal");
            //float v = Input.GetAxis("Vertical");

            float v = gravity;

            Vector3 tempVect = new Vector3(h, v, 0);
            //Flip();
            if (h < 0)
            {
                m_FacingRight.flipX = true;
               
            }
            else if((h > 0))
            {
                m_FacingRight.flipX = false;
            }
            Debug.Log(h);
            tempVect = tempVect * speed * Time.deltaTime;
            Char.MovePosition(Char.transform.position + tempVect);
        }
        else
        {
           Debug.Log("not active");
        }
       
    }

    void Flip()
    {
        Debug.Log("abgeflipt");
        
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
            Debug.Log(this.is_movable + "für" + this.gameObject);
        }
               this.is_movable = true;
    }
    void Move()
    {
        GameObject[] objs;
        objs = GameObject.FindGameObjectsWithTag("Tank");

        foreach (GameObject tank in objs)
        {
            if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
            {
                rb.velocity = Vector2.right * velocity;
                if (bodyTransform.localScale.x > 0f)
                    bodyTransform.localScale = new Vector3(-bodyTransform.localScale.x, bodyTransform.localScale.y, 0f);

                an.SetBool("moving", true);
            }
            else if (!Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftArrow))
            {
                rb.velocity = -Vector2.right * velocity;
                if (bodyTransform.localScale.x < 0f)
                    bodyTransform.localScale = new Vector3(-bodyTransform.localScale.x, bodyTransform.localScale.y, 0f);

                an.SetBool("moving", true);
            }
            else
            {
                rb.velocity = Vector2.zero;
                an.SetBool("moving", false);
            }
        }
        this.is_movable = true;
    }

}

