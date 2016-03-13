using UnityEngine;
using System.Collections;

public class Seat : MonoBehaviour {
    
    public bool occupied = false;

	public int id = 0;
    
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
