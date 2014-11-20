using UnityEngine;
using System.Collections;

public class GUIAudio : MonoBehaviour {
	
	public AudioClip clipButton;
	
	private AudioSource audioButton;

	public bool soundEnabled = true;
	
	AudioSource AddAudio(AudioClip clip, bool loop, bool playAwake, float vol) {
		AudioSource newAudio = (AudioSource) gameObject.AddComponent("AudioSource");
		newAudio.clip = clip;
		newAudio.loop = loop;
		newAudio.playOnAwake = playAwake;
		newAudio.volume = vol;
		return newAudio;
	}
	
	void Awake() {
		//Add the necessary AudioSources
		audioButton = AddAudio(clipButton, false, false, 0.28f);
	}
	
	public void ButtonClick() {
		if(soundEnabled)
			audioButton.Play();
	}
	
}
