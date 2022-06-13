using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float speed = 50;
    
    private bool Left;
    private Rigidbody2D mybody;
    float vecY;

    public static Ball instance;
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null){
            instance = this;
        }else{
            Destroy(gameObject);
        }
        mybody = GetComponent<Rigidbody2D>();
        Invoke("GoBall",1);
    }

    void GoBall(){
        Left = (Random.Range(0,2) > 0) ? true : false; 
        Debug.Log(Left);  
        if(Left){
            mybody.AddForce(new Vector2(-speed,20f));
        }else {
           mybody.AddForce(new Vector2(speed,20f));
        }
    }

    public void ResetBall(){
        mybody.position = Vector3.zero;
        mybody.velocity = Vector2.zero;
        Invoke("GoBall",1);
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.collider.tag != "RightWall" && other.collider.tag != "LeftWall")
            AudioManager.instance.Touch();
        if(other.collider.tag == "Player"){
           
            mybody.velocity = new Vector2(mybody.velocity.x,
            mybody.velocity.y/2 + other.collider.attachedRigidbody.velocity.y/3);
            
        }else if(other.collider.tag == "RightWall"){
            ResetBall();
            GameManager.instance.changeScore("Player");
            AudioManager.instance.Score();
        }else if(other.collider.tag == "LeftWall"){
            ResetBall();
            GameManager.instance.changeScore("Bot");
            AudioManager.instance.Score();
        }else return;
    }
}
