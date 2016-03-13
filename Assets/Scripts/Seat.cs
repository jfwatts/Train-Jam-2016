using UnityEngine;
using System.Collections;

public class Seat : MonoBehaviour {
    
    bool occupied = false;
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    public bool Occupied{
        get { Debug.Log("GET: " + occupied); return occupied; }
        set { Debug.Log("SET: " + value); occupied = value; }
    }
}
