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

    public playerManager player;
    public Text dialogueBox;
    public Text nameBox;
    public GameObject choiceBox;
    public dialogueParser parser;
    public canvasManager canvas;

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
            
            canvas.updateChoice();
            canvas.updateTextbox();
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
                else if (i == 3)
                {
                    if(player.disgust > num) { return false; }
                }
                else if(i == 4)
                {
                    if(player.envy > num) { return false; }
                }
                else if(i == 5)
                {
                    if(player.consequence > num) { return false; }
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
                else if(i == 3)
                {
                    if(player.disgust < num) { return false; }
                }
                else if(i == 4)
                {
                    if(player.envy < num) { return false; }
                }
                else if(i == 5)
                {
                    if(player.consequence < num) { return false; }
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
                else if(i == 3)
                {
                    if(player.disgust != num) { return false; }
                }
                else if(i == 4)
                {
                    if(player.envy != num) { return false; }
                }
                else if(i == 5)
                {
                    if(player.consequence != num) { return false; }
                }
            }
            

        }
        return true;
    }


    public void makeAdditions(string[] _additions)
    {
        //Debug.Log("here");
        for(int i = 0; i < _additions.Length; i++)
        {
            int num = int.Parse(_additions[i]);
            //happy
            if(i == 0)
            {
                player.setHappy(num); 
            }
            //sad
            else if( i == 1)
            {
                player.setSad(num);
            }
            //anger
            else if(i == 2)
            {
                player.setAngry(num);
            }
            //disgust
            else if(i == 3)
            {
                player.setDisgust(num);
            }
            //envy
            else if(i == 4)
            {
                player.setEnvy(num);
            }
            else if(i == 5)
            {
                player.setConsequence(num);
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


                //makeAdditions(additions);
                GameObject button = (GameObject)Instantiate(choiceBox);
                //Button b = button.GetComponent<Button>();
                makeChoice cb = button.GetComponent<makeChoice>();
                cb.setText(textual.Split(':')[0]);
                cb.choice = textual.Split(':')[1];
                cb.manager = this;
                cb.additions = additions;
                button.transform.position = canvas.getButton(i);
                button.transform.SetParent(canvas.diamondFrame.transform);
                button.transform.localScale = new Vector3(1, 1, 1);

                buttons.Add(button.GetComponent<Button>());

            }
            else
            {
                GameObject button = (GameObject)Instantiate(choiceBox);
                //Button b = button.GetComponent<Button>();
                makeChoice cb = button.GetComponent<makeChoice>();
                cb.setText("Option not available");
                cb.choice = "blocked,0";
                cb.manager = this;
                button.transform.position = canvas.getButton(i);
                button.transform.SetParent(canvas.diamondFrame.transform);
                button.transform.localScale = new Vector3(1, 1, 1);
                
                buttons.Add(button.GetComponent<Button>());

            }
        }
        if(choices.Count < 4)
        {
            for(int i = choices.Count; i < 4; i++)
            {
                GameObject button = (GameObject)Instantiate(choiceBox);
                //Button b = button.GetComponent<Button>();
                makeChoice cb = button.GetComponent<makeChoice>();
                cb.setText("Option not available");
                cb.choice = "blocked,0";
                cb.manager = this;
                button.transform.position = canvas.getButton(i);
                button.transform.SetParent(canvas.diamondFrame.transform);
                button.transform.localScale = new Vector3(1, 1, 1);

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
