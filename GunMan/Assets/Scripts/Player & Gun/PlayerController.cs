using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float minrecoil;
    public float maxrecoil;
    
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            Vector2 clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = rb.position - clickPos;
            float distance = Vector2.Distance(rb.position, Camera.main.transform.position);
            float forceMagnitude = Mathf.Lerp(maxrecoil, minrecoil, distance / Camera.main.orthographicSize);
            rb.AddForce(direction.normalized *forceMagnitude, ForceMode2D.Impulse);
            Debug.Log("Mouse Position: " + clickPos.y);
        }
    }
}
