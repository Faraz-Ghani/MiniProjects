using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitController : MonoBehaviour
{
    public Generator generator;
    // Start is called before the first frame update
    void Start()
    {
        generator = FindObjectOfType<Generator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            Debug.Log("Point++");
        }
        else if(other.tag =="Ground"){
            generator.Generate();
            Destroy(gameObject);    
        }
    }
}
