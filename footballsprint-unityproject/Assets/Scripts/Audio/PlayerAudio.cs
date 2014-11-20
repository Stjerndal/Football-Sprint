using UnityEngine;
using System.Collections;

public class PlayerAudio : MonoBehaviour {

	public AudioClip clipJump;
	public AudioClip clipDoubleJump;
	public AudioClip clipFootsteps;
	public AudioClip clipCollect;
	public AudioClip clipDie;

	private AudioSource audioJump;
	private AudioSource audioDoubleJump;
	private AudioSource audioFootsteps;
	private AudioSource audioCollect;
	private AudioSource audioDie;

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
		audioJump = AddAudio(clipJump, false, false, 0.9f);
		audioDoubleJump = AddAudio(clipDoubleJump, false, false, 0.9f);
		audioFootsteps = AddAudio(clipFootsteps, true, false, 0.4f);
		audioCollect = AddAudio(clipCollect, false, false, 0.5f);
		audioDie = AddAudio(clipDie, false, false, 0.06f);
		audioDie.pitch = 1.23f;
	}

	public void Jump() {
		if(soundEnabled) {
			audioJump.Play();
			RunStop();
		}
	}

	public void DoubleJump() {
		if(soundEnabled) {
		audioDoubleJump.Play();
		}
	}

	public void Run() {
		if(soundEnabled) {
			if(!audioFootsteps.isPlaying)
				audioFootsteps.Play();
		}
	}

	public void RunStop(){
		if(audioFootsteps.isPlaying)
			audioFootsteps.Stop();
	}

	public void Collect() {
		if(soundEnabled) {
			audioCollect.Play();
		}
	}

	public void Die() {
		if(soundEnabled) {
			audioDie.Play();
			RunStop();
		}
	}

	public void StopAll() {
		if(audioJump.isPlaying) audioJump.Stop();
		if(audioDoubleJump.isPlaying) audioDoubleJump.Stop();
		if(audioFootsteps.isPlaying) audioFootsteps.Stop();
		if(audioCollect.isPlaying) audioCollect.Stop();
		if(audioDie.isPlaying) audioDie.Stop();
	}

}
