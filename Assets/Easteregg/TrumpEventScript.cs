using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrumpEventScript : MonoBehaviour {

	public AudioClip VoiceClip;
	public AudioClip MusicClip;

	public AudioSource MyAudioSource;

	// Use this for initialization
	void Start () {
		MyAudioSource.clip = VoiceClip;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnEnable() {
		GetComponent<Renderer>().enabled = !GetComponent<Renderer>().enabled;
		EasterEggTriggerScript.PlayerInTrigger += StartEvent;
	}

	void OnDisable() {
		EasterEggTriggerScript.PlayerInTrigger -= StartEvent;
	}

	void StartEvent() {
		StartCoroutine(TrumpEvent());
	}

	IEnumerator TrumpEvent(){
		GetComponent<Renderer>().enabled = !GetComponent<Renderer>().enabled;

		MyAudioSource.Play();

		while (transform.position.y <= -1.46f) {
			yield return new WaitForEndOfFrame();
			transform.Translate(Vector3.up * Time.deltaTime / 1.2f);
		}
		
		MyAudioSource.Stop();
		MyAudioSource.clip = MusicClip;
		MyAudioSource.Play();
	}
}
