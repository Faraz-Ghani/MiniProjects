using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{   
    int time=0;
    public float speed = 1f;
    Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    // Update is called once per frame
    void Update()
    {
        if(time>120){
            Destroy(gameObject);
        }
        if(transform.position != target)
        {
         Vector3 newPos = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
         transform.position = newPos;
        }
        else{
            Destroy(gameObject);
        }
        time++;
    }
}
