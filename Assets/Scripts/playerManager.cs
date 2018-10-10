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
	// Use this for initialization
	void Start ()
    {
        DontDestroyOnLoad(this.gameObject);
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
