using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float jumpforce;
    float score;
    bool isAlive = true;

    [SerializeField]
    bool isGrounded = false;

    Rigidbody2D rb;

    public Text Scoretxt;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        score = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded == true)
            {
                isGrounded = false; 
                rb.AddForce(Vector2.up * jumpforce);
            }
        }
        if (isAlive)
        {
            score += Time.deltaTime * 4;
            Scoretxt.text = "SCORE : " + ((int)score).ToString();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (isGrounded==false){
                isGrounded=true; 
            }
        }
        if (collision.gameObject.CompareTag("Spike"))
        {
            isAlive = false;
            Time.timeScale = 0;
        }
    }
}