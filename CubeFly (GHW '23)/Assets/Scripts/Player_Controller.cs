using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Controller : MonoBehaviour
{
    public Rigidbody2D playerRigidbody;
    public bool isFalling ;
    public float jumpForce =10f;
    public Animator playerAnimator;
    public Bg_Scroll bg;
    public bool dead = false;
    public Animator anim;
    public bool play = false;
    void Awake()
    {
    }
    
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerRigidbody.gravityScale = 1; 
        anim = GameObject.Find("Canvas").GetComponent<Animator>(); 
        Death();
     
    }

    void Update()
    {
        checkInput();
        checkfall();
        if (!dead)
        {
            checkAngle();
        }
        
    }

    public void checkAngle()
    {
       
            if (isFalling && transform.rotation.z > -45f)
            {
                //rotate towards -45 degrees on z axis
                transform.rotation = Quaternion.Euler(0, 0, transform.rotation.z - 15f);
            }
            else if (!isFalling && transform.rotation.z < 45f)
            {
                //rotate towards 45 degrees on z axis
                transform.rotation = Quaternion.Euler(0, 0, transform.rotation.z + 30f);
            }
        
    }

    public void checkInput(){
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!play)
            {
                anim.SetTrigger("Play");
                Alive();

            }
            if (!dead)
            {

                playerAnimator.SetTrigger("Jump");
                playerRigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
            if(play && dead)
            {
                PlayAgain();
            }
        }


    }

    public void checkfall(){
        if (playerRigidbody.velocity.y < -0.1)
        {
            isFalling = true;
        }   
        else
        {
            isFalling = false;
        }
    }

   


    public void Death(){
        bg.speed=0f;
        GameObject[] Pipes = GameObject.FindGameObjectsWithTag("Pipe");
        foreach (GameObject obj in Pipes)
        {
            obj.GetComponent<PipeController>().speed = 0f;
            Debug.Log("Pipe Stopped");
        }
        playerRigidbody.gravityScale = 0f;
        playerRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
        dead = true;
    }

    public void Alive()
    {
        playerRigidbody.constraints = RigidbodyConstraints2D.FreezePositionX;
        bg.speed = 4f;
        GameObject[] Pipes = GameObject.FindGameObjectsWithTag("Pipe");
        foreach (GameObject obj in Pipes)
        {
            obj.GetComponent<PipeController>().speed = 3f;
        }
        playerRigidbody.gravityScale = 1f;
        dead = false;
        play = true;
    }
    
    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
    }

}

