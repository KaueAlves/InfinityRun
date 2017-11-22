using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfinityController : MonoBehaviour {

    public Rigidbody2D playerInfinityRigidBody;
    public Animator playerInfinityAnimator;
    public BoxCollider2D playerInfinityBoxCollider;
    public Transform playerInfinityTranform;
    public Transform GroundCheck;
    public Transform Colisor;
    public LayerMask WhatIsFloor;
    

    public bool grounded;
    public bool jump;
    public bool dodge;
    public int forceJump;
    public float dodgeTemp;
    public float timeTemp;


	// Use this for initialization
	void Start () {
        forceJump = 200;
	}
	
	// Update is called once per frame
	void Update () {
        // Cria verificador de solo
        grounded = Physics2D.OverlapCircle(GroundCheck.position, 0.02f, WhatIsFloor);
        //Botão de pular
        if (Input.GetButtonDown("Jump") && grounded) {
            if (dodge) {
                Colisor.position = new Vector3(Colisor.position.x, Colisor.position.y + 0.055f);
            }
            dodge = false;
            playerInfinityRigidBody.AddForce(new Vector2(0,forceJump));
        }
        //Botão de dodge
        if (Input.GetButtonDown("Fire1") && grounded && !dodge) {
            Colisor.position = new Vector3(Colisor.position.x,Colisor.position.y- 0.055f);
            timeTemp = 0;
            dodge = true;

        }
       
        //tempo de dodge
        if (dodge) {
            timeTemp += Time.deltaTime;
            if (timeTemp >= dodgeTemp) {
                Colisor.position = new Vector3(Colisor.position.x, Colisor.position.y + 0.055f);
                dodge = false;
            }
        }
        //Define animção de Andar/Pular/Rolar
        jump = !grounded;
        playerInfinityAnimator.SetBool("jump", jump);
        playerInfinityAnimator.SetBool("dodge", dodge);


        //Fim update
    }

    void OnTriggerEnter2D() {
        Debug.Log("Bateu");
    }
}
