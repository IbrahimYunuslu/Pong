using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class musicManagement : MonoBehaviour
{
    public Text musicOnOff;
    public static musicManagement instance;
    private AudioSource gameAudio;
    // Awake is called before the Start();
    void Awake()
    {
        Singleton();
        gameAudio = GetComponent<AudioSource>();
    }

    void Singleton(){
        if(instance != null){
            Destroy(gameObject);
        }if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    public void MusicOnOff()
    {
        if(gameAudio.isPlaying == true){
            gameAudio.Stop();
            musicOnOff.text = "Music On!";
        }else if(gameAudio.isPlaying == false)
        {
            gameAudio.Play();
            musicOnOff.text = "Music Off!";
        }
    }
}
