using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public Rigidbody2D playerRigidbody;
    public bool isFalling ;
    public float jumpForce =10f;
    public Animator playerAnimator;
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        checkInput();
        checkfall();
        checkAngle();
    }

    public void checkAngle(){
        if (isFalling && transform.rotation.z > -45f)
        {
            //rotate towards -45 degrees on z axis
            transform.rotation = Quaternion.Euler(0, 0, transform.rotation.z-15f); 
        }
        else if (!isFalling && transform.rotation.z < 45f)
        {
            //rotate towards 45 degrees on z axis
            transform.rotation = Quaternion.Euler(0, 0, transform.rotation.z+30f); 
        }
    }

    public void checkInput(){
        if (Input.GetKeyDown(KeyCode.Space))
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
}

