using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManager : MonoBehaviour {

    public int happy = 0;
    public int sad = 0;
    public int angry = 0;
    public int envy = 0;
    public int disgust = 0;
    public int consequence = 0;
    public Sprite[] faces;
	// Use this for initialization
	void Start ()
    {
        DontDestroyOnLoad(this.gameObject);
	}

    public Sprite getFace()
    {
        int i = chooseSprite();
        return faces[i];
    }
    //negative emotions are always negative numbers, happy is always positive, consequence can be either.
    public int chooseSprite()
    {
        int final = 0;
        float negative = sad + angry + disgust + envy;

        if (happy + consequence + negative > -5 && happy + consequence + negative < 5)
        {
            //should be 2 for meh.
            final = 0;
        }
        if (happy + consequence + negative < -5 && happy + consequence + negative > -10)
        {
            //should be 3 for bad.
            final = 0;
        }

        if (happy + consequence + negative < -10)
        {
            //should be 4 for terrible.
            final = 0;
        }
        if (happy + consequence + negative > 5 && happy + consequence + negative < 10)
        {
            //should be 1 for okay.
            final = 0;
        }
        if (happy + consequence + negative > 10)
        {
            //should be 0 for awesome.
            final = 0;
        }
        return final;
    }

    // Update is called once per frame
    public void setHappy(int _happy)
    {
        happy += _happy;
    }

    public void setSad(int _sad)
    {
        sad += _sad;
    }

    public void setAngry(int _angry)
    {
        angry += _angry;
    }

    public void setEnvy(int _envy)
    {
        envy += _envy;
    }

    public void setDisgust(int _disgust)
    {
        disgust += _disgust;
    }
    
    public void setConsequence(int _consequence)
    {
        consequence += _consequence;
    }
}
