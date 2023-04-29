using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public PlayerController player;
    public float speed;
    public EnemyGenerator generator;
    
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        generator = FindObjectOfType<EnemyGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
          transform.Translate(Vector2.down * speed * Time.deltaTime);
   }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            player.die();
            Debug.Log("Game Over");
        }
        else if(other.tag =="Ground"){
            generator.Generate();
            Destroy(gameObject);    
        }
        else if(other.tag == "Bullet"){
            generator.Generate();
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
