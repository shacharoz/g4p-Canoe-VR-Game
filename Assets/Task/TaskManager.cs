using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour {

	private Collider CueTrigger;
	private Collider StimulateTrigger;
	private Collider StartInputTrigger;
	private Collider EndInputTrigger;


	// Use this for initialization
	void Start () {
		CueTrigger = transform.Find ("Task-CueTrigger").GetComponent<Collider> ();
		StimulateTrigger = transform.Find ("Task-StimulateTrigger").GetComponent<Collider> ();
		StartInputTrigger = transform.Find ("Task-StartInputTrigger").GetComponent<Collider> ();
		EndInputTrigger = transform.Find ("Task-EndInputTrigger").GetComponent<Collider> ();


	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartTaskCue(object obj){
		Collider col = obj as Collider;

		Debug.Log ("start task now.Hello user!");

	}


	public void StartStimulation(object obj){
		Collider col = obj as Collider;

		Debug.Log ("Boom boom boom!");

	}


	public void WaitForUserInput(object obj){
		Collider col = obj as Collider;

		Debug.Log ("User please repeat the sequence");

	}

	public void TaskWrapup(object obj){
		Collider col = obj as Collider;

		Debug.Log ("it was a nice task user, you did well. or not...");

	}
}
