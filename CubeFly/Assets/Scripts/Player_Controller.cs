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
    public bool alive = false;
    public Bg_Scroll bg;
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerRigidbody.gravityScale = 0;   
    }

    void Update()
    {
        checkInput();
        checkfall();
        if (alive)
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
        if (Input.GetKeyDown(KeyCode.Space) && alive)
        {
            playerAnimator.SetTrigger("Jump");
            playerRigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
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

    private void OnCollisionEnter2D(Collision2D other) {
        Death();
    }

    public void play()
    {
        playerRigidbody.gravityScale = 1;
        alive= true;
    }

    public void Death(){
        bg.speed=0f;
        alive=false;
        
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
    }
}

