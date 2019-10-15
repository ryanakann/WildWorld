using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
	public static AudioManager instance;

	private AudioSource[] audioSources;
	public bool musicPlaying;
	private bool switchingMusic;
	public int audioSourceIndex;
	[Range(0f, 1f)]
	public float musicVolume;
	public float fxVolume;
	

	private void Awake () {
		if (instance) {
			Destroy(gameObject);
		} else {
			instance = this;
			audioSources = new AudioSource[2];
			audioSources[0] = gameObject.AddComponent<AudioSource>();
			audioSources[1] = gameObject.AddComponent<AudioSource>();
			musicPlaying = false;
			switchingMusic = false;
			audioSourceIndex = 0;
			musicVolume = 1f;
			fxVolume = 1f;
		}
	}

	private static float VolumeToDecibels (float vol) {
		return Mathf.Log10(Mathf.Clamp(vol, 0.0001f, 1f));
	}

	private static int IncrementAudioSourceIndex () {
		instance.audioSourceIndex = (instance.audioSourceIndex + 1) % 2;
		return instance.audioSourceIndex;
	}

	public static void PlayMusic (AudioAsset track, float fadeTime = 0f, bool crossfade = false) {
		if (!instance.switchingMusic) {
			instance.switchingMusic = true;
			instance.StartCoroutine(instance.PlayMusicCR(track, fadeTime, crossfade));
		}
	}

	private IEnumerator PlayMusicCR (AudioAsset track, float fadeTime, bool crossfade) {
		int currentIndex = audioSourceIndex;
		int nextIndex = IncrementAudioSourceIndex();

		float t = 0f;
		float rate = 1 / fadeTime;
		audioSources[nextIndex].clip = track.clip;
		audioSources[nextIndex].Play();
		while (t < 1f) {
			audioSources[currentIndex].volume = Mathf.Lerp(musicVolume, 0f, t);

			if (crossfade) {
				audioSources[nextIndex].volume = Mathf.Lerp(0f, musicVolume, t);
			}

			t += rate * Time.deltaTime;
			yield return new WaitForEndOfFrame();
		}
		audioSources[currentIndex].volume = 0f;

		if (!crossfade) {
			t = 0f;
			while (t < 1f) {
				audioSources[nextIndex].volume = Mathf.Lerp(0f, musicVolume, t);
				t += rate * Time.deltaTime;
				yield return new WaitForEndOfFrame();
			}
		}
		audioSources[nextIndex].volume = musicVolume;
		switchingMusic = false;
	}
}