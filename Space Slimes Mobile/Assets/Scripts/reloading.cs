using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reloading : MonoBehaviour
{

    GameObject player;
    public void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");   
        MoveGameObject();   
    }
    public void MoveGameObject()
    {
        print("moving");
        transform.position = player.transform.position+ new Vector3(0, 1.5f, 0);
    }
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);

    }

    // Update is called once per frame
    
}
