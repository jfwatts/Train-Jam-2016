using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {
    
    public AudioSource music;
    public AudioSource sfx;
    public AudioClip titleMusic;
    public AudioClip gameMusic;
    public AudioClip winMusic;
    public static AudioManager instance = null;
    
    
    public AudioClip[] soundEfx;
	// Use this for initialization
	void Awake () {
	    if(instance == null){
            instance = this;
        }else if(instance != this){
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
	}
	
	public void PlaySingle(AudioClip clip){
        sfx.clip = clip;
        sfx.Play();
    }
    
    public void PlayMusic(AudioClip clip){
        music.clip = clip;
        music.loop = true;
        music.Play();
    }
}
