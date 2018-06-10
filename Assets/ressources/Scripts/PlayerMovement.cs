using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

	private Rigidbody2D Char;
	public float speed = 100;
	public int playerID = 0;
//	private static GameObject manager;
//	public PlayerManager playerManager;
    
	public bool is_movable = false;
	private SpriteRenderer facing_right;

    public Sprite nonActivePlayer;
    public Sprite activePlayer;

    private float h;

	void Start ()
	{
		Char = GetComponent<Rigidbody2D> ();
		facing_right = GetComponent<SpriteRenderer> ();
//		manager = GameObject.FindGameObjectWithTag ("Manager");
//		playerManager = manager.GetComponentInChildren<PlayerManager> ();


	}

	void Update ()
	{
//        		playerManager.NextPlayerMove();
        if (is_movable)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = activePlayer;
        }
        else {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = nonActivePlayer;
        }
    }


	public void FixedUpdate ()
	{



		if (is_movable == true) {
			h = Input.GetAxis ("Horizontal");
			//Check to flip;
			Flip ();

			float v = Input.GetAxis ("Vertical");

            
			Vector3 my_v = Char.velocity;

			my_v.x = h * speed * Time.deltaTime;
			if (v > 0) {
				my_v.y = v * speed * Time.deltaTime;
			}
			Char.velocity = my_v;

           
		}
        
       
	}

//	void CheckState ()
//	{
//		float check = playerManager.currentPlayer;
//		if (check == playerID) {
//			is_movable = true;
//		} else {
//			is_movable = false;
//		}
//    
//	}

	void Flip ()
	{
		if (h < 0) {
			facing_right.flipX = true;

		} else if ((h > 0)) {
			facing_right.flipX = false;
		}

	}
   
	//    void OnMouseDown()
	//    {
	//        GameObject[] objs;
	//        objs = GameObject.FindGameObjectsWithTag("Tank");
	//        foreach (GameObject tank in objs)
	//        {
	//            var script = tank.GetComponent<PlayerMovement>();
	//            script.is_movable = false;
	//            Debug.Log("Tanks deactivated");
	//            Debug.Log(this.is_movable + "für" + this);
	//        }
	//               this.is_movable = true;
	//            }
}

