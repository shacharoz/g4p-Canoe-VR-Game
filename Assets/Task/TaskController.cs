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



	//saving user input and response
	private bool isCountingResponseTime;
	private float startTimeCount;
	private float endTimeCount; 



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

		SendStimuliSequenceToHardware();
	}


	public void WaitForUserInput(object obj){
		Collider col = obj as Collider;

		_state = State.UserInput;

		//TaskInputStart.Invoke ();
		uiOutputController.InputStart.Invoke(properties);

	}

	public void TaskWrapup(object obj){
		Collider col = obj as Collider;

		_state = State.TaskEnd;


		bool isUserCorrect = CalculateIsUserCorrectOnTask ();
		Debug.Log ("user is correct: " + isUserCorrect);



		//TaskEnd.Invoke ();
		uiOutputController.TaskEnd.Invoke(properties);


	}


	// Update is called once per frame
	void Update () {

		switch (_state) {

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

		}

	}




	private void SendStimuliSequenceToHardware(){

		//convert sequence of stimulus into a byte array and send to hardware controller over bluetooth
	}


	private bool CalculateIsUserCorrectOnTask(){
		bool result = false;

		List<UserResponse> responses = responseRecorder.GetAllResponses ();

		switch (properties.mechanism) { 
		case TaskProperties.Mechanism.CountTimesPainful:

			int painCounter = 0;
			foreach (Stimulus st in properties.Stimuli) {
				if (st.side == Stimulus.StimulatorSide.Painful)
					painCounter++;
			}

			if (responses.Count == painCounter)
				result = true;

			break;


		case TaskProperties.Mechanism.CountTimesHealthy:
			int healthyCounter = 0;
			foreach (Stimulus st in properties.Stimuli) {
				if (st.side == Stimulus.StimulatorSide.Healthy)
					healthyCounter++;
			}

			if (responses.Count == healthyCounter)
				result = true;

			break;


		case TaskProperties.Mechanism.CountTimesTotal:
			if (responses.Count == properties.Stimuli.Count)
				result = true;

			break;




		case TaskProperties.Mechanism.IdentifyStronger:
			break;


		case TaskProperties.Mechanism.RepeatSequence:
			break;

		}



		return result;
	}
}
