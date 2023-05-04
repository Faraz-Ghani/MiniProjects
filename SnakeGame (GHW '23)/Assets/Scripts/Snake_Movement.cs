using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake_Movement : MonoBehaviour
{
    private List<Transform> _segments;
    public Transform segmentPrefab; 
    public int score=1;
    public float timer = 0;
    public float timerMax = 1;
    public Vector2 _direction = Vector2.right;
    // Start is called before the first frame update
    void Start()
    {
      _segments = new List<Transform>();
      _segments.Add(this.transform);   
      Grow();
    }

    // Update is called once per frame
    void Update()
    {
        
    //handle input
    if(Input.GetKeyDown(KeyCode.UpArrow) && _direction != Vector2.down )
        {
            _direction = Vector2.up;
        }
    else if(Input.GetKeyDown(KeyCode.DownArrow) && _direction != Vector2.up)
        {
            _direction = Vector2.down;
        }
    else if(Input.GetKeyDown(KeyCode.LeftArrow) && _direction != Vector2.right)
            {
            _direction = Vector2.left;
            }
    else if(Input.GetKeyDown(KeyCode.RightArrow) && _direction != Vector2.left)
        {
            _direction = Vector2.right;
        } 
 
    
   
}

private void FixedUpdate() {
     //handle growth
    for(int i= _segments.Count-1;i>0;i--){
        _segments[i].position = _segments[i-1].position;
    }

    
    transform.eulerAngles = new Vector3(0,0,GetAngleFromVecot(_direction));
    this.transform.position = new Vector3(
        Mathf.Round(this.transform.position.x) + _direction.x,
        Mathf.Round(this.transform.position.y) + _direction.y,
        0f
    );    
}


private void OnTriggerEnter2D(Collider2D other) {
    if(other.gameObject.tag == "Food"){
        Destroy(other.gameObject);
        score++;
        Grow();
    }
    if(other.gameObject.tag == "Segment"){
       GameOver();
       }
    
    if(other.gameObject.tag == "Wall"){
      GameOver();
    }
}

public void GameOver(){
 _direction = Vector2.zero;
 
}

public float GetAngleFromVecot(Vector2 Dir){
    float n = Mathf.Atan2(Dir.y,Dir.x) * Mathf.Rad2Deg;
    if(n<0) n+=360;
    return n;
}

public void Grow(){
    Transform segment = Instantiate(this.segmentPrefab);
    segment.position = _segments[_segments.Count-1].position;
    _segments.Add(segment);
}
}