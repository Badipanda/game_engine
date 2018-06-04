using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    private Rigidbody2D rb;
    // Ref ao Rigidbody2D da nossa bala
    public Transform bulletSpriteTransform;
    // Ref ao transform do GameObject Sprite que está dentro do GameObject Bullet
    private bool updateAngle = true;
    // bool que diz se devemos ou não atualizar a rotação do GameObject Sprite baseado na traj. da bala
    // Esse bool serve para dizer que após a bala colidir com algum outro corpo, a rotação 
    //da bala não deve ser mais atualizada baseando-se na trajetória
   
    // Ref ao gameObject BulletSmoke, que contém o sistema de particula que faz o rastro da bala
    public CircleCollider2D destructionCircle;
    public static GroundController groundController;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //rb.velocity = new Vector2(5f, 10f);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log("enter collision");
        // Quando a bala colide com outro corpo que nao seja o Player ela 
        //não mais atualiza a rotação baseado na trajetória
        // e o efeito de partícula do rastro da bala é desativado
        if (coll.collider.tag == "Ground")
        {
            
            groundController.DestroyGround(destructionCircle);
            Destroy(gameObject);
        }
    }
}
