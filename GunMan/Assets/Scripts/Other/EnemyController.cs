using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public EnemyGenerator enemyGenerator;
    
    // Start is called before the first frame update
    void Start()
    {
        enemyGenerator = FindObjectOfType<EnemyGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
          transform.Translate(Vector2.down * speed * Time.deltaTime);
   }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            Debug.Log("Game Over");
        }
        else if(other.tag =="Ground"){
            enemyGenerator.Generate();
            Destroy(gameObject);    
        }
        else if(other.tag == "Bullet"){
            Debug.Log("Hit");
            Destroy(gameObject);
        }
    }
}
