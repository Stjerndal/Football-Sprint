using UnityEngine;
using System.Collections;

public class MusicAudio : MonoBehaviour {

	public AudioClip clipMusic;
	
	private AudioSource audioMusic;

	public bool musicEnabled = true;

	private static MusicAudio instance = null;
	public static MusicAudio Instance {
		get { return instance; }
	}
	void Awake() {
		if (instance != null && instance != this) {
			Destroy(this.gameObject);
			return;
		} else {
			instance = this;
		}
		DontDestroyOnLoad(transform.gameObject);
		audioMusic = AddAudio(clipMusic, true, true, 0.2f);
		musicEnabled = (PlayerPrefs.GetInt("musicEnabled", 1) == 1);
		SetMusicPlaying(musicEnabled);
    }
    
	AudioSource AddAudio(AudioClip clip, bool loop, bool playAwake, float vol) {
		AudioSource newAudio = (AudioSource) gameObject.AddComponent("AudioSource");
		newAudio.clip = clip;
		newAudio.loop = loop;
		newAudio.playOnAwake = playAwake;
		newAudio.volume = vol;
		return newAudio;
	}
	
	
	public void SetMusicPlaying(bool enabled) {
		if(!audioMusic) {
			audioMusic = AddAudio(clipMusic, true, true, 0.2f);
		}
		if(enabled && !audioMusic.isPlaying)
			audioMusic.Play();
		else if (!enabled && audioMusic.isPlaying)
            audioMusic.Stop();
        
        musicEnabled = enabled;
    }
}