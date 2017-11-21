using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Definição de Variaveis (primeira minuscula,segunda maiscula)
    public Rigidbody2D playerRigidbody; // Colocar PlayerRigidbody = GetComponent<Rigidbody2D>(); no Start
    public Animator playerAnimator;
    public int forceJump;
    public int velocidade;
    public bool jump;
    public bool up;
    public bool down;
    public bool left;
    public bool right;

    //Verificar o chão
    public bool grounded;
    public LayerMask WhatisGround;
    public Transform GroundCheck;
    public bool groundedBefore; // Auxilia na precisão

    //Criação de Colider

    public Transform colider;

    //Contator
    public int i = 0;


    // Use this for initialization || Antes de iniciar o GameLoop
    void Start()
    {
        //Debug.Log("Hello World");
        playerRigidbody.freezeRotation = true;
        velocidade = 1;

    }

    // Update is called once per frame || GameLoop
    void Update()
    {

        // Cria um verificador de Ground Check
        grounded = Physics2D.OverlapCircle(GroundCheck.position, 0.02f, WhatisGround);

        // Botão de Pulo
        if (Input.GetButtonDown("Jump") && grounded && !jump)
        {
            playerRigidbody.AddForce(new Vector2(0, forceJump));
            jump = true;
            grounded = false;
        }
    

    
        //Botões de andar
        if (Input.GetAxisRaw("Horizontal") > 0) {
            right = true;
            left = false;
            transform.Translate(Vector2.right * velocidade * Time.deltaTime);
        }
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            left = true;
            right = false;
            transform.Translate(Vector2.left * velocidade * Time.deltaTime);
        }
        if (Input.GetAxisRaw("Vertical") > 0) {
            up = true;
            down = false;
            //transform.Translate(Vector2.up * velocidade * Time.deltaTime);
        }
        if (Input.GetAxisRaw("Vertical") < 0)
        {
            up = false;
            down = true;
            //transform.Translate(Vector2.down * velocidade * Time.deltaTime);
        }
        if (Input.GetAxisRaw("Horizontal") == 0) {
            left = false;
            right = false;
        }
        if (Input.GetAxisRaw("Vertical") == 0) {
            up = false;
            down = false;
     
        }
        

        // Verificação de Pulos
        if (!jump && !grounded && groundedBefore)
        {
            //Animação de queda
            Debug.Log("Queda");
            jump = false;
            grounded = false;
            groundedBefore = true;
            
        }
        else if (jump && !grounded)
        {
            //Animação de pulo
            Debug.Log("Pulo");
            jump = true;
            grounded = false;
            groundedBefore = false;
        }
        else if (jump && grounded)
        {
            //Instante da Queda
            Debug.Log("Instante");
            jump = false;
            grounded = true;
            groundedBefore = false;
        }
        else if (!jump && grounded)
        {
            Debug.Log("Chão");
            //No chaõ
            jump = false;
            grounded = true;
            groundedBefore = true;
        }

        playerAnimator.SetBool("up", up);
        playerAnimator.SetBool("down", down);
        playerAnimator.SetBool("right", right);
        playerAnimator.SetBool("left", left);
        playerAnimator.SetBool("jump", jump);
        playerAnimator.SetBool("grounded", grounded);

    }
}
