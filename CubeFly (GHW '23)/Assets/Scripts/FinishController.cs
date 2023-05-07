using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishController : MonoBehaviour
{
    public PipeGenerator pipeGenerator;
    // Start is called before the first frame update
    void Start()
    {
        pipeGenerator = GameObject.Find("PipeGenerator").GetComponent<PipeGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "Pipe"){
            pipeGenerator.generate();
        }
        else if(other.gameObject.tag == "Pipe2")
        {
            pipeGenerator.generate();
        }
        
    }
}
