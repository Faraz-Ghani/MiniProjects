using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool alive = true;
    public BoxCollider2D colliderBox;
    public FruitGenerator Fgenerator;
    public EnemyGenerator Egenerator;
    public GunController Gun;
    public ParticleSystem Particle;
    public float minrecoil;
    public float maxrecoil;
    public GameObject bullet;
    public Transform muzzle;
    public Animator GameOver;
    public ScoreScript score;
    
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        score = FindObjectOfType<ScoreScript>();
        Egenerator=FindObjectOfType<EnemyGenerator>();
        Fgenerator=FindObjectOfType<FruitGenerator>();
        colliderBox=GetComponent<BoxCollider2D>();
        Gun = FindObjectOfType<GunController>();
        rb=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && alive){
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
            Instantiate(bullet,muzzle.transform.position,Quaternion.identity);
    }

    public void die(){
        GameOver.SetTrigger("Game Over");
        rb.velocity = Vector2.zero;
        rb.AddForce(Vector2.up*5, ForceMode2D.Impulse);
        rb.gravityScale=1;
        alive=false;
        colliderBox.isTrigger = true;
        Egenerator.isGameOver = true;
        Fgenerator.isGameOver = true;
        score.isGameOver = true;
    }

}
