

[System.Serializable]
public class Stimulus{
	public string description;
	public float timeForStimulus;
	public StimulatorSide side;
	public float timeGapAfter;

	public enum StimulatorSide {
		Painful,
		Healthy,
	}
}