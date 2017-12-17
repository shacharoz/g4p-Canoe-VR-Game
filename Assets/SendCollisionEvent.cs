using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendCollisionEvent : MonoBehaviour {

	public List<Transform> TransformsToNotify;
	public List<string> NotifyAboutTheseTags;
	public string functionNameToTrigger = "CollidedWithObject";

	// Use this for initialization
	void Start () {
		
	}


	void OnTriggerEnter(Collider other) {

		//Debug.Log ("hello there "+ other.name+" "+other.tag);
		foreach (string tagName in NotifyAboutTheseTags) {
			if (other.tag == tagName) {
				Notify (other);
			}
		}
	}


	private void Notify(object collidedWith) {
		foreach (Transform t in TransformsToNotify) {
			t.SendMessage (functionNameToTrigger, collidedWith);
		}
	}
}
