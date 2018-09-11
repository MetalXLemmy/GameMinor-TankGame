using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasterEggTriggerScript : MonoBehaviour {

	private const string PLAYER = "Player";

	public delegate void StartEvent();
	public static event StartEvent PlayerInTrigger;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay(Collider Other){		
		if (Other.gameObject.tag == PLAYER){
			if (PlayerInTrigger != null) {
				PlayerInTrigger();
			}

			transform.Translate(new Vector3(0, -100, 0));
			Destroy(gameObject);
		}
	}
}
