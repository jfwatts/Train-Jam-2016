using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {
    
    public static GameController controller;

    public float gameMood = 100;
    
    public GameObject results;
    
    public GameObject healthBar;

    public float numOfDudes = 8;
    
    AudioManager am;
    
    public List<Dude> dudes;
	// Use this for initialization
    // make this a singlton
	void Awake () {
        // Allow only one instance of this class across scenes
		if (controller == null) {
			DontDestroyOnLoad (gameObject);
			controller = this;
		} else if (controller != this) {
			Destroy(gameObject);
		}	
	}
	
    void Start(){
        am = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        am.PlayMusic(am.gameMusic);
    }
    
	// Update is called once per frame
	void Update () {
	    //Debug.Log(GetTime());
        //gameMood = CalcGameMood();
        //AdjustMood(gameMood);
        
        
        
        //if(gameMood <= 0){
        //    results.SetActive(true);
         //   Text txt = results.GetComponentInChildren<Text>();
         //   txt.text = "TEST";
            
            // SHOULD PROBABLY PAUSE THE GAME?
            // OR AT LEAST HIDE THE METERS
            //Time.timeScale = 0;
        //}
	}
    
    public int GetTime(){
        return (int)Time.time;
    }
    
    public void AdjustMood(float mood){
        // do something with the mood
        // probably need some average calculation
        //gameMood += mood / numOfDudes;
        if(gameMood < 0){
            return;
        }
        Image img = healthBar.GetComponent<Image>();
        img.fillAmount = mood;
        
    }
    
    // The dude is dead, do something to the mood
    public void DudeDead(){
        numOfDudes = numOfDudes - 1;
        Debug.Log(gameMood);
        gameMood = gameMood - 20;
        AdjustMood(gameMood);
        
        if(numOfDudes <= 6){
            GameOver();
        }
    }
    
    /*float CalcGameMood(){
        
        float mood = 0;
        foreach (Dude d in dudes){
            mood += d.ChillLevel;
            Debug.Log(d.ChillLevel);
        }
        
        Debug.Log("AVG: " + mood /dudes.Count);
        return (mood / dudes.Count);
    }*/
    
    void GameOver(){
        results.GetComponentInChildren<Text>().text = "You partied for\n" + GetTime();
    }
}
