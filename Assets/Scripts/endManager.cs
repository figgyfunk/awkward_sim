using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endManager : MonoBehaviour
{

    public AudioClip song;
    private musicManager music;
    // Use this for initialization
    void Start()
    {
        music = GameObject.Find("musicManager").GetComponent<musicManager>();
        music.pause();
        music.setSong(song);
        music.play();
    }

}
