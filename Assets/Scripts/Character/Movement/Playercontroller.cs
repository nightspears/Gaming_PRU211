using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // SerializeField attribute allows the variable to be shown in the Inspector
    [SerializeField]
    private float speed = 10;// movement speed defluat 10
    [SerializeField]
    private float jumpforce = 5;// how high can jump
    private float moveinput;// take input
    [SerializeField]
    private bool facingRight;// to turn the player
    private bool Isground; // to double or even triple jump
    private Animator anim;// to initialize Animation
    public Transform groundCheck; // to see if touch ground
    public float Checkradius; // for future ( to see if you want to hover )
    public LayerMask WhatIsGround; // initialize LayerMask: ground
    private Rigidbody2D rb; // to initialize Rigidbody2D
    [SerializeField]
    private int extraJumps = 1; // ammount of extra jump available (this will need update) 
    void Start()
    {
        // initialize
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void FixedUpdate(){// handle physics this time step is set to 0.02 seconds
        Isground = Physics2D.OverlapCircle(groundCheck.position,Checkradius,WhatIsGround);
        moveinput = Input.GetAxis("Horizontal"); // take left right arrow
        rb.velocity = new Vector2(moveinput * speed,rb.velocity.y);
        //to check if face right move right or move left to flib
        
        if(facingRight == false &&moveinput >0 ){
            Flib();
        }else if(facingRight == true && moveinput < 0){
            Flib();
            
        }
    }
    void Flib(){
        facingRight =!facingRight; //check  facing direction
        Vector3 scaler = transform.localScale; // take scale 
        scaler.x=-1*scaler.x; // flib scale
        transform.localScale = scaler; // reassign scale 
        Debug.Log(scaler.x);
        Debug.Log(transform.localScale = scaler);
    }
    void Update(){
        // if touch ground then reset double jump
        if(Isground){
            extraJumps = 1;
            anim.SetBool("IsJumping",false);
        }
        else if(Isground==false){
            anim.SetBool("IsJumping",true);
        }
        //if click w and there are double jump then move up
        if(Input.GetKeyDown(KeyCode.W)&&extraJumps>0){//jump but not the first time
            rb.velocity = Vector2.up * jumpforce;
            extraJumps--;   
            anim.SetTrigger("TakeOf");
            Debug.Log("jump"); // for test :D
            //if click w and there are no more extra jump but is touching ground then still allow jump
        }else if(Input.GetKeyDown(KeyCode.W) && extraJumps == 0 && Isground == true){ //jump for the first time
            rb. velocity = Vector2.up * jumpforce;
            anim.SetTrigger("TakeOf");
            Debug.Log("jump1"); // for test :D
        }
        


        if(moveinput == 0){// animation for running
           anim.SetBool("IsRunning", false);
        }else{
           anim.SetBool("IsRunning", true);
        }
    }
}
