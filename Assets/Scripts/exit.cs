using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exit : MonoBehaviour {

    public dialogueParser parser;
    public dialogueManager manager;
    public AudioClip song;
    private musicManager music;
    private void Start()
    {
        music = GameObject.Find("MusicManager").GetComponent<musicManager>();
        music.pause();
        music.setSong(song);
        music.play();
        parser.LoadDialogue();
        manager.parseLine();
        manager.lineNum += 1;
    }
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Application.Quit();
        }
	}
}
