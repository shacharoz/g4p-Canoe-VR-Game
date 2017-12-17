using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {

    public float SPEED = 1;


	private bool _wallLeft;
	private bool _wallRight;

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
			if (_wallLeft == false)
				transform.Translate (Vector3.left * 1);
			else
				_wallLeft = false;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
			if (_wallRight == false)
				transform.Translate(Vector3.right * 1);
			else
				_wallRight = false;
        }



    }


	//see SendCollisionEvent script for more details
	public void CollidedWithObject (object obj) {
		Collider col = obj as Collider;

		if (this.transform.position.x > 0 && col.transform.position.x > this.transform.position.x) {
			Debug.Log ("bump right wall");
			//this.transform.position = new Vector3 (col.transform.position.x, this.transform.position.y, this.transform.position.z);
			_wallLeft=true;

		} else {

			if (this.transform.position.x < 0 && col.transform.position.x < this.transform.position.x) {
				Debug.Log ("bump left wall");
				//this.transform.position = new Vector3 (col.transform.position.x, this.transform.position.y, this.transform.position.z);
				_wallRight=true;
			}
		}
	}
}
