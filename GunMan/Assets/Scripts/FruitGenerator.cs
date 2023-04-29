using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitGenerator : MonoBehaviour
{

    public bool isGameOver = false;
    public GameObject Fruit;
    public float mindelay=1;
    public float maxdelay=5;

    private int x_thresold=2;


    // Start is called before the first frame update
    void Start()
    {
        Generate();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Generate(){
        if(!isGameOver){Debug.Log("Generate");
        float delay = Random.Range(mindelay,maxdelay);
        Invoke("GenerateFruit",delay);
        int rand = Random.Range(0,2);
        }
    }    


    public void GenerateFruit(){
        int x = Random.Range(-x_thresold,x_thresold);
        Vector3 pos = new Vector3(x,transform.position.y,transform.position.z);
        Instantiate(Fruit,pos,Quaternion.identity);
    }
}
