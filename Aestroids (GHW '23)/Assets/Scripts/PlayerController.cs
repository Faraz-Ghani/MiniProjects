using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D rb;
    public bool canMove = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        checkInput();
        checkPos();
    }
    private void checkPos() {
        if (transform.position.y > 5.5f) {
            transform.position = new Vector3(transform.position.x, -5.5f, 0);
        }
        else if (transform.position.y < -5.5f) {
            transform.position = new Vector3(transform.position.x, 5.5f, 0);
        }
        if (transform.position.x > 10.3f) {
            transform.position = new Vector3(-10.3f, transform.position.y, 0);
        }
        else if (transform.position.x < -10.3f) {
            transform.position = new Vector3(10.3f, transform.position.y, 0);
        }
    }

    private void checkInput() {

        Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        //rb.AddForce(movement * speed);

        if (movement != Vector2.zero) {
        float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        if (Input.GetKey(KeyCode.W)) {
            rb.AddForce(Vector2.up * Time.deltaTime * speed, ForceMode2D.Impulse);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector2.down * Time.deltaTime * speed, ForceMode2D.Impulse);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector2.left * Time.deltaTime * speed, ForceMode2D.Impulse);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector2.right * Time.deltaTime * speed, ForceMode2D.Impulse);
        }

        

    }

}
