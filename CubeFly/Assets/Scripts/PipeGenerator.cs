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
        generate();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void generate(){
        float y = Random.Range(yMin, yMax);
        GameObject pipe = Instantiate(pipePrefab, new Vector3(10, y, 0), Quaternion.identity);
    }
}
