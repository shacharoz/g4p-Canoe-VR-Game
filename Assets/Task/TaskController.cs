using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TaskController : MonoBehaviour {

	private Collider CueTrigger;
	private Collider StimulateTrigger;
	private Collider StartInputTrigger;
	private Collider EndInputTrigger;


	public TaskProperties properties;

	public UITaskController uiOutputController;


	internal enum State {
		TaskStart,
		Cue,
		Stimulation,
		UserInput,
		TaskEnd
	}
	internal State _state;


	// Use this for initialization
	void Start () {
		CueTrigger = transform.Find ("Task-CueTrigger").GetComponent<Collider> ();
		StimulateTrigger = transform.Find ("Task-StimulateTrigger").GetComponent<Collider> ();
		StartInputTrigger = transform.Find ("Task-StartInputTrigger").GetComponent<Collider> ();
		EndInputTrigger = transform.Find ("Task-EndInputTrigger").GetComponent<Collider> ();



		if (uiOutputController == null)
			uiOutputController = GameObject.Find ("UI-Canvas").GetComponent<UITaskController> ();

	}
	

	public void StartTaskCue(object obj){
		Collider col = obj as Collider;

		//TaskCueStart.Invoke ();
		uiOutputController.CueStart.Invoke(properties);

		//Debug.Log ("start task now.Hello user!");

	}


	public void StartStimulation(object obj){
		Collider col = obj as Collider;

		//TaskStimulationStart.Invoke ();
		uiOutputController.StimulationStart.Invoke(properties);

		//Debug.Log ("Boom boom boom!");

	}


	public void WaitForUserInput(object obj){
		Collider col = obj as Collider;

		//TaskInputStart.Invoke ();
		uiOutputController.InputStart.Invoke(properties);

		//Debug.Log ("User please repeat the sequence");

	}

	public void TaskWrapup(object obj){
		Collider col = obj as Collider;

		//TaskEnd.Invoke ();
		uiOutputController.TaskEnd.Invoke(properties);

		//Debug.Log ("it was a nice task user, you did well. or not...");

	}



	// Update is called once per frame
	void Update () {



		switch (_state) {

		case State.Stimulation:
			
			break;


		case State.UserInput:

			if (Input.GetKeyDown (KeyCode.Space) == true) {

			}
			break;


		case State.TaskEnd:

			break;
		}


	}

}
