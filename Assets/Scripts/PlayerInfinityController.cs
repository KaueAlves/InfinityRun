using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfinityController : MonoBehaviour {

    public Rigidbody2D playerInfinityRigidBody;
    public Animator playerInfinityAnimator;
    public BoxCollider2D playerInfinityBoxCollider;
    public Transform playerInfinityTranform;
    public Transform GroundCheck;
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
            dodge = false;
            playerInfinityRigidBody.AddForce(new Vector2(0,forceJump));
        }
        //Botão de dodge
        if (Input.GetButtonDown("Fire1") && grounded) {
            timeTemp = 0;
            dodge = true;
        }
       
        //tempo de dodge
        if (dodge) {
            timeTemp += Time.deltaTime;
            if (timeTemp >= dodgeTemp) {
                dodge = false;
            }
        }
        //Define animção de Andar/Pular/Rolar
        jump = !grounded;
        playerInfinityAnimator.SetBool("jump", jump);
        playerInfinityAnimator.SetBool("dodge", dodge);

    }
}
