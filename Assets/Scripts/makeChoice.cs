using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class makeChoice : MonoBehaviour {

    public string choice;
    public dialogueManager manager;
    // Use this for initialization

    public void setText(string newText)
    {
        this.GetComponentInChildren<Text>().text = newText;
    }

    public void setChoice(string newChoice)
    {
        this.choice = newChoice;
    }

    public void parseChoice()
    {
        string command = choice.Split(',')[0];
        string num = choice.Split(',')[1];
        manager.playerTalking = false;
        if (command == "line")
        {
            manager.lineNum = int.Parse(num);
            manager.showText();
        }
        else if (command == "scene")
        {
             SceneManager.LoadScene("Scene" + num);
        }
        else if(command == "file")
        {
            manager.parser.script.Clear();
            manager.parser.LoadDialogue("Assets/Placeholder Assets/" + manager.parser.prefix + "_" + num + ".txt");
            manager.lineNum = 0;
            manager.showText();
        }
    }
}
