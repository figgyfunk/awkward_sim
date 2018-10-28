using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicManager : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        DontDestroyOnLoad(this.gameObject);
    }
	
	public void setSong(AudioClip song)
    {
        this.GetComponent<AudioSource>().clip = song;
    }

    public void play()
    {
        this.GetComponent<AudioSource>().Play();
    }

    public void pause()
    {
        this.GetComponent<AudioSource>().Pause();
    }
}
