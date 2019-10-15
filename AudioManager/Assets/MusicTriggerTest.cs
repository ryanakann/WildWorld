using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTriggerTest : MonoBehaviour
{
	public AudioAsset music1;
	public AudioAsset music2;

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.J)) {
			AudioManager.PlayMusic(music1, 2f, false);
		} else if (Input.GetKeyDown(KeyCode.K)) {
			AudioManager.PlayMusic(music2, 4f, true);
		}
    }
}
