using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
 
    public Animator Transition;

    public float transtiontime=1f;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            LoadNextLevel();
        }       
    }
    public void LoadNextLevel(){
        StartCoroutine (LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }
    
    IEnumerator LoadLevel(int LevelIndex){
        //Play animation
        Transition.SetTrigger("Start");
        //wait
        yield return new WaitForSeconds(transtiontime);
        //load Scene
        SceneManager.LoadScene(LevelIndex);
        Debug.Log("Loading Level");
    }
}
