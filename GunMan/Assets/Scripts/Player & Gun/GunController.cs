using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
     void Start()
    {
        // Get the parent sprite renderer
        SpriteRenderer parentRenderer = transform.parent.GetComponent<SpriteRenderer>();

        // If the parent has a sprite renderer
        if (parentRenderer != null)
        {
            // Set the child's sorting order to be one more than the parent's sorting order
            GetComponent<SpriteRenderer>().sortingOrder = parentRenderer.sortingOrder + 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //relocate gun
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.transform.position.z - transform.position.z;
        Vector3 lookPos = Camera.main.ScreenToWorldPoint(mousePos);
        lookPos.z = transform.position.z;
        transform.up = lookPos - transform.position;

    }

    public void Shoot(){
        Debug.Log("Gun Shooting");
    }
}
