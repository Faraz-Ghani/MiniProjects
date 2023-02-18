using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeGenerator : MonoBehaviour
{
    public GameObject spike;

    public float minspeed;
    public float maxspeed;
    public float currentspeed;
    public float speedmultipler;
    // Start is called before the first frame update
    void Awake()
    {
        currentspeed = minspeed;
        generateSpike();
    }
    public void randomizer()
    {
        float randomWait = Random.Range(01f, 02f);
        Invoke("generateSpike", randomWait);
    }
    public void generateSpike()
    {
        GameObject Spike = Instantiate(spike,transform.position,transform.rotation);
        Spike.GetComponent<SpikeScript>().spikeGenerator = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentspeed < maxspeed)
        {
            currentspeed += speedmultipler;
        }
    }
}
