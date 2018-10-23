using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exit : MonoBehaviour {

    public dialogueParser parser;
    public dialogueManager manager;
    private void Start()
    {
        parser.LoadDialogue();
        manager.showText();
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
