using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleController : MonoBehaviour
{
    GameObject BulletCollider;

    public ParticleSystem Particle;
    // Start is called before the first frame update
    void Start()
    {
        Particle.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if(Particle.isPlaying){
            BulletCollider.SetActive(true);
            Invoke("BulletCollider.SetActive(false)", 0.2f);
        }

    }

    public void Shoot(){
        Particle.Play();
        Debug.Log("Muzzle Shooting");
    }
}
