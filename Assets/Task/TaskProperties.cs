using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskProperties : MonoBehaviour {

	public Mechanism mechanism;

	//cue
	public float cueStartTime = 2;
	public float cueLengthTime = 2;

	//stimulation
	public List<Stimulus> Stimuli;






	public enum Mechanism {
		SequenceMatching,
		RepeatSequence,
		CountTimes,
		IdentifyStronger,

	}

}

[System.Serializable]
public class Stimulus{
	public string description;
	public float timeForStimulus;
	public float timeGapAfter;
}
