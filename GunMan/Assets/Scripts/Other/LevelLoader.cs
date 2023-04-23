using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator Transition;
    public int NextLevelIndex ;
    public Animator MenuAnim;
    public float transtiontime=1f;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Setings_Main(){
        MenuAnim.SetTrigger("Main_Settings");
    }

    public void About_Main(){
        MenuAnim.SetTrigger("Main_About");
    }

    public void LoadNextLevel(){
        StartCoroutine (LoadLevel(NextLevelIndex));
    }
    
    IEnumerator LoadLevel(int LevelIndex){
        MenuAnim.SetTrigger("StartGame"); 
        //Play animation
        Transition.SetTrigger("Start");
        //wait
        yield return new WaitForSeconds(transtiontime);
        //load Scene
        SceneManager.LoadScene(LevelIndex);
        Debug.Log("Loading Level");
    }
}
