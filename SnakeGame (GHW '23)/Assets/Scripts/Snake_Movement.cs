using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake_Movement : MonoBehaviour
{
    private List<Transform> _segments ; 
    public int score=0;
    public float timer = 0;
    public float timerMax = 1;
    public Vector2 GridPosition = new Vector2(0,0);
    // Start is called before the first frame update
    void Start()
    {
      _segments = new List<Transform>();
      _segments.Add(this.transform);   
    }

    // Update is called once per frame
    void Update()
    {
    //handle input
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
 
    
    //handle movement
    if(GridPosition.x > 8 || GridPosition.x < -8 || GridPosition.y > 4.5 || GridPosition.y < -4.5){
    Debug.Log("Game Over");
    }
    else{
    transform.position = new Vector3(GridPosition.x, GridPosition.y, 0);    
    }

}

private void OnTriggerEnter2D(Collider2D other) {
    if(other.gameObject.tag == "Food"){
        Destroy(other.gameObject);
        Debug.Log("Food Eaten");
        score++;
    }
}
}