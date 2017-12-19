using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetParentTransform : MonoBehaviour {

	public Transform NestUnderThisTransform;

	// Use this for initialization
	void Start () {
		transform.parent = NestUnderThisTransform;

	}

}
