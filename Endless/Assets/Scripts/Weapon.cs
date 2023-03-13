using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float CooldownTime;
    float cooldownUntilNextPress; 
    public BulletGenerator BulletGenerator;
    int ammo=3;
    public GameObject Player;
    public Transform firePoint;
    public GameObject bulletPrefab;
    // Update is called once per frame
    void Update()
    {
/*        if (Input.GetButtonDown("Fire1") && ammo>0 && Time.timeScale>0)
        {
            Shoot();
        }
  */  }

    public void Shoot()
    {   
        if (ammo>0 && Time.timeScale > 0 && cooldownUntilNextPress < Time.time)
        {

            ammo--;
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        }
    }

    public void Pickup()
    {
        ammo++;
        BulletGenerator.randomizer();

    }



}
