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

	private UserResponseRecorder responseRecorder;

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

		responseRecorder = new UserResponseRecorder ();

		_state = State.TaskStart;

	}
	

	public void StartTaskCue(object obj){
		Collider col = obj as Collider;

		_state = State.Cue;

		//TaskCueStart.Invoke ();
		uiOutputController.CueStart.Invoke(properties);

		//Debug.Log ("start task now.Hello user!");

	}


	public void StartStimulation(object obj){
		Collider col = obj as Collider;

		_state = State.Stimulation;

		//TaskStimulationStart.Invoke ();
		uiOutputController.StimulationStart.Invoke(properties);

		//Debug.Log ("Boom boom boom!");

	}


	public void WaitForUserInput(object obj){
		Collider col = obj as Collider;

		_state = State.UserInput;

		//TaskInputStart.Invoke ();
		uiOutputController.InputStart.Invoke(properties);

		//Debug.Log ("User please repeat the sequence");

	}

	public void TaskWrapup(object obj){
		Collider col = obj as Collider;

		_state = State.TaskEnd;

		//TaskEnd.Invoke ();
		uiOutputController.TaskEnd.Invoke(properties);

		//Debug.Log ("it was a nice task user, you did well. or not...");

	}


	private bool isCountingResponseTime;
	private float startTimeCount;
	private float endTimeCount; 

	// Update is called once per frame
	void Update () {



		switch (_state) {

		case State.Stimulation:
			
			break;


		case State.UserInput:
			
			if (isCountingResponseTime == false && Input.GetKeyDown (KeyCode.Space) == true) {
				//Debug.Log ("start count");
				startTimeCount = Time.time;
				isCountingResponseTime = true;
			}
			if (isCountingResponseTime == true && Input.GetKeyUp (KeyCode.Space) == true) {
				//Debug.Log ("end count");
				endTimeCount = Time.time;
				isCountingResponseTime = false;

				responseRecorder.AddResponse (startTimeCount, endTimeCount);
			}
			break;


		case State.TaskEnd:
			//Debug.Log (responseRecorder.GetAllResponses());
			break;
		}


	}

}
