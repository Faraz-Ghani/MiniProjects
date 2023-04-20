using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GunController Gun;
    public ParticleSystem Particle;
    public float minrecoil;
    public float maxrecoil;
    
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        Gun = FindObjectOfType<GunController>();
        rb=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            Shoot();
        }
        
    }

    void Shoot(){
            Vector2 clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = rb.position - clickPos;
            float distance = Vector2.Distance(rb.position, Camera.main.transform.position);
            float forceMagnitude = Mathf.Lerp(maxrecoil, minrecoil, distance / Camera.main.orthographicSize);
            rb.AddForce(direction.normalized *forceMagnitude, ForceMode2D.Impulse);
            Particle.Play();
            Gun.Shoot();
    }
}
