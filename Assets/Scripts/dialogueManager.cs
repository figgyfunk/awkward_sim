using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogueManager : MonoBehaviour {

    public string dialogue, characterName;
    public int lineNum;
    public List<string> choices;
    public bool playerTalking;
    List<Button> buttons = new List<Button>();
    public Transform choicePanel;
    public playerManager player;
    public Text dialogueBox;
    public Text nameBox;
    public GameObject choiceBox;
    public dialogueParser parser;

    // Use this for initialization
    void Start ()
    {
        dialogue = "";
        characterName = "";
        playerTalking = false;
        lineNum = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetMouseButtonDown(0) && playerTalking == false)
        {
            showText();
            lineNum++; 
        }
        updateUI();
	}

    public void showText()
    {

        parseLine();
        //if doing images, reset here. 

    }

    public void parseLine()
    {
        if (parser.getName(lineNum) != "Player")
        {
            playerTalking = false;
            characterName = parser.getName(lineNum);
            dialogue = parser.getText(lineNum);
            //DisplayImages if we want to ya know ;)
            //DisplayImages();
        }
        else
        {
            playerTalking = true;
            characterName = "";
            dialogue = "";
            choices = parser.GetChoices(lineNum);
            CreateButtons();
        }
    }
    private bool parseRequirements(string[] _requirements)
    {
        for(int i = 0; i < _requirements.Length; i++)
        {
            string[] item = _requirements[i].Split(',');
            int num = int.Parse(item[1]);

            if(item[0] == "<" || item[0] == "<=")
            {
                if(i == 0)
                {
                    if(player.happy > num) { return false; }
                }
                else if(i == 1)
                {
                    if(player.sad > num) { return false; }
                }
                else if(i == 2)
                {
                    if(player.angry > num) { return false; }
                }
            }
            if (item[0] == ">" || item[0] == ">=")
            {
                if (i == 0)
                {
                    if (player.happy < num) { return false; }
                }
                else if (i == 1)
                {
                    if (player.sad < num) { return false; }
                }
                else if (i == 2)
                {
                    if (player.angry < num) { return false; }
                }
            }
            if(item[0] == "=")
            {
                if (i == 0)
                {
                    if (player.happy != num) { return false; }
                }
                else if (i == 1)
                {
                    if (player.sad != num) { return false; }
                }
                else if (i == 2)
                {
                    if (player.angry != num) { return false; }
                }
            }
            

        }
        return true;
    }


    private void makeAdditions(string[] _additions)
    {
        for(int i = 0; i < _additions.Length; i++)
        {
            int num = int.Parse(_additions[i]);
            if(i == 0)
            {
                player.setHappy(num); 
            }
            else if( i == 1)
            {
                player.setSad(num);
            }
            else if(i == 2)
            {
                player.setAngry(num);
            }
        }
    }
    void CreateButtons()
    {
        for (int i = 0; i < choices.Count; i++)
        {
            string textual = choices[i].Split('?')[0];
            string[] requirements = choices[i].Split('?')[1].Split('/')[0].Split(':');
            string[] additions = choices[i].Split('?')[1].Split('/')[1].Split(',');
            if (parseRequirements(requirements))
            {
                makeAdditions(additions);
                GameObject button = (GameObject)Instantiate(choiceBox);
                //Button b = button.GetComponent<Button>();
                makeChoice cb = button.GetComponent<makeChoice>();
                cb.setText(textual.Split(':')[0]);
                cb.choice = textual.Split(':')[1];
                cb.manager = this;
                button.transform.SetParent(choicePanel.transform);
                button.transform.localPosition = new Vector3(0, -25 + (i * 150));
                button.transform.localScale = new Vector3(3, 5, 1);
                buttons.Add(button.GetComponent<Button>());
            }
            
        }
    }

    void updateUI()
    {
        if (!playerTalking)
        {
            ClearButtons();
        }
        if(characterName != "" && dialogue != "")
        {
            dialogueBox.text = characterName + ": " + dialogue;
        }
        
        //nameBox.text = characterName;
    }

    void ClearButtons()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            print("Clearing buttons");
            Button b = buttons[i];
            buttons.Remove(b);
            Destroy(b.gameObject);
        }
    }
}
