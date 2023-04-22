using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator Transition;
    public int NextLevelIndex ;
    public Animator ButtonAnimator;

    public float transtiontime=1f;

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadNextLevel(){
        StartCoroutine (LoadLevel(NextLevelIndex));
    }
    
    IEnumerator LoadLevel(int LevelIndex){
        ButtonAnimator.SetTrigger("StartGame"); 
        //Play animation
        Transition.SetTrigger("Start");
        //wait
        yield return new WaitForSeconds(transtiontime);
        //load Scene
        SceneManager.LoadScene(LevelIndex);
        Debug.Log("Loading Level");
    }
}
