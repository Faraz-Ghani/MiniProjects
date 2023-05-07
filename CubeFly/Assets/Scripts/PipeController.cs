using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    public float speed = 3f;
    public PipeGenerator pipeGenerator;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
      pipeGenerator = GameObject.Find("PipeGenerator").GetComponent<PipeGenerator>();   
      anim = GameObject.Find("Canvas").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        if(transform.position.x < -30f){
            Destroy(gameObject);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
         if (other.gameObject.tag == "Player"){
             anim.SetTrigger("Death");
            other.gameObject.GetComponent<Player_Controller>().Death();
        }
      }


}
