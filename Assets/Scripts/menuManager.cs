using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuManager : MonoBehaviour {

    public AudioClip song;
    public musicManager music;
	// Use this for initialization
	void Start ()
    {
        music.setSong(song);
        music.play();
	}
	
	
}
