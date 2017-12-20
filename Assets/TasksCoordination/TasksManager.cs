using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TasksManager : MonoBehaviour {

	private List<TaskController> tasks;

	public GameObject TaskTemplatePrefab;

	public List<TaskProperties> propertiesForTasks;
	public UITaskController uiTaskController;

	public Transform ParentTaskTransform;


	private float PLAYER_LENGTH = 3;

	private float _lastTaskZPos;

	// Use this for initialization
	void Start () {
		_lastTaskZPos = -PLAYER_LENGTH;

		SpawnTask (propertiesForTasks [0]);

	}


	private void SpawnTask(TaskProperties props){
		
		Vector3 nextTaskPos = ParentTaskTransform.position;
		nextTaskPos.z = _lastTaskZPos + props.overallLength;
		_lastTaskZPos = nextTaskPos.z;

		GameObject taskGO = Instantiate (TaskTemplatePrefab, nextTaskPos, Quaternion.identity, ParentTaskTransform);
		TaskController tc = taskGO.GetComponent<TaskController> ();
		tc.uiOutputController = uiTaskController;
		tc.properties = props;

	}



	// Update is called once per frame
	void Update () {

	}
}
