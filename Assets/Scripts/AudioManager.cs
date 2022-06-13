using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] private AudioClip pingpong, win, lose,score;
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null){
            instance = this;
        }else{
            Destroy(gameObject);
        }
    }

    public void Touch(){
        AudioSource.PlayClipAtPoint(pingpong,transform.position);
    }

    public void YouWin(){
        AudioSource.PlayClipAtPoint(win,transform.position);
    }

    public void YouLose(){
        AudioSource.PlayClipAtPoint(lose,transform.position);
    }

    public void Score(){
        AudioSource.PlayClipAtPoint(score,transform.position);
    }
}
