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



		Vector3 moveto = Vector3.forward;
		transform.Translate(moveto * Time.deltaTime * SPEED);

		//keyboard controls left and right
		if (Input.GetKey(KeyCode.LeftArrow))
        {
			if (_wallLeft == false) {
				moveto = Vector3.left;
				transform.Translate (moveto * Time.deltaTime * SPEED);

			} else {
				_wallLeft = false;
			}
        }

		if (Input.GetKey (KeyCode.RightArrow)) {
			if (_wallRight == false) {
				moveto = Vector3.right;
				transform.Translate (moveto * Time.deltaTime * SPEED);

			} else {
				_wallRight = false;
			}
        }


		//keep moving 



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
