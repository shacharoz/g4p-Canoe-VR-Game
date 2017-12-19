using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TaskManager : MonoBehaviour {

	private Collider CueTrigger;
	private Collider StimulateTrigger;
	private Collider StartInputTrigger;
	private Collider EndInputTrigger;


	public TaskProperties properties;

	public UnityEvent TaskCueStart;
	public UnityEvent TaskStimulationStart;
	public UnityEvent TaskInputStart;
	public UnityEvent TaskEnd;

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

		TaskCueStart.Invoke ();

		Debug.Log ("start task now.Hello user!");

	}


	public void StartStimulation(object obj){
		Collider col = obj as Collider;

		TaskStimulationStart.Invoke ();

		Debug.Log ("Boom boom boom!");

	}


	public void WaitForUserInput(object obj){
		Collider col = obj as Collider;

		TaskInputStart.Invoke ();

		Debug.Log ("User please repeat the sequence");

	}

	public void TaskWrapup(object obj){
		Collider col = obj as Collider;

		TaskEnd.Invoke ();

		Debug.Log ("it was a nice task user, you did well. or not...");

	}
}
