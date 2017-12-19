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

	public Sprite RED_SQUARE;
	public Sprite GREEN_SQUARE;


	internal enum State {
		TaskStart,
		Cue,
		Stimulation,
		UserInput,
		TaskEnd
	}
	internal State _state;


	private List<Stimulus> stimuliSequenceData;
	private float startTime;
	private int _stimuliCounter;
	private bool isPulseSent;


	// Use this for initialization
	void Start () {
		_state = State.TaskStart;


		painfulStimulatorEmulator.sprite = RED_SQUARE;
		healthyStimulatorEmulator.sprite = RED_SQUARE;
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
			if (isPulseSent == false) {

				//send stimulus
				healthyStimulatorEmulator.color.a = 0;
				painfulStimulatorEmulator.color.a = 0;

				UnityEngine.UI.Image stimulator = (stimuliSequenceData [_stimuliCounter].side == Stimulus.StimulatorSide.Healthy) ? healthyStimulatorEmulator : painfulStimulatorEmulator;
				stimulator.color.a = 1;

				isPulseSent = true;
			
			} else {
				if (Time.time - startTime > stimuliSequenceData [_stimuliCounter].timeForStimulus) {
					UnityEngine.UI.Image stimulator = (stimuliSequenceData [_stimuliCounter].side == Stimulus.StimulatorSide.Healthy) ? healthyStimulatorEmulator : painfulStimulatorEmulator;
					stimulator.color.a = 0;
					startTime = Time.time;

				} else { 
					if (Time.time - startTime > stimuliSequenceData [_stimuliCounter].timeGapAfter) {

						//move forward the counter
						_stimuliCounter++;
						startTime = Time.time;
						isPulseSent = false;
					}
				}
			}

			break;


		case State.UserInput:

			break;

		}
	}


	public void OnCueStart (TaskProperties properties){
		_state = State.Cue;

		MessageTopScreen (properties.cueMessage);

	}

	public void OnStimulationStart (TaskProperties properties){
		startTime = Time.time;

		isPulseSent = false;
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
