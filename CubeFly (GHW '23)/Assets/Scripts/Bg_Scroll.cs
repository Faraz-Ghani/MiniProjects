using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bg_Scroll : MonoBehaviour
{
    public float speed =4f;
    private Vector3 StartPos;
    // Start is called before the first frame update
    void Start()
    {
        StartPos=transform.position;
    }

    // Update is called once per frame
    void Update()
    {   if(transform.position.x<-66.8f){
        transform.position=StartPos;    
    }
        transform.Translate(Vector3.left*speed*Time.deltaTime);
    }

    public void setSpeed(){
        speed=4f;
    }
}
