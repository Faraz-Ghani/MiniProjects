using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    public float speed = 3f;
    public PipeGenerator pipeGenerator;
    // Start is called before the first frame update
    void Start()
    {
      pipeGenerator = GameObject.Find("PipeGenerator").GetComponent<PipeGenerator>();   
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

   private void OnTriggerEnter2D(Collider2D other) {
     if (other.gameObject.tag == "Player")
        {
            
        }
    else if (other.gameObject.tag == "Finish")
        {
        pipeGenerator.generate();
        Destroy(gameObject);
        }
   }

   public void OnCollisionEnter2D(Collision2D other) {
      speed=0f;
   }


}
