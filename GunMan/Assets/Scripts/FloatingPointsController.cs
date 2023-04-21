using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingPointsController : MonoBehaviour
{
    public float DestroyTime =0.5f;
    public Vector3 offset = new Vector3(0,1,0);
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,DestroyTime);

        transform.localPosition+=offset;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
