using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UITaskController : MonoBehaviour {



	public UnityAction<TaskProperties> CueStart;
	public UnityAction<TaskProperties> StimulationStart;
	public UnityAction<TaskProperties> InputStart;
	public UnityAction<TaskProperties> TaskEnd;


	public UnityEngine.UI.Text messageTextField;
	public UnityEngine.UI.Image painfulStimulatorEmulator;
	public UnityEngine.UI.Image healthyStimulatorEmulator;


	internal enum State {
		TaskStart,
		Cue,
		Stimulation,
		UserInput,
		TaskEnd
	}
	internal State _state;


	//stimulus
	private List<Stimulus> stimuliSequenceData;
	private float startTime;
	private int _stimuliCounter;
	private bool isPulseSent;
	private bool isPulseEnd;
	private Color col = new Color(1,1,1,0);


	//user input save for CountTasks
	private int _inputCounter=0;
	private 


	// Use this for initialization
	void Start () {
		_state = State.TaskStart;

		col.a = 0;
	}

	void OnEnable() {
		CueStart += OnCueStart;
		StimulationStart += OnStimulationStart;
		InputStart += OnInputStart;
		TaskEnd += OnTaskEnd;
	}

	void OnDisable() {
		CueStart -= OnCueStart;
		StimulationStart -= OnStimulationStart;
		InputStart -= OnInputStart;
		TaskEnd -= OnTaskEnd;
	}



	// Update is called once per frame
	void Update () {

		switch (_state) {

		case State.Stimulation:
			//if stimulation is over dont get into the cycle again
			if (stimuliSequenceData.Count == _stimuliCounter)  return;
			

			if (isPulseSent == false) {

				//send stimulus
				healthyStimulatorEmulator.color = col;
				painfulStimulatorEmulator.color = col;

				UnityEngine.UI.Image stimulator = (stimuliSequenceData [_stimuliCounter].side == Stimulus.StimulatorSide.Healthy) ? healthyStimulatorEmulator : painfulStimulatorEmulator;
				col.a = 1;
				stimulator.color = col;

				isPulseSent = true;
			
			} else if (isPulseEnd == false) {
				if (Time.time - startTime > stimuliSequenceData [_stimuliCounter].timeForStimulus) {

					//reset the emulation
					UnityEngine.UI.Image stimulator = (stimuliSequenceData [_stimuliCounter].side == Stimulus.StimulatorSide.Healthy) ? healthyStimulatorEmulator : painfulStimulatorEmulator;
					col.a = 0;
					stimulator.color = col;
					startTime = Time.time;

					isPulseEnd = true;
				}

			} else {
				if (Time.time - startTime > stimuliSequenceData [_stimuliCounter].timeGapAfter) {

					//move the to next stimulus
					_stimuliCounter++;
					startTime = Time.time;
					isPulseSent = false; isPulseEnd = false;
				}
			}

			break;


		case State.UserInput:

			if (Input.GetKeyDown (KeyCode.Space) == true) {

			}
			break;

		}
	}


	public void OnCueStart (TaskProperties properties){
		_state = State.Cue;

		MessageTopScreen (properties.cueMessage);

	}

	public void OnStimulationStart (TaskProperties properties){
		startTime = Time.time;

		isPulseSent = false; isPulseEnd = false;
		_stimuliCounter = 0;
		stimuliSequenceData = properties.Stimuli;

		MessageTopScreen (properties.stimulationMessage);

		_state = State.Stimulation;

	}

	public void OnInputStart (TaskProperties properties){
		_state = State.UserInput;

		MessageTopScreen (properties.inputStartMessage);

	}

	public void OnTaskEnd (TaskProperties properties){
		_state = State.TaskEnd;

		MessageTopScreen (properties.taskEndMessage);
	}

	private void ActivateOnePulse(){

	}

	private void MessageTopScreen(string message){
		messageTextField.text = message;
	}



}
