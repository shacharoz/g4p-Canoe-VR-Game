using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowThis : MonoBehaviour {

	public Transform NestUnderThisTransform;

	// Use this for initialization
	void Start () {
		transform.parent = NestUnderThisTransform;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
