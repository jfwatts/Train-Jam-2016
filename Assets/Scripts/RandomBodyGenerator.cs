using UnityEngine;
using System.Collections;

public class RandomBodyGenerator : MonoBehaviour {

	public int colour;
	public int hairstyleChoice;
	public int towelColourChoice;
	public int bodyType;
	public int torsoAdder;
	public int IdNumber;

	public Sprite[] hairstyles;
	public Sprite[] towelColour;
	public Sprite[] bodyShapes; //store 6 body shapes, get colour, multiply by 1 or 2 to get rndom

	public Sprite[] b_heads;
	public Sprite[] b_rightArms;
	public Sprite[] b_rightForearms;
	public Sprite[] b_leftArms;
	public Sprite[] b_leftForearms;
	public Sprite[] b_rightThighs;
	public Sprite[] b_rightShins;
	public Sprite[] b_rightFeet;
	public Sprite[] b_leftThighs;
	public Sprite[] b_leftShins;
	public Sprite[] b_leftFeet;
	public SpriteRenderer[] bodyParts;

	public SpriteRenderer hair;
	public SpriteRenderer towel;
	public SpriteRenderer body;

	public SpriteRenderer head;
	public SpriteRenderer rightArm;
	public SpriteRenderer rightForearm;
	public SpriteRenderer leftArm;
	public SpriteRenderer leftForearm;
	public SpriteRenderer rightThigh;
	public SpriteRenderer rightShin;
	public SpriteRenderer rightFoot;
	public SpriteRenderer leftThigh;
	public SpriteRenderer leftShin;
	public SpriteRenderer leftFoot;

	// Use this for initialization
	void Start () {

		colour = Random.Range (0, 3);
		hairstyleChoice = Random.Range (0, 4);
		towelColourChoice = Random.Range (0, 3);
		bodyType = Random.Range (1, 3);
		if (bodyType == 1) {
			torsoAdder = 0;
		} else if (bodyType == 2){
			torsoAdder = 3;
		}
		//generate random number to determine colour 1, 2, or 3
		//pick random hair type, 1, 2, 3 or 4
		//pick random towel colour 1, 2 or 3;
		//pick random body type, 1 or 2

		hair.sprite = hairstyles [hairstyleChoice];
		towel.sprite = towelColour [towelColourChoice];
		body.sprite = bodyShapes [colour+torsoAdder];

		head.sprite = b_heads [colour];
		rightArm.sprite = b_rightArms [colour];
		rightForearm.sprite = b_rightForearms [colour];
		leftArm.sprite = b_leftArms [colour];
		leftForearm.sprite = b_leftForearms[colour];
		rightThigh.sprite = b_rightThighs [colour];
		rightShin.sprite = b_rightShins [colour];
		rightFoot.sprite = b_rightFeet [colour];
		leftThigh.sprite = b_leftThighs [colour];
		leftShin.sprite = b_leftShins [colour];
		leftFoot.sprite = b_leftFeet [colour];

		foreach (SpriteRenderer bodyPart in bodyParts) {
			bodyPart.sortingOrder = bodyPart.sortingOrder + (20 * IdNumber);
		}
	}


}
