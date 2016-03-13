using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class faceUpdateScript : MonoBehaviour {

	public float happinessLevel;
	public Animator dadimator;
    public AnimationScript animScript;

	public Sprite[] emojis;
	public Sprite[] faces;
	public GameObject currentImage;
	public Image currentSprite;
	public GameObject face;
	public SpriteRenderer faceSprite;

	void Start () {
		currentSprite = currentImage.GetComponent<Image> ();
		faceSprite = face.GetComponent<SpriteRenderer> ();
		dadimator = gameObject.GetComponent<Animator> ();
        animScript = gameObject.GetComponent<AnimationScript>();

	}
	
	void Update () {
	

		if (happinessLevel >= 75) {
			faceSprite.sprite = faces [0];
		} else if (happinessLevel >= 50) {
			faceSprite.sprite = faces [1];
		} else if (happinessLevel >= 25) {
			faceSprite.sprite = faces [2];
		} else if (happinessLevel >= 0) {
			faceSprite.sprite = faces [3];
		}

		if (happinessLevel >= 80) {
			currentSprite.sprite = emojis [0];
		} else if (happinessLevel >= 60) {
			currentSprite.sprite = emojis [1];
		} else if (happinessLevel >= 40) {
			currentSprite.sprite = emojis [2];
		} else if (happinessLevel >= 20) {
			currentSprite.sprite = emojis [3];
		} else if (happinessLevel >= 0) {
			currentSprite.sprite = emojis [4];
		}

		dadimator.SetFloat ("HappinessMeter", happinessLevel);

        if (happinessLevel == 39){
            animScript.becameAngry = true;
        }

	}
}
