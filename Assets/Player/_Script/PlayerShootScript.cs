using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootScript : MonoBehaviour {

	private const string FIREBUTTON = "Fire1";
	private const string INDESTRUCTABLE = "Indestructable";


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Ray TurretRay = new Ray(transform.position, -transform.up);

		RaycastHit hit;
		if (Physics.Raycast(TurretRay, out hit) && Input.GetButton(FIREBUTTON) && hit.transform.tag != INDESTRUCTABLE){
			Debug.DrawRay(TurretRay.origin, TurretRay.direction, Color.white);
			Destroy(hit.transform.gameObject);
		}
	}
}