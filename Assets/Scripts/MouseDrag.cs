using UnityEngine;
using System.Collections;

public class MouseDrag : MonoBehaviour {    
    float x;
    float y;
    
    bool snapped = false;
    bool onsnap = false;
    
    // HACK HACK HACK AS FUCK
    public bool inHotTub = false;
        
    Seat seat;
	
    AnimationScript aniScript;
	public int id;
    
    void Start(){
        aniScript = GetComponentInChildren<AnimationScript>();
		id = Random.Range (1, 100);
    }
    
	// Update is called once per frame
	void Update (){
	    x = Input.mousePosition.x;
        y = Input.mousePosition.y;
	}
    
    void OnMouseUp(){
        if(snapped){
            snapped = false;
        } else {
            aniScript.droppedOnGround = true;
        }
    }
    
    void OnMouseDrag(){
        if(!snapped){
            // This make the object follow the mouse cursor
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(x,y,10.0f));
        }  
    }
    
    void OnMouseDown(){
        Debug.Log("This is only called once, right?");
        aniScript.pickedUpStanding = true;  
    }
    
    void OnTriggerEnter2D(Collider2D other){        
        if(other.tag == "Seat"){
            seat = other.GetComponent<Seat>();
            // no one is in the seat
			if(!seat.Occupied && seat.id != id){
                transform.position = other.transform.position;
                snapped = true;
                seat.Occupied = true;
				seat.id = id;
                inHotTub = true;
                //aniScript.pickedUpStanding = false;
                onsnap = true;
                aniScript.droppedInTub = true;
            }
        }
    }
    
    void OnTriggerExit2D(Collider2D other){
        if(other.tag == "Seat"){
			if(seat.Occupied && seat.id == id && onsnap){
                seat.Occupied = false;
                inHotTub = false;
				seat.id = 0;
                aniScript.pickedUpFromTub = true;
            }
        }
    }
}

