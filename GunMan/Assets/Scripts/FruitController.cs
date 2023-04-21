using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitController : MonoBehaviour
{
    public float speed;
    public Generator generator;
    
    public float x=0;
    public ScoreScript score;

    public GameObject points;
    // Start is called before the first frame update
    void Start()
    {
        score = FindObjectOfType<ScoreScript>();
        generator = FindObjectOfType<Generator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        transform.Rotate(0,x*Time.deltaTime,0);
        x=x + (10 * Time.deltaTime);
        checkPosition();
    }

    public void checkPosition(){
        if(transform.position.y < -10   ){
            generator.Generate();
            Destroy(gameObject);
        }
    }
    
    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            score.scoreValue+=5;
            if(points){
                ShowFloatingText();
            }
            generator.Generate();
            Destroy(gameObject);
        }
    }
    void ShowFloatingText(){   
        var go = Instantiate(points,transform.position,Quaternion.identity);
        go.GetComponent<TextMesh>().text = "+5";
    }
}
