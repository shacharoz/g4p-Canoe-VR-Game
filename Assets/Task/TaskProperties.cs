using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskProperties : MonoBehaviour {

	public Mechanism mechanism;

	public float overallLength;

	//cue
	public float cueStartTime = 2;
	public float cueLengthTime = 2;
	public string cueMessage = "";

	//stimulation
	public string stimulationMessage = "";
	public List<Stimulus> Stimuli;

	//
	public string inputStartMessage = "";

	//
	public string taskEndMessage = "";




	public enum Mechanism {
		RepeatSequence,     //repeat the sequence of pulses 
		CountTimesHealthy,  //count the number of pulses on the healthy body part
		CountTimesPainful,  //count the number of pulses on the painful body part
		IdentifyStronger,   //identify which was the storngest of the pulses
	}


}