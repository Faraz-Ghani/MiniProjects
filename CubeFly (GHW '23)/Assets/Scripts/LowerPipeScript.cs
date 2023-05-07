using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerPipeScript : MonoBehaviour
{
    public PipeGenerator pipeGenerator;
    public Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GameObject.Find("Canvas").GetComponent<Animator>();
        pipeGenerator = GameObject.Find("PipeGenerator").GetComponent<PipeGenerator>();     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player")
        {

            anim.SetTrigger("Death");
            other.gameObject.GetComponent<Player_Controller>().Death();
        }
        
    }
}
    