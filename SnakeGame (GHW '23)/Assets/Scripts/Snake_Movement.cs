using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake_Movement : MonoBehaviour
{
    public float timer = 0;
    public float timerMax = 1;
    public Vector2 GridPosition = new Vector2(0,0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            GridPosition.y += .5f;
        }
    else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            GridPosition.y -= .5f;
        }
    else if(Input.GetKeyDown(KeyCode.LeftArrow))
            {
              GridPosition.x -= .5f;
            }
    else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            GridPosition.x += .5f;
        } 
 
    if(GridPosition.x > 8 || GridPosition.x < -8 || GridPosition.y > 4.5 || GridPosition.y < -4.5){
    Debug.Log("Game Over");
    }
    else{
    transform.position = new Vector3(GridPosition.x, GridPosition.y, 0);    
        }
}
}