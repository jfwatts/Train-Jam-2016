using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class DudeSpawner : MonoBehaviour {

    public GameObject dude;
    public GameObject dudeHolder;
    
    public Transform spawnLocation;
    
    public float spawnRange;
    
    public int maxDudes;
    
    // SUPER HACKY SPACING TO MAKE IT LOOK NICE
    public int spacing;
    
    
    public static int startNum;
    
    GameController gc;
      
	// Use this for initialization
	void Start () {
        
        gc = GameObject.Find("GameController").GetComponent<GameController>();
        startNum = 80;
        
        for (int i = 0; i < maxDudes; i++){
             //range = Random.Range(0,dudes.Count);
             // should check this
             GameObject obj = Instantiate(dude) as GameObject;
             obj.transform.SetParent(dudeHolder.transform);
             obj.transform.position = GetPosition(spawnLocation);
             RandomBodyGenerator rbg = obj.GetComponentInChildren<RandomBodyGenerator>();
             rbg.IdNumber = startNum + 1;
             startNum = rbg.IdNumber;
             obj.SetActive(true);
             gc.dudes.Add(obj.GetComponent<Dude>());
             
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    float lastx = 0;
    Vector3 GetPosition(Transform location){
        float x = location.position.x;
        float y = location.position.y;
        float z = location.position.z;
        
        //float range = Random.Range(-spawnRange, spawnRange);
        //x = x + range;
        if(lastx == 0){
            lastx = x;
        }
        x = lastx + spacing;
        lastx = x;
        
        Debug.Log("Calling this");
        Debug.Log("X: " + x);
        Debug.Log("Y: " + y);
        Debug.Log("Z: " + z);
        
        
        return new Vector3(x,y,z);
    }
    
    
    
}
