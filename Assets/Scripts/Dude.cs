using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class Dude : MonoBehaviour{
    
    // The current mood of the character
    public float chillLevel = 100.0f;
    public float maxChill;
    
    public float chillReductionRate = 0.5f;
    
    public float ChillLevel{
        get {
            return chillLevel;
        }
        set {
            if(value <= maxChill){
                chillLevel = value;
            }
            ChangeChill(chillLevel);
        }
    }
    
    
    public GameController gc;
    
    MouseDrag md;
    
    // ANIMATOR SCRIPT ACCESS
    AnimationScript aniScript;
    faceUpdateScript fuScript;
    
	// Use this for initialization
	void Start () {
        // SUPER SLOW BUT BLAH
        GameObject b = GameObject.Find("GameController");
        gc = b.GetComponent<GameController>();
        md = GetComponentInChildren<MouseDrag>();
        aniScript = GetComponentInChildren<AnimationScript>();
        fuScript = GetComponentInChildren<faceUpdateScript>();
        InvokeRepeating("ModifyHealth", Random.Range(0.0f,1.5f), chillReductionRate);
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
    
    void ChangeChill(float chill) {
        // do UI stuff when the chill changes
        // this would be for the facial expressions or
        // the emoji
        // I might not have to do this if Drad's has set it up in
        // her animation
        //gc.AdjustMood(chill);
        fuScript.happinessLevel = chill;
        //Debug.Log("Chaning Chill: " + chill);
    }
    
    
    // OK SO I DECIDED TO JUST GET THE STATUS FROM THE OTHER CLASS
    // THAT'S STILL KINDA BAD BUT NOT AS BAD AS THE OTHER OPTION
    // I'M TIRED WHAT YOU GONNA DO?
    bool InHotTub(){
        if(md.inHotTub)
            Debug.Log("In Hot Tub");
        else
            Debug.Log("Not In Hot Tub");
            
        return md.inHotTub;
    }
    
    
    void ModifyHealth(){
        if(InHotTub()){
            ChillLevel = ChillLevel + 1;
        }else{
            ChillLevel = ChillLevel - 1;
        }
        
        //if inside hot tub increment health
        // else decrement
        //Debug.Log("Modifying Health");
        //Debug.Log(ChillLevel);
        
        if(ChillLevel <= 0){
            // TODO: Tell the controller
            // we're about to be destroyed
            gc.DudeDead();
            
        }
        
        if(ChillLevel <= -20){
            Destroy(gameObject);
        }
    }
    
}
