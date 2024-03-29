using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{

    public bool isGameOver = false;
    public GameObject Enemy;
    public float mindelay=0;
    public float maxdelay=2;

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
        int rand = Random.Range(0,2);
        Invoke("GenerateEnemy",delay);
      
        }
    }    

    public void GenerateEnemy(){
        int x = Random.Range(-x_thresold,x_thresold);
        Vector3 pos = new Vector3(x,transform.position.y,transform.position.z);
        Instantiate(Enemy,pos,Quaternion.identity);
    }
}
