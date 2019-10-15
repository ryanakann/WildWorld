using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Audio", menuName = "Audio/AudioAsset", order = 1)]
public class AudioAsset : ScriptableObject {
	public new string name;
	public AudioClip clip;
	public float duration;

	private void Initialize () {
		duration = clip.length;
	}
}
