using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBarrelScript : MonoBehaviour {

	public float speed;

	private const string MOVETURRET = "MoveTurret";

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton(MOVETURRET)){
			transform.Rotate(new Vector3(0, Input.GetAxis(MOVETURRET) * speed * Time.deltaTime, 0));
		}
	}
}
