using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{   
    public Animator Animator;
    public PipeGenerator PipeGenerator;
    public Player_Controller playerController;
    public Bg_Scroll Bg_Scroll;
    private void awake() {
       Animator = GetComponent<Animator>();
    }
    public void play()
    {
        Animator.SetTrigger("Play");
        Bg_Scroll.setSpeed();   
       // playerController.play();
        PipeGenerator.generateTwo();
    }
}
