using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

	public float speed = 5f;

	private float diagonalMod;
	private const string H_AXIS = "Horizontal";
	private const string V_AXIS = "Vertical";


	// Use this for initialization
	void Start () {
		diagonalMod = (float) Mathf.Sin(45);
	}
	
	// Update is called once per frame
	void Update () {
		movementFunc();
		rotateFunc();
	}

	void movementFunc(){
		float HInput = Input.GetAxisRaw(H_AXIS);
		float VIpunt = Input.GetAxisRaw(V_AXIS);

		Vector3 movement = new Vector3(HInput, 0.0f, VIpunt);

		if (HInput != 0 && VIpunt != 0){
			transform.Translate(movement * speed * diagonalMod * Time.deltaTime);
		} else{
			transform.Translate(movement * speed * Time.deltaTime);
		}
	}

	void rotateFunc(){
		Ray moveRay = new Ray(transform.position, -transform.up);
		Debug.DrawRay(moveRay.origin, moveRay.direction, Color.blue);

		RaycastHit hit;
		if (Physics.Raycast(moveRay, out hit)){
			Vector3 newRotation = Quaternion.FromToRotation(transform.up, hit.normal).eulerAngles;
			newRotation.y = 0;
			transform.Rotate(newRotation);
		}
	}
}
