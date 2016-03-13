using UnityEngine;
using System.Collections;

public class AnimationScript : MonoBehaviour {

	public Animator dadimator;

	public bool pickedUpStanding;
	public bool droppedInTub;
	public bool becameAngry;
	public bool pickedUpFromTub;
	public bool droppedOnGround;
	public bool holdingDad;
	public bool soaking;
	public bool isAngry;


	void Start () {

		dadimator = gameObject.GetComponent<Animator> ();

	}

	void Update () {

		// triggered when standing dad is picked up (clicked on with mouse)
		if (pickedUpStanding) {
			StartCoroutine ("PickUpTrans");
		}

		//state automatically occurs while holding dad after picking up (mouse down?)
		if (holdingDad) {
			dadimator.SetBool ("HoldingDad", true);
			dadimator.SetBool ("PickedUPWhileStanding", false);
			dadimator.SetBool ("PickedUpFromTub", false);
			dadimator.SetBool ("DroppedInTub", false);
			dadimator.SetBool ("DroppedOnGround", false);
			dadimator.SetBool ("BecameAngry", false);
			dadimator.SetBool ("IsAngry", false);
		}

		// triggered when dad dropped in vicinity tub and snaps to available space (unmouse)
		if (droppedInTub) {
			StartCoroutine ("DroppedTub");
		}
			
		// triggered when dad in tub is picked up (clicked on with mouse)
		if (pickedUpFromTub) {
			StartCoroutine ("PickedUpTub");
		}

		// triggered when dad dropped not in vicinity of tub and returns to ground
		if (droppedOnGround) {
			StartCoroutine ("DroppedGround");
		}

		// state automatically occurs while dad is in hot tub
		if (soaking) {
			dadimator.SetBool ("Soaking", true);
			dadimator.SetBool ("DroppedInTub", false);
			droppedInTub = false;
		}

		// triggered when dad is fed up by xyz metered. transition to being angry
		if (becameAngry) {
			StartCoroutine ("GettingAngry");
		}

		// triggered once becameAngry is complete. can be interrupted by pickedUpStanding
		if (isAngry) {
			dadimator.SetBool ("IsAngry", true);
			dadimator.SetBool ("BecameAngry", false);

		}
	}

	IEnumerator PickUpTrans(){
		dadimator.SetBool ("PickedUPWhileStanding", true);
		yield return new WaitForSeconds (1.0f);
		dadimator.SetBool ("HoldingDad", true);
		holdingDad = true;
		pickedUpFromTub = false;
		pickedUpStanding = false;
		isAngry = false;
		becameAngry = false;
		droppedOnGround = false;
	}

	IEnumerator DroppedTub(){
		dadimator.SetBool ("DroppedInTub", true);
		yield return new WaitForSeconds (1.0f);
		dadimator.SetBool ("Soaking", true);
		dadimator.SetBool ("HoldingDad", false);
		holdingDad = false;
		soaking = true;
	}

	IEnumerator PickedUpTub(){
		dadimator.SetBool ("PickedUpFromTub", true);
		yield return new WaitForSeconds (1.0f);
		dadimator.SetBool ("HoldingDad", true);
		dadimator.SetBool ("Soaking", false);
		soaking = false;
		pickedUpFromTub = false;
		holdingDad = true;

	}

	IEnumerator DroppedGround(){
		dadimator.SetBool ("DroppedOnGround", true);
		yield return new WaitForSeconds (1.0f);
		dadimator.SetBool ("HoldingDad", false);
		dadimator.SetBool ("DroppedOnGround", false);
		holdingDad = false;
		droppedOnGround = false;
	}

	IEnumerator GettingAngry(){
		dadimator.SetBool ("BecameAngry", true);
		yield return new WaitForSeconds (3.0f);
		if (!holdingDad) {
			dadimator.SetBool ("IsAngry", true);
			dadimator.SetBool ("BecameAngry", false);
			isAngry = true;
			becameAngry = false;
		}
	}
}