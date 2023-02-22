using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPickUpScript : MonoBehaviour
{
    public BulletGenerator BulletGenerator;
    void Update()
    {
        transform.Translate(Vector2.left * BulletGenerator.currentspeed * Time.deltaTime);  
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.CompareTag("nextline"))
        {
            BulletGenerator.randomizer();
        }
        if (collision.gameObject.CompareTag("finishline"))
        {
            Destroy(this.gameObject);
        }
    }
}
