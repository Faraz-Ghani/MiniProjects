using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.transform.position.z - transform.position.z;
        Vector3 lookPos = Camera.main.ScreenToWorldPoint(mousePos);
        lookPos.z = transform.position.z;
        transform.up = lookPos - transform.position;
   
    }
}
