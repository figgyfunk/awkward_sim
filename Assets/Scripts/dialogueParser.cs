using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;


public class dialogueParser : MonoBehaviour {
    public List<line> script = new List<line>();
    //holds one line of info. 
    public struct line
    {
        public string name;
        public string text;
        public List<string> choices;

        public line(string _name, string _text)
        {
            name = _name;
            text = _text;
            choices = new List<string>();
        }
    }

    
    //prefix should be similar to what the scene is called for clarity, first file is always 0.
    public string prefix;


    //parses file and creates script for game to read info from. 
    public void LoadDialogue()
    {
        string name = "/Resources/textFiles/";
        name += prefix;
        name += "_0.txt";
        string fileName = Application.dataPath + name;
        string currLine;
        StreamReader r = new StreamReader(fileName, Encoding.Default);

        while ((currLine = r.ReadLine()) != null)
        {
            string[] data = currLine.Split(';');
            if(data.Length == 0) { continue; }
            if(data[0] == "Player")
            {
                line entry = new line(data[0], ""); 
                for(int i = 1; i < data.Length; i++)
                {
                    entry.choices.Add( data[i]);
                }
                script.Add(entry);
            }
            else
            {
                //Debug.Log(currLine);
                line entry = new line(data[0], data[1]);
                script.Add(entry);
            }
        }
        r.Close();
        
    }

    public void LoadDialogue(string fileName)
    {
        string currLine;
        StreamReader r = new StreamReader(fileName);

        while ((currLine = r.ReadLine()) != null)
        {

            string[] data = currLine.Split(';');
            if (data.Length == 0) { continue; }
            if (data[0] == "Player")
            {
                line entry = new line(data[0], "");
                for (int i = 1; i < data.Length; i++)
                {
                    entry.choices.Add(data[i]);
                }
                script.Add(entry);
            }
            else
            {
                line entry = new line(data[0], data[1]);
                script.Add(entry);
            }
        }
        r.Close();

    }
    public string getName(int lineNum)
    {

        if (lineNum < script.Count)
        {
            return script[lineNum].name;
        }
        return "error lineNum greater than script length.";
    }

    public string getText(int lineNum)
    {
        
        if (lineNum < script.Count)
        {
            return script[lineNum].text;
        }
        return "error lineNum greater than script length.";
    }

    public List<string> GetChoices(int lineNum)
    {
        
        if (lineNum < script.Count)
        {
            return script[lineNum].choices;
        }
        return new List<string>();
    }
}
