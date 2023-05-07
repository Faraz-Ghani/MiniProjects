using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeGenerator : MonoBehaviour
{
    public GameObject pipePrefab;
    public float yMin = -1.5f;
    public float yMax = -8.5f;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("PipeGenerator").GetComponent<PipeGenerator>();
        generateTwo();
        GameObject[] Pipes = GameObject.FindGameObjectsWithTag("Pipe");
        foreach (GameObject obj in Pipes)
        {
            obj.GetComponent<PipeController>().speed = 0f;
            Debug.Log("Pipe Stopped");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void generate(){
        float y = Random.Range(yMin, yMax);
        Instantiate(pipePrefab, new Vector3(10, y, 0), Quaternion.identity);
    }

    public void generateTwo(){
        //generate once
        float y = Random.Range(yMin, yMax);
        Instantiate(pipePrefab, new Vector3(10, y, 0), Quaternion.identity);
    


        //generate twice
         y = Random.Range(yMin, yMax);
        Instantiate(pipePrefab, new Vector3(30, y, 0), Quaternion.identity);
    
    }
}
