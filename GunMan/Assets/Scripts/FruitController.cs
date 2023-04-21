using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitController : MonoBehaviour
{
    public float speed;
    public Generator generator; 
    public float x=0;
    public ScoreScript score;
    public GameObject[] points;
    
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
            addfive();
            generator.Generate();
            Destroy(gameObject);
        }
        else if(other.tag == "Bullet"){
            subtractfive();
            generator.Generate();
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
    void subtractfive(){
        score.updateval(-5);
        ShowFloatingText(1);
    }
    void addfive(){
        score.updateval(5);
        ShowFloatingText(0);
    }
    void ShowFloatingText(int val){   
        var go = Instantiate(points[val],transform.position,Quaternion.identity);
        // go.GetComponent<TextMesh>().text = val.ToString();
    }
}
