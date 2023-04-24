using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public bool isGameOver = false;
    [SerializeField] private TextMeshProUGUI score;
    public float scoreValue = 0;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       if(!isGameOver){ scoreValue+=Time.deltaTime*0.75f;
        score.text =  ((int)scoreValue).ToString();}
    }

    public void updateval(int val){
        anim.SetTrigger("Pop");
        scoreValue+=val;
    }

}
