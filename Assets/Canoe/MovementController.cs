using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {

    public float SPEED = 1;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		//keep moving forward
        transform.Translate(Vector3.forward * SPEED);



		//keyboard controls left and right
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * 1);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * 1);
        }



    }


	public void CollidedWithObject (object obj) {
		Collider col = obj as Collider;
		//col.
	}
}
