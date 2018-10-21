using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class canvasManager : MonoBehaviour {

    public GameObject[] buttonPositions;
    public GameObject textbox;
    public GameObject diamondFrame;
    public GameObject sprite;
	// Use this for initialization
	
    public void updateTextbox()
    {
        textbox.SetActive(!textbox.activeInHierarchy);
    }

    public void updateChoice()
    {
        diamondFrame.SetActive(!diamondFrame.activeInHierarchy);
    }

    public Transform getButton(int i)
    {
        return buttonPositions[i].transform;
    }

    public Transform getText(int i)
    {
        return buttonPositions[i].GetComponentInChildren<Text>().transform;
    }
}
